using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace clases
{
    public static class Funciones
    {
        static public T Find<T>(this IEnumerable<T> collection, Predicate<T> pred)
        { //this para que pueda ser extensor
            foreach (var elem in collection)
            {
                if (pred(elem))
                    return elem;
            }
            return default(T);
        }

        static public IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Predicate<T> pred)
        {
            var aux = new T[collection.Count()];
            int i = 0;
            foreach (var elem in collection)
            {
                if (pred(elem))
                {
                    aux[i] = elem;
                    ++i;
                }
            }
            Array.Resize(ref aux, i);
            if (i == 0)
                return default(IEnumerable<T>);
            return aux;
        }

        static public T2 Reduce<T1, T2>(this IEnumerable<T1> collection, Func<T1, T2, T2> func, T2 d = default(T2))
        {
            foreach (var elem in collection)
            {
                d = func(elem, d);
            }
            return d;
        }

        static public IEnumerable<T2> Map<T1, T2>(this IEnumerable<T1> collection, Func<T1, T2> f)
        {
            T2[] result = new T2[collection.Count()];
            int i = 0;
            foreach (var elem in collection)
            {
                result[i] = f(elem);
                i++;
            }
            return result;
        }

        static void Show<T>(this IEnumerable<T> collection)
        {
            foreach (var elem in collection)
                Console.WriteLine($"{elem} ");
            Console.WriteLine();
        }
    }
}
