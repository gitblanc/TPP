using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Julio2013
{
     static class Extensores
    {
        public static void AddPermisos(this IEnumerable<Aplicacion> aplicaciones, Action<Aplicacion> f)
        {
            foreach (Aplicacion app in aplicaciones)
            {
                f(app);
            }
        }

        //Ejercicio 3------------------------------------
        public static IEnumerable<Aplicacion> ProcesadorAplicaciones(this IEnumerable<Aplicacion> aplicaciones,
        Func<Aplicacion, bool> f, Action<Aplicacion> f2 = null)
        {
            foreach (Aplicacion a in aplicaciones)
            {
                if (f(a))
                {
                    if (f2 != null)
                        f2(a);
                }
            }
            return aplicaciones;
        }
    }
}
