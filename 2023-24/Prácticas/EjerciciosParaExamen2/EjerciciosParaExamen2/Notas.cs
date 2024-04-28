using System;

namespace EjerciciosParaExamen2
{
    internal class Notas
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Notitas!");
            /*
             * ------------------------------------------------------P10------------------------------------------------------
             * concurrencia -> paralelismo simulado en un procesador
             * paralelismo -> el real (en varios procesadores)
             * 
             * Los hilos pueden recibir un Action con 0 o 1 parámetros que han de ser de tipo object SÍ O SÍ
             * 
             * ¿Qué indica Thread.CurrentThread.ManagedThreadId?
             *  - La id del hilo
             * 
             * nunca usar el sleep para hacer una tarea cíclica, sino para hacer demostraciones y testing
             * 
             * TOMAR LOS TIEMPOS EN MODO DEBUG ES UN 0
             * 
             * Al generar las graficas hay que explicar:
             *  - Fijarse en los valores que empiezan a estar por encima de ejecutar con un sólo hilo
             *  - Fijarse en el mejor valor de hilos
             * 
             * PARA HACER LAS GRAFICAS
             *  - Cambiar de Debug a Release
             *  - Compilar
             *  - Ejecutar
             *  - Carpeta /bin
             *  - Release
             *  - Abrir un cmd (y meterse en la carpeta correpondiente)
             *  - Escribir: MasterWorker.exe > datos.csv -> nombre programa y mandarlo a un .csv
             *  - Abrir el fichero e insertar un gráfico de dispersión
             *  - Guardarlo como un libro de excel
             *  ---------------------------------------------------------------------------------------------------------------
             */
        }
    }
}
