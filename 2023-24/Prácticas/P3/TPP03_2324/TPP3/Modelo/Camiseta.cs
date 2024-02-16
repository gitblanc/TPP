using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Camiseta : Producto, IFacturable
    {
        public string Talla { get; set; }

        public string Color { get; set; }

        public double GetBase()
        {
            if (Color == "rojo")
                return 5.00;
            else if (Color == "verde")
                return 7.00;
            else
                return 10.00;
        }

        public string GetConcepto()
        {
            return $"Camiseta de color {Color} y talla {Talla} con Precio Base: {GetBase()}";
        }

        public double GetIva()
        {
            return 0.21 * GetBase();
        }

        public double GetPrecio()
        {
            return GetBase() + GetIva();
        }

        public double GetTipoIva()
        {
            return 0.21;
        }

        public string ToTicket()
        {
            return $"Concepto: {GetConcepto()}, Iva: {GetTipoIva()}, " +
                $"Total del Iva: {GetIva()}" +
                $"Precio con Iva: {GetPrecio()}, ";
        }
    }
}
