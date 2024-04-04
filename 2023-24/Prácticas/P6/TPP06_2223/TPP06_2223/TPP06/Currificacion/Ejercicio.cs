
using System;
using System.Collections.Generic;

namespace Currificacion
{
    public static class Ejercicio
    {
        //Ejercicio 1..

        //Implementar de forma currificada el método Buscar entregado en la sesión anterior.
        //Demostrar el uso de su invocación y de la aplicación parcial.
        public static T Find<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                    return item;
            }
            return default;
        }

        public static Func<Predicate<T>, T> FindCurrificado<T>(IEnumerable<T> collection)//, Predicate<T> predicate)
        {
            return predicate =>
            {
                foreach (var item in collection)
                {
                    if (predicate(item))
                        return item;
                }
                return default;
            };
        }

        //Ejercicio 2. EXAMEN

        // Si - > 5 / 3 = 1 ; Resto = 2

        // Entonces -> 3 * 1 + 2 = 5;

        //Currifíquese la función y compruébese mediante el uso de la aplicación parcial el siguiente ejemplo:

        // Se sabe que la división:  20 / 6 = 3. Se desconoce el valor del resto.
        // Partiendo del valor 0, e incrementalmente, obténgase el resto.

        public static bool ComprobarDivision(int divisor, int dividendo, int cociente, int resto)
        {
            return dividendo == cociente * divisor + resto;
        }

        public static Predicate<int> ComprobarDivisionCurrificada1(int divisor, int dividendo, int cociente)//, int resto)
        {
            return resto => dividendo == cociente * divisor + resto;//return dividendo == cociente * divisor + resto;
        }

        public static Func<int, Predicate<int>> ComprobarDivisionCurrificada2(int divisor, int dividendo)//, int cociente)//, int resto)
        {
            return cociente =>
            {
                return resto => dividendo == cociente * divisor + resto;
            };
        }

        public static Func<int, Func<int, Predicate<int>>> ComprobarDivisionCurrificada3(int divisor)//, int dividendo)//, int cociente)//, int resto)
        {
            return dividendo =>
            {
                return cociente =>
                {
                    return resto => dividendo == cociente * divisor + resto;
                };
            };
        }

        /*
         * Método Extensor de Tuplas para Mapeo y Filtrado Condicional: Crea un método extensor currificado para IDictionary<TKey, TValue> 
         * que permita filtrar la colección basándose en una condición aplicada a TKey y luego mapear TValue a un nuevo valor. 
         * El resultado debe ser un IDictionary<TKey, TResult>.
         */
        //Sin currificar
        public static IDictionary<Tkey, TRes> Ejercicio8a_P6<Tkey, TValue, TRes>(this IDictionary<Tkey, TValue> dictionary, Predicate<Tkey> condition, Func<TValue, TRes> mapper)
        {
            Dictionary<Tkey, TRes> res = new();
            foreach (var item in dictionary)
            {
                if (condition(item.Key))
                {
                    res[item.Key] = mapper(item.Value);
                }
            }

            return res;
        }

        //Currificado (1 vez)
        public static Func<Func<TValue, TRes>, IDictionary<Tkey, TRes>> Ejercicio8b_P6<Tkey, TValue, TRes>(this IDictionary<Tkey, TValue> dictionary, Predicate<Tkey> condition)//, Func<TValue, TRes> mapper)
        {
            return mapper =>
            {
                Dictionary<Tkey, TRes> res = new();
                foreach (var item in dictionary)
                {
                    if (condition(item.Key))
                    {
                        res[item.Key] = mapper(item.Value);
                    }
                }

                return res;
            };
        }

        //ESTO ESTA MAL, PORQUE NO SE LE ESTARÍA PASANDO NINGÚN PARÁMETRO (FIJARSE QUE ES EXTENSOR)
        //public static Func<Predicate<Tkey>, Func<Func<TValue, TRes>, IDictionary<Tkey, TRes>>> Ejercicio8c_P6<Tkey, TValue, TRes>(this IDictionary<Tkey, TValue> dictionary)//, Predicate<Tkey> condition)//, Func<TValue, TRes> mapper)
        //{
        //    return condition =>
        //    {
        //        return mapper =>
        //        {
        //            Dictionary<Tkey, TRes> res = new();
        //            foreach (var item in dictionary)
        //            {
        //                if (condition(item.Key))
        //                {
        //                    res[item.Key] = mapper(item.Value);
        //                }
        //            }

        //            return res;
        //        };
        //    };
        //}
    }
}
