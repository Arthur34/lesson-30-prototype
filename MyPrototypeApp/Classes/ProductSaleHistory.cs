using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrototypeApp.Classes
{
    /// <summary>
    /// История продаж продукта
    /// </summary>
    public class ProductSaleHistory : Product
    {
        public ProductSale[] Sales;

        public ProductSaleHistory(string code, string name)
            : base(code, name)
        { }

        public ProductSaleHistory(string code, string name, ProductSale[] sales)
            : this(code, name)
        {
            Sales = sales;
        }

        public override ProductSaleHistory Copy()
        {
            var copy = new ProductSaleHistory(Code, Name);

            copy.Sales = new ProductSale[Sales.Length];
            Sales.CopyTo(copy.Sales, 0);
            return copy;
        }
    }
}
