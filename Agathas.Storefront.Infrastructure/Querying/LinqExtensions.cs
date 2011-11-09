using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Infrastructure.Querying
{
    public static class LinqExtensions
    {
        /// <summary>
        ///  Thanks to Timothy Khouri - http://www.singingeels.com/Articles/Extending_LINQ__Specifying_a_Property_in_the_Distinct_Function.aspx.
        /// </summary>        
       public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, Func<T, object> uniqueCheckerMethod)
       {
           return source.Distinct(new GenericComparer<T>(uniqueCheckerMethod));
       }

       public class GenericComparer<T> : IEqualityComparer<T>
       {
           public GenericComparer(Func<T, object> uniqueCheckerMethod)
           {
               this._uniqueCheckerMethod = uniqueCheckerMethod;
           }

           private Func<T, object> _uniqueCheckerMethod;

           bool IEqualityComparer<T>.Equals(T x, T y)
           {
               return this._uniqueCheckerMethod(x).Equals(this._uniqueCheckerMethod(y));
           }

           int IEqualityComparer<T>.GetHashCode(T obj)
           {
               return this._uniqueCheckerMethod(obj).GetHashCode();
           }
       }
    }        
}
