using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrototypeApp.Classes
{
    /// <summary>
    /// Информация о продажах за день
    /// </summary>
    public struct ProductSale
    {
        public DateTime Date;
        public decimal Amount;
        public bool IsPromotion;

        public ProductSale(DateTime date, decimal amount, bool isPromo)
        {
            Date = date;
            Amount = amount;
            IsPromotion = isPromo;
        }
    }
}
