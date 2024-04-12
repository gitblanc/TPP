﻿using System;
using System.ComponentModel;
using System.Threading;

namespace ObligatoriaSesion10
{
    internal class Master
    {
        private BitcoinValueData[] _data;
        private int _numeroHilos;
        private long _valor;

        public Master(BitcoinValueData[] data, int numeroHilos, long valorPrefijado)
        {
            this._data = data;
            this._numeroHilos = numeroHilos;
            this._valor = valorPrefijado;
        }

        public long ContarVeces()
        {
            Worker[] workers = new Worker[this._numeroHilos];
            int numElementosPorHilo = this._data.Length / _numeroHilos;

            for (int i = 0; i < this._numeroHilos; i++)
            {
                int indiceDesde = i * numElementosPorHilo;
                int indiceHasta = (i + 1) * numElementosPorHilo - 1;
                if (i == this._numeroHilos - 1) //el último hilo, llega hasta el final del vector.
                {
                    indiceHasta = this._data.Length - 1;
                }
                workers[i] = new Worker(this._data, indiceDesde, indiceHasta, _valor);
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

            foreach (Thread thread in hilos)
            {
                thread.Join();
            }

            // Por último, sumamos todos los resultados de los trabajadores.
            //y devolvemos la raiz cuadrada.
            long resultado = 0;
            foreach (Worker worker in workers)
                resultado += worker.Resultado;
            return resultado;
        }
    }
}