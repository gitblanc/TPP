using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasterWorkerClase
{
    public class Master
    {
        private short[] _v1, _v2;
        private int _numeroHilos;


        public Master(short[] vector1, short[] vector2, int numeroHilos)
        {
            if (numeroHilos < 1 || numeroHilos > vector1.Length)
                throw new ArgumentException("El número de hilos debe ser menor o igual al tamaño de los vectores");
            this._v1 = vector1;
            this._v2 = vector2;
            this._numeroHilos = numeroHilos;
        }

        public long ContarRepeticiones()
        {
            //Creamos los workers
            Worker[] workers = new Worker[this._numeroHilos];
            int numElemsPorHilo = this._v1.Length / _numeroHilos;

            for (int i = 0; i < this._numeroHilos; i++)
            {
                int desde = i * numElemsPorHilo;
                int hasta = desde + numElemsPorHilo;
                if (i == this._numeroHilos - 1)//último hilo, fin del vector
                {
                    hasta = this._v1.Length;
                }
                workers[i] = new Worker(_v1, _v2, desde, hasta);
            }

            // Iniciamos los hilos.
            Thread[] hilos = new Thread[workers.Length];
            for (int i = 0; i < workers.Length; i++)
            {
                hilos[i] = new(workers[i].Calcular)
                {
                    Name = "Worker número: " + (i + 1), // le damos un nombre (opcional)
                    Priority = ThreadPriority.Normal // prioridad (opcional)
                }; // Creamos el hilo
                hilos[i].Start();   // arrancamos el hilo
            }

            //Esperamos a que acaben para continuar.
            foreach (Thread thread in hilos)
            {
                thread.Join();
            }

            //Por último, sumamos todos los resultados de los trabajadores.
            //y devolvemos el número de veces que se repite el vector v2 en v1.
            long resultado = 0;
            foreach (Worker worker in workers)
                resultado += worker.Resultado;
            return resultado;
        }
    }
}
