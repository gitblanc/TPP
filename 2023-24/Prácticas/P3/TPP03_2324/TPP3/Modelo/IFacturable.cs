using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public interface IFacturable
    {
        double GetBase();
        double GetTipoIva();

        double GetIva();

        double GetPrecio();

        string GetConcepto();

        string ToTicket();
    }
}
