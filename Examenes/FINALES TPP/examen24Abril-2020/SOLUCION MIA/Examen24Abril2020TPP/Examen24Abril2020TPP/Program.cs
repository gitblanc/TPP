using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Examen24Abril2020TPP
{
    public class Program
    {
        static object bloqueadorHashSet = new object();
        static object ob = new object();

        static void Main(string[] args)
        {
            Console.WriteLine(ClausulaVocales("Mensaajero")());
        }

        //EJERCICIO 1 - CLÁUSULAS - SIN TERMINAR
        public static Func<int> ClausulaVocales(string cadena)
        {
            int contA = 0;
            for(int i = 0; i < cadena.Length; i++)
            {
                if (cadena[i].ToString().ToLower().Equals("a"))
                {
                    contA++;
                }
            }
            return () => contA;
        }

        public static IDictionary<int, IList<T>> Ejercicio2<T>(IEnumerable<T> elements, IEnumerable<Predicate<T>> predicates)
        {
            IDictionary<int, IList<T>> dict = new Dictionary<int, IList<T>>();
            foreach (Predicate<T> p in predicates)
            {
                int counter = 0;
                IList<T> list = new List<T>();
                foreach (T var in elements)
                {
                    if (p(var))
                    {
                        counter++;
                        list.Add(var);
                    }
                }
                dict.Add(counter, list);
            }
                
            return dict;
        }

        //SEGUNDA PARTE

        public static long ImparesVocal(string[] palabra)
        {
            long res = 0;
            for (int i = 0; i < palabra.Length; i++)
            {
                if (palabra[i].Length % 2 != 0)
                {
                    if (palabra[i].ToLower().StartsWith("a") || palabra[i].ToLower().StartsWith("e") || palabra[i].ToLower().StartsWith("i")
                        || palabra[i].ToLower().StartsWith("o") || palabra[i].ToLower().StartsWith("u"))
                    {
                        res++;
                    }
                }
            }
               return res;
        }

        public static long ParesConsonante(string[] palabra)
        {
            long res = 0;
            for (int i = 0; i < palabra.Length; i++)
            {
                if (palabra[i].Length % 2 == 0)
                {
                    if (!palabra[i].ToLower().EndsWith("a") && !palabra[i].ToLower().EndsWith("e") && !palabra[i].ToLower().EndsWith("i")
                        && palabra[i].ToLower().EndsWith("o") && !palabra[i].ToLower().EndsWith("u"))
                    {
                        res++;
                    }
                }
            }
            return res;
        }

        public static void Ejercicio3V1(string[] palabras)
        {
            long consonante = 0;
            long vocal = 0;
            Parallel.Invoke(
                () => consonante = ParesConsonante(palabras), () => vocal = ImparesVocal(palabras)
                );
            Console.WriteLine("Consonantes: " + consonante + ", vocales: " + vocal);
        }

        public static void Ejercicio3V2(string[] palabras)
        {
            long vocales = 0;
            long consonantes = 0;
            long res1 = 0;
            long res2 = 0;
            HashSet<int> listaHilos = new HashSet<int>();
            Parallel.ForEach(palabras, elem =>
            {
                lock (ob) //Bloquear el vector
                {
                    if (elem.Length % 2 != 0)
                    {
                        if (elem.ToLower().StartsWith("a") || elem.ToLower().StartsWith("e") || elem.ToLower().StartsWith("i") || elem.ToLower().StartsWith("o") || elem.ToLower().StartsWith("u"))
                        {
                            vocales++;
                        }
                    }

                    if (elem.Length % 2 == 0)
                    {
                        if (!elem.ToLower().EndsWith("a") && !elem.ToLower().EndsWith("e") && !elem.ToLower().EndsWith("i") && !elem.ToLower().ToLower().EndsWith("o") && !elem.ToLower().EndsWith("u"))
                        {
                            consonantes++;
                        }
                    }
                }

                lock (bloqueadorHashSet) //Bloquear el HashSet
                {
                    listaHilos.Add(Thread.CurrentThread.ManagedThreadId);
                }
            });

            res1 = vocales;
            res2 = consonantes;
            Console.WriteLine("Palabras de longitud impar que empiezan por vocal: {0}", res1);
            Console.WriteLine("Palabras de longitud par que terminan por consonante: {0}", res2);
            Console.WriteLine("Numero de hilos usados: {0}", listaHilos.Count());
        }

        public static string[] CrearPalabrasAleatorias(int numeroElementos, short minimo, short maximo)
        {
            Random random = new Random();
            string[] vector = new string[numeroElementos];
            for (int i = 0; i < numeroElementos; i++)
                vector[i] = String.Concat(new char[(short)random.Next(minimo, maximo + 1)].Select(c => (char)random.Next(97, 123)));
            return vector;
        }


        static void MostrarLinea(TextWriter stream, string numHilosCabecera, string ticksCabecera)
        {
            stream.WriteLine("{0};{1}", numHilosCabecera, ticksCabecera);
        }

        static void MostrarLinea(TextWriter stream, int numHilos, long ticks)
        {
            stream.WriteLine("{0:N0};{1:N0}", numHilos, ticks);
        }
    }
}
