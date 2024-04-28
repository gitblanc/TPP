using System;

namespace EjerciciosParaExamen2
{
    internal class Notas
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Notitas!");
            /* NOTAS DE LOS LABORATORIOS
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
             *  
             *  ------------------------------------------------------P11------------------------------------------------------
             * ¿Por qué es readonly? ¿Por qué es estático? ¿Siempre será estático?
             *      - Es readonly porque si un lock tiene una referencia y se modifica, el lock peta
             *      - Es estático porque será el mismo objeto al que se acceda (para evitar personalización)
             *      - No siempre será estático
             *      
             *      private static readonly object _object = new object();
             *      
             * Como regla básica, es necesario bloquear cualquier operación de escritura.
             * Incluyendo los casos más simples, como el de modificar/incrementar el valor de una variable.
             * 
             * ¿Qué hace lock?
             *      Pilla la referencia a un objeto y le pone una señal
             *      Cuando llega al lock para y el hilo se libera cuando termina el código de dentro del lock
             *      
             * El Interbloqueo (o deadlock) se produce cuando varias tareas (procesos o hilos)
             * están esperando a un evento que sólo otra puede iniciar, por tanto
             * todas las tareas se bloquean de forma permanente.
             * En este caso, si de forma concurrente se hace una transferencia de A a B y de B a A,
             * estaremos en un caso de interbloqueo.
             * deadlock = ESPERA INDEFINIDA
             *  ---------------------------------------------------------------------------------------------------------------
             */
        }
    }
}
