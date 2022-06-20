using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP.Examen.PL5.Restaurante
{
    public class CocinaMultihilo : Cocina
    {
        IDictionary<Ingrediente, int> Cocina.Despensa { get { throw new NotImplementedException(); } }
        IDictionary<string, IEnumerable<string>> Cocina.Recetas { get { throw new NotImplementedException(); } }


        public CocinaMultihilo(int nCocineros)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pizza> AtenderPedidos(IEnumerable<string> pedidos)
        {
            throw new NotImplementedException();
        }
    }
}
