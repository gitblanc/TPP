using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Examen24Abril2020TPP
{
    class Master
    {
        private string[] vector;

        private int numeroHilos;
        private double tope = 0;

        private ColaConcurrente<string> cola;

        public Master(string[] vector, int numeroHilos)
        {
            if (numeroHilos < 1 || numeroHilos > vector.Length)
                throw new ArgumentException("Número de hilos erroneo");
            this.vector = vector;
            this.numeroHilos = numeroHilos;
            this.cola = new ColaConcurrente<string>();
        }

        public void Ejercicio4Cola()
        {
            Worker[] workers = new Worker[this.numeroHilos];
            int elementosPorHilo = this.vector.Length / numeroHilos;
            for (int i = 0; i < this.numeroHilos; i++)
                workers[i] = new Worker(this.vector, i * elementosPorHilo, (i < this.numeroHilos - 1) ?
                    (i + 1) * elementosPorHilo : this.vector.Length - 1, ref cola);

            Thread[] hilos = new Thread[workers.Length];
            for(int i = 0; i < hilos.Length; i++)
            {
                hilos[i] = new Thread(workers[i].Calcular);
                hilos[i].Name = "Worker vector modulo " + (i + 1);
                hilos[i].Priority = ThreadPriority.BelowNormal;
                hilos[i].Start();
            }

            for(int i = 0; i < hilos.Length; i++)
            {
                hilos[i].Join();
            }


            while (!cola.EstaVacia())
            {
                Console.WriteLine(cola.Extraer());
            }
            
        }

    }
}
