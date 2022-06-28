using System;
using System.Collections.Generic;
using System.Text;

namespace cosasDeClase
{
    internal static class Functions
    {
        static public T Find<T>(this IEnumerable<T> collection, Predicate<T> f)
        {
            foreach (var elem in collection)
            {
                if (f(elem))
                    return elem;
            }
            return default(T);
        }

        static public IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Predicate<T> f)
        {
            var aux = new List<T>();
            foreach (var elem in collection)
            {
                if (f(elem))
                    aux.Add(elem);
            }
            return aux;
        }
        static public IEnumerable<T> FilterLazy<T>(this IEnumerable<T> collection, Predicate<T> f)
        {
            foreach (var elem in collection)
            {
                if (f(elem))
                    yield return elem;
            }
        }

        static public T2 Reduce<T1, T2>(this IEnumerable<T1> collection, Func<T2, T1, T2> f, T2 d = default(T2))
        {
            foreach (var elem in collection)
            {
                d = f(d, elem);
            }
            return d;
        }
    }
}
