using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrototypeApp.Classes
{
    /// <summary>
    /// Доп. заказ к основному заказу
    /// </summary>
    public class AdditionalOrder : Order
    {
        public Order FirstOrder;

        public AdditionalOrder(int id, DateTime dateDelivery, ProductSaleHistory[] listGoods, Order firstOrder)
            : base(id, dateDelivery, listGoods)
        {
            FirstOrder = firstOrder;
        }

        public override AdditionalOrder Copy()
        {            
            var firstCopy = FirstOrder.Copy();                                  // копируем родительский заказ
            var copyGoods = ListGoods.Select(g => g.Copy()).ToArray();          // копируем свои товары
            return new AdditionalOrder(Id, DateDelivery, copyGoods, firstCopy); // Создаём копию
        }
    }
}
