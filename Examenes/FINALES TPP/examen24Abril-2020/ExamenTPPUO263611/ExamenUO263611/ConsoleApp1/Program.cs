using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1
{
    static class Program
    {
        static object bloqueadorHashSet = new object();
        static object ob = new object();
        static void Main(string[] args)
        {
           var ej1 = "Mensajero".Ejercicio1();
           foreach(var elem in ej1)
            {
                Console.WriteLine(elem);
            }

            Ejercicio3(CrearPalabrasAleatorias(10000, 3, 8));
            Ejercicio4();
        }

        public static IEnumerable<int> Ejercicio1(this string palabra)
        {
            IList<int> repeticiones = new List<int>();
            int contadorA = 0;
            int contadorE = 0;
            int contadorI = 0;
            int contadorO = 0;
            int contadorU = 0;
            for(int i = 0; i < palabra.Length; i++)
            {
                if(palabra[i].ToString().ToLower().Equals("a"))
                {
                    contadorA++;
                }
                else if(palabra[i].ToString().ToLower().Equals("e"))
                {
                    contadorE++;
                }
                else if(palabra[i].ToString().ToLower().Equals("i"))
                {
                    contadorI++;
                }
                else if(palabra[i].ToString().ToLower().Equals("o"))
                {
                    contadorO++;
                }
                else if(palabra[i].ToString().ToLower().Equals("u"))
                {
                    contadorU++;
                }
            }

            repeticiones.Add(contadorA);
            repeticiones.Add(contadorE);
            repeticiones.Add(contadorI);
            repeticiones.Add(contadorO);
            repeticiones.Add(contadorU);

            return repeticiones;
        }

        public static void Ejercicio3(this string[] vector)
        {
            long vocales = 0;
            long consonantes = 0;
            long res1 = 0;
            long res2 = 0;
            HashSet<int> listaHilos = new HashSet<int>();
            Parallel.ForEach(vector, elem =>
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

                lock(bloqueadorHashSet) //Bloquear el HashSet
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

        public static void Ejercicio4()
        {
            System.IO.StreamWriter salidaMultihilo = new System.IO.StreamWriter("salidaMultihilo.csv");
            var vector = CrearPalabrasAleatorias(1000, 2, 5);
            MostrarLinea(salidaMultihilo, "Num hilos", "Ticks");
            for (int i = 1; i <= 20; i++)
            {
                Stopwatch t = new Stopwatch();
                Master m = new Master(vector, i);
                t.Start();
                m.CalcularModulo();
                t.Stop();
                MostrarLinea(salidaMultihilo, i, t.ElapsedTicks);
                GC.Collect();
                GC.WaitForFullGCComplete();
            }
            salidaMultihilo.Close();
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
