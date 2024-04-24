using System.Threading;

namespace _03Interlocked
{
    public class Sumatorio
    {
        private readonly object _object = new object();//no hace falta poner static porque sólo hay un objeto Sumatorio
        protected long valor;
        private int numHilos;

        internal Sumatorio(long valor, int numHilos)
        {
            this.valor = valor;
            this.numHilos = numHilos;
        }

        internal long Valor
        {
            get { return this.valor; }
        }

        protected virtual void DecrementarValor()
        {
            lock (_object)//Funciona pero estamos paralelizando 0 líneas
            {
                this.valor = this.valor - 1;// es el recurso compartido -> valor
            }
        }

        internal void Calcular()// Es un master/worker
        {
            //object _object = new object();//Se puede poner aquí para seguir un enfoque más funcional
            int iteraciones = (int)valor / numHilos; //Las necesarias para dejar el recuento a 0.
            Thread[] hilos = new Thread[numHilos];
            for (int i = 0; i < numHilos; i++)
                hilos[i] = new Thread(
                    () =>
                        {
                            for (int j = 0; j < iteraciones; j++)
                            {
                                //lock (_object)//Funciona pero estamos paralelizando 0 líneas
                                //{
                                this.DecrementarValor();
                                //}
                            }
                        }
                     );

            //Iniciamos hilos y hacemos Join
            foreach (Thread hilo in hilos)
                hilo.Start();
            foreach (Thread hilo in hilos)
                hilo.Join();
        }
    }
}
