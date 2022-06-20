using System;
using System.Collections.Generic;
using System.Threading;

namespace Junio2019
{

    public class Master {

        private string[] claves;

        private IDictionary<int, InformacionSha1> result = null;

        private InformacionSha1[] usuarios;

        private int numberOfThreads;

        public Master(string[] claves, InformacionSha1[] usuarios) {
            this.claves = claves;
            this.usuarios = usuarios;
            this.numberOfThreads = usuarios.Length;
            result = new Dictionary<int, InformacionSha1>();
        }

        public IDictionary<int, InformacionSha1> ComputeModulus() {
            Worker[] workers = new Worker[this.numberOfThreads];
            int itemsPerThread = this.claves.Length/numberOfThreads;
            for (int i = 0; i < this.numberOfThreads; i++)
            {
                workers[i] = new Worker(this.claves,
                    i * itemsPerThread,
                    (i < this.numberOfThreads - 1) ? (i + 1) * itemsPerThread - 1 : this.claves.Length - 1, usuarios[i], ref result);
            }
            Thread[] threads = new Thread[workers.Length];
            for(int i=0;i<workers.Length;i++) {
                threads[i] = new Thread(workers[i].Compute); 
                threads[i].Name = "Worker Vector Modulus " + (i+1); 
                threads[i].Priority = ThreadPriority.BelowNormal; 
                threads[i].Start();  
            }
            foreach(Thread t in threads)
            {
                t.Join();
            }
            return result;
        }

       

    }

}
