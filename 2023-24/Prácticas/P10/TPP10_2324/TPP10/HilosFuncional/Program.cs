using System;

using System.Threading;
using HilosPOO;

namespace HilosFuncional
{
    class Program
    {
        static void Main(string[] args)
        {

            // En el ejemplo HilosPOO, el método Run de cada Expositor no recibía parámetros.
            // De hecho, utilizábamos el propio objeto Expositor para encapsular los datos (valor y nVeces).
            // El/Los parámetro/s lo encapsulábamos como atributo/s de una clase.

            // A continuación veremos los casos desde un enfoque más funcional.

            //Thread recibe en su constructor cualquier Action con 0 o 1 parámetros de tipo object.

            Thread hiloParametrizado = new Thread(ObtenerDatos);//ObtenerDatos es un Action
            //Los hilos pueden recibir un Action con 0 o 1 parámetros que han de ser de tipo object SÍ O SÍ

            //En el método Start pasamos un argumento (si es necesario).
            hiloParametrizado.Start("wwww.google.es");//Aquí se le pasa el parámetro


            //También podríamos utilizar directamente una expresión lambda:
            Thread hiloSuelto = new Thread(//ESTO NO SE PUEDE HACER, PUES NO ES FUNCIONAL PURO (VALOR ES UN OBJETO)
                     valor =>
                     {
                         Console.WriteLine("El hilo suelto recibe " + valor);
                     }
             );
            hiloSuelto.Start("Declarando el action directamente");


            //¿Y si necesitamos más parámetros? 

            //¿Qué concepto se está aplicando aquí?

            //Vamos a crear 4 hilos.
            //Cada hilo debería imprimir un par de valores: 40 y 41, 41 y 42, 42 y 43, 43 y 44... En cualquier orden.

            //EJERCICIO: ¿Cómo arreglamos esto?

            Thread[] hilos = new Thread[4];
            int numero = 40;
            //for (int i = 0; i < 4; i++)
            //{
            //    //Sin parámetro                
            //    hilos[i] = new Thread(
            //        () =>
            //            {
            //                Console.WriteLine($"{numero} {numero + 1}");
            //            }
            //        );
            //    hilos[i].Start();
            //    numero++;
            //}

            //SOLUCION
            for (int i = 0; i < 4; i++)
            {
                var copia = numero;//En cada iteración se crea una iteración distinta
                //Sin parámetro                
                hilos[i] = new Thread(
                    () =>
                    {
                        Console.WriteLine($"{copia} {copia + 1}");//aquí se guarda una referencia a número. Los 4 hilos guardan lamisma referencia a número                        
                    }
                    );
                hilos[i].Start();
                numero++;
            }

            //EJERCICIO: Empleando un enfoque funcional, impleméntese la funcionalidad del ejercicio Expositor de HilosPOO.
            var objeto = 0;

            for (int i = 0; i < 4; i++)
            {
                var copia = objeto;//En cada iteración se crea una iteración distinta
                //Sin parámetro                
                hilos[i] = new Thread(
                    () =>
                    {
                        int i = 0;
                        //¿Qué indica Thread.CurrentThread.ManagedThreadId?
                        // Para saber la id del hilo
                        Console.WriteLine("Comienza el hilo ID={0} que escribirá {1} veces cada 2000ms. (mínimo)", Thread.CurrentThread.ManagedThreadId, 4);

                        while (i < 4)
                        {
                            //Dormimos el proceso durante 2000 milisegundos
                            //¿Para qué es útil? ¿Y para qué no debe utilizarse?
                            Thread.Sleep(2000);//nunca usar el sleep para hacer una tarea cíclica, sino para hacer demostraciones y testing
                            Console.WriteLine("Ejecución {0} del hilo [ID={1}; NOMBRE={2}; PRIORIDAD={3}] con valor {4}",
                                i, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name, Thread.CurrentThread.Priority, copia);
                            i++;
                        }
                        Console.WriteLine($"Fin del hilo ID = {Thread.CurrentThread.ManagedThreadId}.");
                    });
                hilos[i].Start();
                objeto++;
            }

            //Expositor<int>[] expositores = new Expositor<int>[4];
            //for (int i = 0; i < expositores.Length; i++)
            //{
            //    int nVeces = 1 + i;
            //    int valor = i;
            //    expositores[i] = new Expositor<int>(valor, nVeces);
            //    valor++;
            //}

            //for (int i = 0; i < 4; i++)
            //{
            //    //¿Qué estamos enviando en el construtor de cada Thread?
            //    hilos[i] = new Thread(expositores[i].Run);//Los hilos en el constructor, reciben un Action. NO DEVUELVEN NADA

            //    //Parámetros opcionales.
            //    hilos[i].Name = "Hilo número: " + i; //Nombre del hilo.
            //    hilos[i].Priority = ThreadPriority.Normal; //Prioridad
            //}



        }

        public static void ObtenerDatos(object valor)
        {
            Console.WriteLine("Obteniendo datos del destino {0}", valor);
            //Simulamos carga de trabajo, fines demostrativos.
            Thread.Sleep(2000);
            Console.WriteLine("Datos obtenidos y almacenados");

        }
    }
}
