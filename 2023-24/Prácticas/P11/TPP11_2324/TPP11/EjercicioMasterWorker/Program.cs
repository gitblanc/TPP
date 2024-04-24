using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace EjercicioMasterWorker
{
    class Program
    {
        /// <summary>
        /// A partir del Master Worker de la entrega obligatoria, prueba las siguientes modificaciones:
        /// -Los workers almacenarán en una lista "Resultado", los valores que sean superiores a la cantidad buscada.
        ///     - No admitirá duplicados.
        ///     - La lista Resultado la pasa el Master a los workers y DEBE SER LA MISMA PARA TODOS LOS WORKERS.
        /// </summary>
        /// <param name="args"></param>


        /*
        * This program processes Bitcoin value information obtained from the
        * url https://api.kraken.com/0/public/OHLC?pair=xbteur&interval=5.
        */
        static void Main(string[] args)
        {

            /* NOTA
             * Acordarse que para ejecutar un Master-Worker correctamente, poner el modo Release >> Compilar la solución y ejecutarla un par de veces
             * 
             * PASAR A .CSV
             * - Abrir la carpeta donde se encuentra este proyecto (Click derecho en ObligatoriaSesion10 >> Open Folder in Explorer)
             * - Ir a /bin/Release/netX.X/
             * - Abrir un cmd y ejecutar el ".exe" -> $ ObligatoriaSesion10.exe >> result.csv
             * - Guardarlo como un libro de Excel (y no como un .csv) 
             * - Generar la gráfica correspondiente con su debida argumentación
             */

            const int maximoHilos = 50;
            long valorPrefijado = 7000; //CAMBIAR ESTE PARÁMETRO

            var data = Utils.GetBitcoinData();

            //Console.WriteLine(CultureInfo.CurrentCulture);
            //foreach (var d in data)
            //    Console.WriteLine(d);

            MostrarLinea(Console.Out, "Num Hilos", "Ticks", "Resultado");

            //Toma de tiempos.
            Stopwatch stopWatch = new Stopwatch();

            for (int numeroHilos = 1; numeroHilos <= maximoHilos; numeroHilos++)
            {
                MasterModificado master = new MasterModificado(data, numeroHilos, valorPrefijado);
                stopWatch.Restart();
                var resultado = master.ContarVeces();
                stopWatch.Stop();

                MostrarLinea(Console.Out, numeroHilos, stopWatch.ElapsedTicks, resultado.Count);
                foreach (var item in resultado)
                    Console.Write(item + " ");

                Console.WriteLine();
                //Entre ejecuciones, limpiamos y esperamos.
                GC.Collect();
                GC.WaitForFullGCComplete();
            }

        }

        static void MostrarLinea(TextWriter stream, string numHilosCabecera, string ticksCabecera, string resultadoCabecera)
        {
            stream.WriteLine("{0};{1};{2}", numHilosCabecera, ticksCabecera, resultadoCabecera);
        }

        static void MostrarLinea(TextWriter stream, int numHilos, long ticks, double resultado)
        {
            stream.WriteLine("{0};{1:N0};{2:N2}", numHilos, ticks, resultado);
        }
    }
}
