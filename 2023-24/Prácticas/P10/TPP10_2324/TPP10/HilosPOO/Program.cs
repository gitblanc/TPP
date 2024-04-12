using System;

// ¡OJO!
using System.Threading;

namespace HilosPOO
{
    class Program
    {
        static void Main()
        {
            HilosPOOEstado();
        }

        static void HilosPOOEstado()
        {
            int tamaño = 4;
            //Creamos en un array 4 objetos Expositor
            Expositor<int>[] expositores = new Expositor<int>[tamaño];



            //A cada expositor le asignamos un propio valor: 0, 1,2,3.

            for (int i = 0; i < expositores.Length; i++)
            {
                int nVeces = 1 + i;
                int valor = i;
                expositores[i] = new Expositor<int>(valor, nVeces);
                valor++;
            }

            //Ahora vamos crear un array de hilos (Thread)

            //Cada hilo, deberá ejecutar el método Run de un objeto Expositor.

            Thread[] hilos = new Thread[tamaño];

            for (int i = 0; i < tamaño; i++)
            {
                //¿Qué estamos enviando en el construtor de cada Thread?
                hilos[i] = new Thread(expositores[i].Run);//Los hilos en el constructor, reciben un Action. NO DEVUELVEN NADA

                //Parámetros opcionales.
                hilos[i].Name = "Hilo número: " + i; //Nombre del hilo.
                hilos[i].Priority = ThreadPriority.Normal; //Prioridad
            }


            //Hasta este punto, tenemos los hilos definidos y lo que tienen que hacer.
            //Los tenemos que arrancar:

            foreach (Thread hilo in hilos)
            {
                //Iniciamos el hilo con el método Start de la clase Thread.
                hilo.Start();//Lanzamos el hilo
                //hilo.Join();//Así es secuencial. SUSPENSO INSTANTÁNEO
            }

            //Para solucionar la condición de carrera:
            foreach (var hilo in hilos)
            {
                hilo.Join();//Con esto, el hilo principal espera a que acaben el resto de hilos
            }

            //¿Qué está pasando con esta línea?
            Console.WriteLine("Fin del cálculo.");//Como es el hilo principal, éste sigue con su ejecución

            //EJERCICIO: Modifique el código para que la sentencia anterior aparezca una vez todos los hilos hayan completado su tarea.
        }

    }
}
