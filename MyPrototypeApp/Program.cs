using MyPrototypeApp.Classes;
using MyPrototypeApp.Interfaces;

internal class Program
{
    private static T Copy<T>(IMyCloneable<T> obj) => obj.Copy();

    private static object Clone(ICloneable obj) => obj.Clone();

    /// <summary>
    /// Проверка глубокого копирования заказа
    /// </summary>
    private static bool CheckCopyOrders(Order o1, Order o2)
    {
        // проверяем объекты на идентичность
        if (object.ReferenceEquals(o1, o2))
            return false;

        // проверяем поля
        if (o1.Id != o2.Id || o1.DateDelivery != o2.DateDelivery)
            return false;

        // должны быть разные объекты-массивы
        if (object.ReferenceEquals(o1.ListGoods, o2.ListGoods))
            return false;

        // проверяем количество товаров
        if (o1.ListGoods?.Length != o2.ListGoods?.Length)
            return false;

        // проверяем все товары
        for (int i = 0; i < o1.ListGoods.Length; i++)
        {
            if (!CheckCopyGoodsSaleHistory(o1.ListGoods[i], o2.ListGoods[i]))
                return false;
        }

        return true;
    }

    /// <summary>
    /// Проверка глубокого копирования товара с историей
    /// </summary>
    private static bool CheckCopyGoodsSaleHistory(ProductSaleHistory g1, ProductSaleHistory g2)
    {
        // Должны быть физически разные объекты
        if (object.ReferenceEquals(g1, g2))
            return false;

        // Совпадающие значения полей значимых типов
        if (g1.Code != g2.Code || g1.Name != g2.Name)
            return false;

        // Должны быть физически разные объекты-массивы
        if (object.ReferenceEquals(g1.Sales, g2.Sales))
            return false;

        // Совпадает количество дней продаж
        if (g1.Sales?.Length != g2.Sales?.Length)
            return false;

        // Проверяем равенство дней продаж
        for (int i = 0; i < g1.Sales.Length; i++)
        {
            if (g1.Sales[i].Date != g2.Sales[i].Date || g1.Sales[i].Amount != g2.Sales[i].Amount ||
                g1.Sales[i].IsPromotion != g2.Sales[i].IsPromotion)
            {
                return false;
            }
        }

        // ок
        return true;
    }

    private static void Main(string[] args)
    {
        var order = new Order(1, new DateTime(2024, 02, 15), new ProductSaleHistory[]
        {
                new ProductSaleHistory("X001", "GamePad X1", new ProductSale[]
                {
                    new ProductSale(new DateTime(2024, 02, 01), 220, true),
                    new ProductSale(new DateTime(2024, 01, 02), 550, true),
                    new ProductSale(new DateTime(2023, 04, 03), 0, false),
                    new ProductSale(new DateTime(2023, 03, 04), 700, false)
                })
        });

        Console.WriteLine("IMyClonable test");
        var orderCopy = Copy(order);
        Console.WriteLine($"Copy check: {CheckCopyOrders(order, orderCopy)}");

        Console.WriteLine("\nIClonable test");
        var orderClone = Clone(order);
        Console.WriteLine($"Copy check: {CheckCopyOrders(order, (Order)orderClone)}");

        Console.Write("\n\nPress <Enter> for exit...");
        Console.ReadLine();
    }
}