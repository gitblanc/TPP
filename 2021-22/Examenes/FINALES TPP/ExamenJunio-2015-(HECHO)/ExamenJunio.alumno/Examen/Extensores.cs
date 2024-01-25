using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.FinalJunio
{
    public static class Extensores
    {
        public static IEnumerable<Persona> EvitarRepetidos(this IEnumerable<Persona> personas)
        {
            IList<Persona> res = new List<Persona>();
            bool repetido = false;
            foreach (var p in personas)
            {
				repetido = false;
                foreach (var item2 in res){
                    if (item2.Nombre == p.Nombre)
                    {
                        repetido = true;
                        break;
                    }
				}
				
                if (!repetido)
                    res.Add(p);
            }

            return res;
        }

    }
}
