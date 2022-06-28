using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practica9
{
    internal class Worker
    {
        private short[] vector;
        private int from;
        private int to;

        private long result;

        internal long Result
        {
            get { return result; }
        }

        public Worker(short[] vector, int fromIndex, int toIndex)
        {
            this.vector = vector;
            this.from = fromIndex;
            this.to = toIndex;
        }

        internal void Compute()
        {
            this.result = 0;
            for (int i = from; i <= to; i++)
            {
                this.result += this.vector[i] * this.vector[i];
            }
        }
    }
}
