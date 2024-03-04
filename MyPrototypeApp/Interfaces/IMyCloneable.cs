using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrototypeApp.Interfaces
{
    /// <summary>
    /// Дженерик интерфейс IMyCloneable для реализации шаблона "Прототип"
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IMyCloneable<T>
    {
        T Copy();
    }
}
