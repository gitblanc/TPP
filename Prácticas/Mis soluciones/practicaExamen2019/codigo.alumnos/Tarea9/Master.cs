using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practica9
{
    internal class Master
    {
        private short[] vector;
        private int numberofThreads;

        public Master(short[] vector, int numberofThreads)
        {
            this.vector = vector;
            this.numberofThreads = numberofThreads;
        }

        internal double ComputeModulus()
        {
            Worker[] workers = new Worker[this.numberofThreads];
            int itemsPerThread = this.vector.Length / this.numberofThreads;
            for (int i = 0; i < numberofThreads; i++)
            {
                workers[i] = new Worker(this.vector,
                    i * itemsPerThread,
                    (i < itemsPerThread - 1 ? (i + 1) * itemsPerThread - 1 : this.vector.Length - 1));
            }
            Thread[] threads = new Thread[workers.Length];
            for (int i = 0; i < workers.Length; i++)
            {
                threads[i] = new Thread(workers[i].Compute);
                threads[i].Name = $"Worker Vector Modulus {i + 1}";
                threads[i].Priority = ThreadPriority.BelowNormal;
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            long result = 0;
            foreach (var worker in workers)
            {
                result += worker.Result;
            }
            return Math.Sqrt(result);
        }
    }
}
