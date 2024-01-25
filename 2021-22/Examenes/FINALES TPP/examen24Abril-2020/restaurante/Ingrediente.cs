using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP.Examen.PL5.Restaurante
{
    public class Ingrediente
    {
        private string nombre = "";
        public string Nombre { get { return this.nombre; } }

        public Ingrediente(string nombre)
        {
            this.nombre = nombre;
        }

        public override bool Equals(object obj)
        {
            if (obj is Ingrediente)
                return this.nombre.Equals(((Ingrediente)obj).Nombre);
            else
                return false;
        }
        public override int GetHashCode()
        {
            return this.nombre.GetHashCode();
        }
    }
}
