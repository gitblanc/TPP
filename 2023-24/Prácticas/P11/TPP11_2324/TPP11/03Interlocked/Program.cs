using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
namespace _03Interlocked
{
    class Program
    {

        /// <summary>
        /// Una alternativa más eficiente a lock es el uso de la clase Interlocked (System.Threading)
        /// Realiza asignaciones de forma primitiva.
        /// Métodos más utilizados: Increment, Decrement, CompareExchange, Add.
        /// https://learn.microsoft.com/en-us/dotnet/api/system.threading.interlocked?view=net-7.0
        /// Observa bien con qué tipos pueden utilizarse.
        /// </summary>
        static void Main()
        {
            const long valor = 100000000;
            const int numHilos = 10;

            Console.WriteLine("Valor esperado como resultado: 0.");
            MostrarLinea(Console.Out, "Num Hilos", "Ticks", "Resultado");
            //Toma de tiempos.
            Stopwatch stopWatch = new Stopwatch();

            //COMENTAR DESDE AQUI
            stopWatch.Restart();
            Sumatorio sumatorio = new Sumatorio(valor, numHilos);
            sumatorio.Calcular();
            stopWatch.Stop();

            MostrarLinea(Console.Out, numHilos, stopWatch.ElapsedTicks, sumatorio.Valor);

            Console.WriteLine("Valor tras realizar la operación directamente : {0}.", sumatorio.Valor);
            //HASTA AQUI

            /*
             * RESULTADO
             * Valor esperado como resultado: 0.
             * Num Hilos;Ticks;Resultado
             * 10;28.692.951;0,00
             * Valor tras realizar la operación directamente : 0.
             * 
             */

            //COMENTAR DESDE AQUI
            //stopWatch.Restart();
            //SumatorioInterLocked sumatorioInter = new SumatorioInterLocked(valor, numHilos);
            //sumatorioInter.Calcular();
            //stopWatch.Stop();

            //MostrarLinea(Console.Out, numHilos, stopWatch.ElapsedTicks, sumatorioInter.Valor);

            //Console.WriteLine("Valor tras realizar la operación con InterLocked : {0}.", sumatorioInter.Valor);
            //HASTA AQUI

            /*
             * RESULTADO
             * Valor esperado como resultado: 0.
             * Num Hilos;Ticks;Resultado
             * 10;23.200.774;0,00
             * Valor tras realizar la operación directamente : 0.
             * 
             */


            //EJERCICIO: Implementar una versión con lock (usando object)
            //     Toma tiempos de la versión de lock y de la de Interlock, imprímelos por pantalla.
            //     Cómo realizar tomas de tiempo lo tenéis en la práctica(y entrega) anterior.

            //EJERCICIO: Crear y entender un ejemplo para cada método:
            //Increment, Add, Exchange y CompareExchange.

            /*
             * PARA TOMAR TIEMPOS
             * 
             * 1. Primero medir tiempos de uno y después tiempos de otro
             * 2. Ejecutar en modo Release
             */
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
