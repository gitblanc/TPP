using System;
using Modelo;

using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace TPP07
{
    static class Program
    {
        static void Main()
        {

            IEnumerable<int> valores = Enumerable.Range(1, 9);//partiendo del 1, genera 9 elementos

            Console.WriteLine("Colecciones de enteros.");

            //Uso de métodos extensores
            //Map transforma una secuencia de <T>s en una secuencia de <Q>s.
            valores.Map(n => n * n).ForEach(Console.WriteLine);
            Console.WriteLine();

            valores.Map(n => n * n).Map(n => n / 2.0).ForEach(Console.WriteLine);
            Console.WriteLine();

            valores.Map(n => new Angulo(n))
                .Map(a => a.Grados)
                .ForEach(a => Console.WriteLine(a)); // .ForEach(Console.WriteLine) <- ¿Sabes el motivo?

            Console.WriteLine();

            Console.WriteLine("\nColecciones de Personas.");

            var personas = Factoria.CrearPersonas();

            var nombres = personas.Map(p => p.Nombre);
            nombres.ForEach(Console.WriteLine);
            Console.WriteLine();

            var iniciales = personas.Map(p => p.Nombre).Map(cadena => cadena[0]);
            iniciales.ForEach(Console.WriteLine);
            Console.WriteLine();
            personas.Map(p => p.Nif + "\t" + p.Nombre + "\t" + p.Apellido).ForEach(Console.WriteLine);


            //¿Qué estamos haciendo aquí?
            //Colección de objetos anónimos -> haces un map y lo conviertes a un objeto anónimo
            var info = personas.Map(p => new
            {
                Nombre = p.Nombre,
                Dni = p.Nif
            }
            );

            info.ForEach(Console.WriteLine);

            /* EJERCICIO:
            * - Añade el método Map a tu lista genérica.
            * - A partir de una lista de enteros: Calcula la suma de los cuadrados de la colección.
            * - A partir de una lista de Personas: Calcula la longitud media de los nombres de la colección.
            */


            //Método ZIP de Linq: Combina dos secuencias:
            // Genera una tupla por cada elemento
            Console.WriteLine("Ejercicio BIEN");
            var combinación = valores.Zip(personas.Map(p => p.Nombre));
            combinación.Map(c => c.First + " : " + c.Second).ForEach(Console.WriteLine);

            /* EJERCICIO EXAMEN: Implementa el método Zip de LINQ:
             * - Colecciones potecialmente infinitas.
             * - Trabajará con tuplas .
             * */
            Console.WriteLine("Ejercicio EXAMEN");
            var combinacion2 = valores.MyZip(personas.Map(p => p.Nombre));
            combinacion2.Map(c => c.Item1 + " : " + c.Item2).ForEach(Console.WriteLine);
        }

        //Es como el ejercicio de examen
        public static IEnumerable<(T, Q)> MyZip<T, Q>(this IEnumerable<T> collection1, IEnumerable<Q> collection2)
        {
            // Un iterador al crearlo apunta al -1
            var enumerator1 = collection1.GetEnumerator();
            var enumerator2 = collection2.GetEnumerator();
            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                yield return (enumerator1.Current, enumerator2.Current);
            }
        }
    }
}
