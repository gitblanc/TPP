using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public abstract class Producto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        private uint _stock;
        public uint Stock
        {
            get { return _stock; }
        }

        public bool Disponibilidad { get; set; }


        public virtual void Reponer(uint n)
        {
            _stock += n;
        }

        public virtual void Comprar(uint n)
        {
            _stock -= n;
        }
    }
}
