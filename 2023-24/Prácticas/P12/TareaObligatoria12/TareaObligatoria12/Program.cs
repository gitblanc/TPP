using System;
using System.Diagnostics;
using ModeloClases;
using System.Threading.Tasks;

namespace TareaObligatoria12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String texto = ProcesadorTextos.LeerFicheroTexto(@"..\..\..\..\clarin.txt");
            string[] palabras = ProcesadorTextos.DividirEnPalabras(texto);

            Stopwatch sw = new();
            //string[] conteo = null;
            sw.Start();
            var conteo = ProcesadorTextos.ContarPalabras(palabras); //ESTO SERÍA SECUENCIAL
            //VERSION PARALELA
            //Parallel.Invoke(
            //    () => conteo = ProcesadorTextos.ContarPalabras(palabras)
            //    );
            sw.Stop();

            Console.WriteLine("Se han contado las palabras en {0} ms", sw.ElapsedMilliseconds);
            ProcesadorTextos.Mostrar(conteo, Console.Out, 50);
        }

        // PREGUNTAS

        /*
         * 
         * ¿Por qué cree que el beneficio de rendimiento no es muy elevado? ¿Qué se podría hacer para mejorarlo?
         * 
         * Creo que el beneficio no es muy elevado porque se está paralelizando la llamada a la tarea y no la tarea en sí
         * Yo creo que se podría usar el .AsParallel() en la consulta
         */
    }
}
