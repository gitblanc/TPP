using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP.Examen.PL5.Restaurante
{
    public interface Cocina 
    {
        IDictionary<Ingrediente, int> Despensa { get; }
        IDictionary<string, IEnumerable<string>> Recetas { get; }

        IEnumerable<Pizza> AtenderPedidos(IEnumerable<string> pedido);

    }
}
