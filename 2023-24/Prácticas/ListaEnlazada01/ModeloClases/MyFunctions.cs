using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloClases
{
    public class MyFunctions
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
    }
}
