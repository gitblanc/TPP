using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP.Examen.PL5.Restaurante
{
    public class Cocinero
    {
        protected Cocina lugarDeTrabajo;
        protected IDictionary<string, IEnumerable<string>> recetario;
        protected IDictionary<Ingrediente, int> almacenIngredientes;
        public Cocinero(Cocina c)
        {
            //El cocinero trabaja en una cocina
            this.lugarDeTrabajo = c;
            //Utiliza las recetas definidas en esa cocina
            this.recetario = c.Recetas;
            //Tomará los ingredientes de la despensa de esa cocina
            this.almacenIngredientes = c.Despensa;
        }

        internal virtual Pizza PrepararReceta(string pedido)
        {
            //Busca en las recetas
            var receta = this.recetario[pedido];
            var ingredientes = new Ingrediente[receta.Count()];
            for (int i = 0; i < receta.Count(); i++)
            {
                string nombreIngrediente = receta.ElementAt(i);
                var ing = Modelo.GetIngredientes().Where(ingr => ingr.Nombre.Equals(nombreIngrediente)).FirstOrDefault();
                if (ing == null)
                    throw new ArgumentException(String.Format("El ingrediente {0} no se ha encontrado", nombreIngrediente));

                this.almacenIngredientes[ing] -= 1; //Disminuimos la cantidad de ingredientes en el almacen
                ingredientes[i] = ing;
                System.Threading.Thread.Sleep(100); //Simulamos el trabajo de añadir un ingrediente
            }
            //Devuelve una pizza preparada
            return new Pizza(pedido, ingredientes);
        }
    }
}
