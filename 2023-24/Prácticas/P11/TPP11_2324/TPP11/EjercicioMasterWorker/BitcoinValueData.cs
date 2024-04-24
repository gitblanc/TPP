using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioMasterWorker
{
    public class BitcoinValueData
    {
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }

        public override string ToString()
        {
            return Timestamp + ": " + Value;
        }
    }
}
