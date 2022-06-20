using System;
using System.Threading;


namespace ConsoleApp1
{
    /// <summary>
    /// Calcula el módulo de un vector de manera concurrente.
    /// ///Raiz_Cuadrada(x1^2 + x2^2 + x3^2 + ... + xn^2);
    /// Genera y cordena un conjunto de hilos trabajadores (Workers)
    /// que realizarán el cálculo.
    /// 
    /// </summary>
    public class Master
    {
        /// <summary>
        /// Vector del que se obtendrá el módulo
        /// </summary>
        private string[] vector;
        private ColaConcurrente<String> cola;
        /// <summary>
        /// Número de trabajadores que se van a emplear en el cálculo.
        /// </summary>
        private int numeroHilos;


        public Master(string[] vector, int numeroHilos)
        {
            if (numeroHilos < 1 || numeroHilos > vector.Length)
                throw new ArgumentException("El número de hilos debe ser menor o igual al tamaño del vector");
            this.vector = vector;
            this.numeroHilos = numeroHilos;
        }

        /// <summary>
        /// Este método crea y coordina el cálculo
        /// </summary>
        public ColaConcurrente<string> CalcularModulo()
        {
           ColaConcurrente<string> colaC = new ColaConcurrente<string>();
            // Creamos los workers
            Worker[] workers = new Worker[this.numeroHilos];
            int numElementosPorHilo = this.vector.Length / numeroHilos;
            for (int i = 0; i < this.numeroHilos; i++)
            { 
                int indiceDesde = i * numElementosPorHilo;
                int indiceHasta = (i + 1) * numElementosPorHilo - 1;
                if (i == this.numeroHilos - 1) //el último hilo, llega hasta el final del vector.
                {
                    indiceHasta = this.vector.Length - 1;
                }
                workers[i] = new Worker(this.vector, indiceDesde, indiceHasta, ref colaC);
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
            //Esperamos a que acaben
            foreach (Thread thread in hilos)
                thread.Join();

            //Por último, sumamos todos los resultados parciales
            //y devolvemos la raiz cuadrada.
            //ColaConcurrente<string> resultado = new ColaConcurrente<string>();
            foreach (Worker worker in workers)
                colaC = worker.Resultado;

            return colaC;
        }

    }
}
