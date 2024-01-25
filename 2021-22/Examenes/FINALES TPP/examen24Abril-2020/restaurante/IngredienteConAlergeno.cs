using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP.Examen.PL5.Restaurante
{
    public class IngredienteConAlergeno : Ingrediente
    {
        private string alergeno = "";
        public string Alergeno { get { return this.alergeno; } }

        public IngredienteConAlergeno(string nombre, string alergeno) : base(nombre)
        {
            this.alergeno = alergeno;
        }
    }
}
