using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EjercicioProductorConsumidor
{
    class Consumidor
    {

        private Queue<Producto> cola;
        private readonly object _obj = new object();

        public Consumidor(Queue<Producto> cola)
        {
            this.cola = cola;
        }

        public void Run()
        {
            Random random = new Random();
            while (true)
            {
                Console.WriteLine("- Sacando producto...");
                Producto producto = null;
                //lock (cola)
                lock (_obj)
                {
                    while (cola.Count == 0)
                        Thread.Sleep(100);

                    producto = cola.Dequeue();
                }
                Console.WriteLine("- Producto sacado: {0}.", producto);
                Thread.Sleep(random.Next(300, 700));
            }
        }

    }
}
