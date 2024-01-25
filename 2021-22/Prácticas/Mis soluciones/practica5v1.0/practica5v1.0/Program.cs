using System;
using System.Collections;
using System.Collections.Generic;

namespace funciones
{
    public static class Program
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
            var aux = new List<T>();
            foreach (var elem in collection)
            {
                if (pred(elem))
                    aux.Add(elem);
            }
            return aux;
        }
    }
}
