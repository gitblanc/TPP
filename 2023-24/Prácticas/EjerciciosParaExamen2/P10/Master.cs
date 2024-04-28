using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P10
{
    //Master es public
    public class Master
    {
        private BitcoinValueData[] _vector;
        private int _numeroHilos;
        private double _maxValue;

        public Master(BitcoinValueData[] vector, int numHilos, double maxValue)
        {
            if (numHilos < 1 || numHilos > vector.Length)
                throw new ArgumentException("El número de hilos debe ser menor o igual al tamaño del vector");
            this._vector = vector;
            this._numeroHilos = numHilos;
            this._maxValue = maxValue;
        }

        public double CalcularResultado()
        {
            // Creamos los workers
            Worker[] workers = new Worker[this._numeroHilos];
            int numElementosPorHilo = this._vector.Length / _numeroHilos;
            for (int i = 0; i < this._numeroHilos; i++)
            {
                int indiceDesde = i * numElementosPorHilo;
                int indiceHasta = (i + 1) * numElementosPorHilo - 1;
                if (i == this._numeroHilos - 1) //el último hilo, llega hasta el final del vector.
                {
                    indiceHasta = this._vector.Length - 1;
                }
                workers[i] = new Worker(this._vector, indiceDesde, indiceHasta, this._maxValue);
            }

            // * Iniciamos los hilos.
            Thread[] hilos = new Thread[workers.Length];
            for (int i = 0; i < workers.Length; i++)
            {
                hilos[i] = new Thread(workers[i].Calcular); // Creamos el hilo
                hilos[i].Name = "Worker número: " + (i + 1); // le damos un nombre (opcional)
                hilos[i].Priority = ThreadPriority.Normal; // prioridad (opcional)
                hilos[i].Start();   // arrancamos el hilo
            }

            //¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡OJO!!!!!!!!!!!!!!!!
            //Esperamos a que acaben para continuar.
            // Es fundamental entender cómo y cuándo usar el Join.
            foreach (Thread thread in hilos)
            {
                thread.Join();
            }

            //Por último, sumamos todos los resultados de los trabajadores y lo devolvemos
            double resultado = 0;
            foreach (Worker worker in workers)
                resultado += worker.Resultado;
            return resultado;
        }
    }
}
