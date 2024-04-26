using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace _03Procesado.Tareas.Secuencial.Locales
{
    internal class Program
    {
        /// <summary>
        /// Se presenta una sobrecarga del método ForEach en la que cada partición genera un resultado local.
        /// 
        /// </summary>
        static void Main()
        {
            var vector = GenerarVectorAleatorio(-10, 10, 1000000);
            int resultadoTotal = 0;
            Stopwatch sw = new Stopwatch();

            sw.Start();

            //<T,S> donde T es el tipo de origen y S es el tipo del resultado local.
            Parallel.ForEach<int, int>(//la TAREA es un sumatorio de un vector
                                       //IEnumerable<T> a recorrer. Potencialmente un hilo por elemento.
                vector,

                // Func<S> que inicializa la variable de resultado local para la partición.
                () => 0,

                //Func<T,ParallelLoopState, S> que representa el algoritmo a ejecutar.
                // Es la función que acumula
                (actual, loopState, resultadoLocal) =>
                {

                    resultadoLocal += actual;
                    return resultadoLocal;
                },

                //Action<Q> una vez finalizada la partición, ¿qué hacer con el resultado local?
                resultadoLocalFinal => Interlocked.Add(ref resultadoTotal, resultadoLocalFinal)
                // hay que tener cuidado con la variable resultadoTotal, que es compartida
                // sólo se haría un lock por cada hilo ejecutado
                // Esta forma no es necesaria si no hay recursos compartidos
                // Es un tipo de master worker
            );
            sw.Stop();

            Console.WriteLine("El sumatorio total es {0}. Tiempo: {1}.", resultadoTotal, sw.ElapsedMilliseconds);

            //EJERCICIO:
            //Impleméntese el cálculo del valor mínimo en el vector anterior, siguiendo los dos enfoques posibles:
            //  - Empleando resultados parciales/locales.
            //  - No empleando resultados parciales/locales (téngase en cuenta los posibles recursos compartidos).
            // Imprímase el tiempo empleado para cada uno de los enfoques.


            //EJERCICIO:
            //Impleméntese el ejercicio anterior empleando el For, almacenando la POSICIÓN del valor mínimo.
            //Debe almacenarse la posición más cercana al inicio del vector que contenga el valor mínimo:
            //      {4, 5, 6, 1, 4, 5, 6, 1} -> Resultado esperado: 3
            int[] array = { 4, 5, 6, 1, 4, 5, 6, 1 };
            var minPosition = 0;
            object obj = new();
            Action<int> valorMenor = elem =>
            {
                lock (obj)
                {
                    if (array[elem] == array[minPosition] && elem < minPosition)
                        minPosition = elem;
                    else if (array[elem] < array[minPosition])
                        minPosition = elem;
                }
            };
            Parallel.For(minPosition, array.Length, valorMenor);
            Console.WriteLine("Resultado esperado: 3 - Resultado real: {0}", minPosition);
        }

        static int[] GenerarVectorAleatorio(int min, int max, int tam)
        {
            Random random = new Random();
            int[] vector = new int[tam];

            for (int i = 0; i < tam; i++)
                vector[i] = random.Next(min, max + 1);

            return vector;
        }
    }
}
