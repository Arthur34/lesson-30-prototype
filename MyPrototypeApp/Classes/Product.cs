using MyPrototypeApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrototypeApp.Classes
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class Product : IMyCloneable<Product>, ICloneable
    {
        public string Code;
        public string Name;

        public Product(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public object Clone() => Copy();

        public virtual Product Copy() => new(Code, Name);
    }
}
