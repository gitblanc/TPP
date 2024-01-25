using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junio2015
{
    static class Extensores
    {
        public static IEnumerable<Persona> EvitarRepetidos(this IEnumerable<Persona> personas)
        {
            IList < Persona > resultado = new List<Persona>();
            bool repetido = false;
            foreach(Persona p in personas)
            {
                repetido = false;
                foreach(Persona per in resultado)
                {
                    if(p.Nombre == per.Nombre)
                    {
                        repetido = true;
                        break;
                    }
                }

                if (!repetido)
                {
                    resultado.Add(p);
                }
            }
            return resultado;
        }
    }
}
