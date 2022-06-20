using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TPP.Examen.PL5.Restaurante
{
    internal class Horno
    {

        public Pizza Hornear(Pizza sinCocinar)
        {
            Console.WriteLine(String.Format("Se está horneando una {0}", sinCocinar.Nombre));
            //Simula el tiempo de cocinado
            sinCocinar.Horneado();
            return sinCocinar;
        }
    }
}
