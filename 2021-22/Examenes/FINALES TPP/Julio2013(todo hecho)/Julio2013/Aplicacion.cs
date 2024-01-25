using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntregableExamenTPP
{
    class Aplicacion
    {
        public string[] Permisos { get; private set; }

        public string Nombre { get; private set; }

        public int MB { get; private set; }

        private int contPermisos = 0;

        private int numeroDeRevisiones;

        public int GetNumeroDeRevisiones()
        {
            return numeroDeRevisiones;
        }

        public void IncrementarNumeroDeRevisiones()
        {
            numeroDeRevisiones++;
        }
        public Aplicacion(string nombre, int mb)
        {
            Nombre = nombre;
            MB = mb;
            Permisos = new string[10];
        }

        public void AddPermiso(string perm)
        {
            if (contPermisos >= Permisos.Length)
                throw new InvalidOperationException("No se permite añadir más permisos a esta aplicación");
            Permisos[contPermisos] = perm;
            contPermisos = contPermisos + 1;
        }

        private string listPermisos()
        {
            string result = "|";

            foreach (string p in Permisos)
                if (p != null)
                    result += p + "|";
                else result += "<vacio> |";

            return result;
        }
        public override string ToString()
        {
            return this.Nombre + "(" + this.MB + " MB) [" + listPermisos() + "] (revisada " + GetNumeroDeRevisiones() + " veces)";
        }
    }
}
