using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloClases
{
    public static class MyFunctions
    {
        // FUNCIONES DE ORDEN SUPERIOR

        /// <summary>
        /// A partir de una colección de elementos, nos devuelve el primero que cumpla un criterio 
        /// dado o su valor por defecto en el caso de no existir ninguno.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="predicate"></param>
        /// <returns>Element found or its default</returns>
        public static T Find<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                    return item;
            }
            return default;
        }

        /// <summary>
        /// A partir de una colección de elementos, nos devuelve todos aquellos 
        /// que cumplan un criterio dado (siendo éste parametrizable)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="predicate"></param>
        /// <returns>IEnumerable<T></returns>
        public static IEnumerable<T> Filter<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            IEnumerable<T> res = new List<T>();
            foreach (var item in collection)
            {
                if (predicate(item))
                    res = res.Append(item);
            }

            return res;
        }

        /// <summary>
        /// Esta función recibe una colección de elementos y una función que recibe 
        /// un primer parámetro del tipo que tenemos y un segundo parámetro del tipo 
        /// que queremos obtener; su tipo devuelto es el propio del que queremos obtener.
        /// </summary>
        /// <typeparam name="TP"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="collection"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        public static TR Reduce<TP, TR>(IEnumerable<TP> collection, Func<TP, TR, TR> function)
        {
            TR res = default;
            foreach (var item in collection)
            {
                res = function(item, res);
            }
            return res;
        }
        /// <summary>
        /// Con parámetros opcionales, para evitar los nullpointerexception (un ejemplo es con un Diccionario)
        /// </summary>
        /// <typeparam name="TP"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="collection"></param>
        /// <param name="function"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public static TR Reduce<TP, TR>(IEnumerable<TP> collection, Func<TP, TR, TR> function, TR res = default)
        {
            foreach (var item in collection)
            {
                res = function(item, res);
            }
            return res;
        }

        //----------------------------------------------
        //----------------------------------------------
        //-----------------EXTENSORES-------------------
        //----------------------------------------------
        //----------------------------------------------
        // A partir de aquí, se añaden métodos extensores (métodos genéricos de orden superior)

        /// <summary>
        /// Método Buscar extensor (exclusivo) para mi lista (es decir, no de IEnumerable)
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="predicate"></param>
        /// <returns>El primer elemento que encuentre y cumpla el predicato o su valor por defecto</returns>
        public static T MyFind<T>(this LinkedList<T> collection, Predicate<T> predicate)
        {
            foreach (T item in collection)
            {
                if (predicate(item))
                    return item;
            }
            return default;
        }

        /// <summary>
        /// Método Filtrar extensor (exclusivo) para mi lista
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="predicate"></param>
        /// <returns>Una lista con los elementos que cumplan el predicate</returns>
        public static LinkedList<T> MyFilter<T>(this LinkedList<T> collection, Predicate<T> predicate)
        {
            var result = new LinkedList<T>();
            foreach (T item in collection)
            {
                if (predicate(item))
                    result.Add(item);
            }

            return result;
        }

        /// <summary>
        /// Método Reducir extensor (exclusivo) para mi lista (con valor por defecto)
        /// </summary>
        /// <typeparam name="TS"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="collection"></param>
        /// <param name="function"></param>
        /// <param name="res"></param>
        /// <returns>El valor acumulado o bien un valor por defecto</returns>
        public static TR MyReduce<TS, TR>(this LinkedList<TS> collection, Func<TS, TR, TR> function, TR res = default)
        {
            foreach (TS item in collection)
            {
                res = function(item, res);
            }

            return res;
        }

        /// <summary>
        /// Método Reducir extensor (exclusivo) para mi lista (sin valor por defecto)
        /// </summary>
        /// <typeparam name="TS"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="collection"></param>
        /// <param name="function"></param>
        /// <param name="res"></param>
        /// <returns>El valor acumulado o bien un valor por defecto</returns>
        public static TR MyReduce<TS, TR>(this LinkedList<TS> collection, Func<TS, TR, TR> function)
        {
            TR res = default;
            foreach (TS item in collection)
            {
                res = function(item, res);
            }

            return res;
        }

        /// <summary>
        /// Método Invertir extensor (exclusivo) para mi lista
        /// Se crea una Pila y se va sacando elemento a elemento, que se añade a una lista auxiliar
        /// </summary>
        /// <param name="collection"></param>
        /// <returns>Lista con todos los elementos existentes al revés</returns>
        public static LinkedList<T> MyInvert<T>(this LinkedList<T> collection)
        {
            MyStack<T> stack = new MyStack<T>((uint)collection.Count());
            LinkedList<T> list = new LinkedList<T>();
            foreach (T item in collection)
                stack.Push(item);
            for (int i = 0; i < collection.NumberOfElements; i++)
            {
                list.Add(stack.Pop());
            }
            return list;
        }

        /// <summary>
        /// Método Map extensor (exclusivo) para mi lista
        /// </summary>
        /// <typeparam name="TS"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="collection"></param>
        /// <param name="function"></param>
        /// <returns>Lista con elementos transformados por la función pasada como parámetro</returns>
        public static LinkedList<TR> MyMap<TS, TR>(this LinkedList<TS> collection, Func<TS, TR> function)
        {
            var res = new LinkedList<TR>();
            foreach (TS item in collection)
            {
                res.Add(function(item));
            }
            return res;
        }

        /// <summary>
        /// Método ForEach extensor (exclusivo) para mi lista
        /// Va recorriendo la colección y haciendo la acción pasada como parámetro
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="cuerpo"></param>
        public static void MyForEach<T>(this LinkedList<T> collection, Action<T> cuerpo)
        {
            var iterador = collection.GetEnumerator();
            while (iterador.MoveNext())
            {
                cuerpo(iterador.Current);
            }
        }
    }
}
