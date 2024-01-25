using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP.Examen.PL5.Restaurante
{
    public class CocinaMonohilo : Cocina
    {
        //Atributos espécificos
        private Cocinero chef;
        private Horno horno;

        //Atributos Comunes
        private IDictionary<Ingrediente, int> despensa;
        IDictionary<Ingrediente, int> Cocina.Despensa { get { return this.despensa; } }
        private IDictionary<string, IEnumerable<string>> libroRecetas;
        IDictionary<string, IEnumerable<string>> Cocina.Recetas { get { return this.libroRecetas; } }

        public CocinaMonohilo()
        {
            this.despensa = new Dictionary<Ingrediente, int>();
            foreach (var i in Modelo.GetIngredientes())
                despensa[i] = 100;
            this.libroRecetas = Modelo.GetMenu();

            this.horno = new Horno();
            this.chef = new Cocinero(this);
        }

        IEnumerable<Pizza> Cocina.AtenderPedidos(IEnumerable<string> pedidos)
        {
            IList<Pizza> resultado = new List<Pizza>();
            foreach(var pedido in pedidos)
            {
                var platoPreparado = this.chef.PrepararReceta(pedido);
                resultado.Add(this.horno.Hornear(platoPreparado));
            }
            return resultado;
        }
    }
}
