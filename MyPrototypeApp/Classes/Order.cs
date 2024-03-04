using MyPrototypeApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrototypeApp.Classes
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order : IMyCloneable<Order>, ICloneable
    {
        public int Id;
        public DateTime DateDelivery;
        public ProductSaleHistory[] ListGoods;

        public Order(int id, DateTime dateDelivery, ProductSaleHistory[] listGoods)
        {
            Id = id;
            DateDelivery = dateDelivery;
            ListGoods = listGoods;
        }

        public object Clone() => Copy();

        public virtual Order Copy()
        {
            var copyGoods = ListGoods.Select(g => g.Copy()).ToArray();
            return new Order(Id, DateDelivery, copyGoods);
        }
    }
}
