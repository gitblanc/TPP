using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP.Examen.PL5.Restaurante
{
    public class Pizza
    {
        internal string nombre;
        public string Nombre { get { return this.nombre; } }

        internal IEnumerable<Ingrediente> ingredientes;
        public IEnumerable<Ingrediente> Ingredientes { get { return this.ingredientes; } }

        private bool cocinado;
        public bool Cocinado { get { return this.cocinado; } }

        //Ejemplo: "margarita", { "masa fina", "salsa de tomate", "mozzarella"}
        public Pizza(string nombre, IEnumerable<Ingrediente> ingredientes)
        {
            this.cocinado = false;
            this.nombre = nombre;
            this.ingredientes = ingredientes;
        }

        public void Horneado()
        {
            //Simula procesamiento
            System.Threading.Thread.Sleep(50);
            this.cocinado = true;
        }
    }
}
