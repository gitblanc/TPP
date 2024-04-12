using System;
using System.Diagnostics;
using System.IO;
using System.Numerics;

namespace MasterWorkerClase
{
    class Program
    {
        // A través de 2 arrays de enteros (el tamaño del 2º es <= al del 1º)
        // Calcular el número de veces que ses repite el 2º array en el primero.
        // Suponer que tendrá un máximo de longitudV1/longitudV2 hilos
        // Ejemplo:
        // { 2, 2, 1, 3, 2, 2, 1, 2, 1, 2, 2, 1 } y { 2, 2, 1}
        // Resultado: 3
        static void Main(string[] args)
        {
            const int maximoHilos = 12;
            short[] v1 = new short[] { 2, 2, 1, 3, 2, 2, 1, 2, 1, 2, 2, 1 };
            short[] v2 = new short[] { 2, 2, 1 };

            MostrarLinea(Console.Out, "Num Hilos", "Ticks", "Resultado");

            //Toma de tiempos.
            Stopwatch stopWatch = new Stopwatch();

            for (int numeroHilos = 1; numeroHilos <= maximoHilos; numeroHilos++)
            {
                Master master = new(v1, v2, numeroHilos);
                stopWatch.Restart();
                long resultado = master.ContarRepeticiones();
                stopWatch.Stop();

                MostrarLinea(Console.Out, numeroHilos, stopWatch.ElapsedTicks, resultado);

                //Entre ejecuciones, limpiamos y esperamos.
                GC.Collect();
                GC.WaitForFullGCComplete();
            }

            //Probarlo posteriormente con el RandomVector.
            short[] v1b = CreateRandomVector(1000, 0, 4);
            short[] v2b = CreateRandomVector(2, 0, 4);

            MostrarLinea(Console.Out, "Num Hilos", "Ticks", "Resultado");

            //Toma de tiempos.

            for (int numeroHilos = 1; numeroHilos <= 50; numeroHilos++)
            {
                Master master = new(v1b, v2b, numeroHilos);
                stopWatch.Restart();
                long resultado = master.ContarRepeticiones();
                stopWatch.Stop();

                MostrarLinea(Console.Out, numeroHilos, stopWatch.ElapsedTicks, resultado);

                //Entre ejecuciones, limpiamos y esperamos.
                GC.Collect();
                GC.WaitForFullGCComplete();
            }
        }

        public static short[] CreateRandomVector(int numberOfElements, short lowest, short greatest)
        {
            short[] vector = new short[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = (short)random.Next(lowest, greatest + 1);
            return vector;
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
