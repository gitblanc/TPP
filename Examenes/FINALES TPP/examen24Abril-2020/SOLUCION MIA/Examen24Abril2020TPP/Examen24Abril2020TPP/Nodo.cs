using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen24Abril2020TPP
{
     class Nodo<T>
    {
         public Nodo<T> siguiente;

       public Nodo<T> Siguiente
        {
            get
            {
                return siguiente;
            }
            set
            {
                siguiente = value;
            }
        }

        public  T Info { get; set; }

    }
}
