using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntregableExamenTPP
{
    class DatosApp
    {
        public int Numero { get; set; }
        public List<string> Permisos { get; private set; }

        public DatosApp()
        {
            Permisos = new List<string>();
            Numero = 0;
        }

        public static DatosApp randomDatosAppFactory(int numero, string [] permisos)
        {
            DatosApp a = new DatosApp();
            a.Numero = numero;
            a.Permisos.Add(permisos[numero % permisos.Length]);
            a.Permisos.Add(permisos[((numero * 2) + 1) % permisos.Length]);
            return a;
        }
    }
}
