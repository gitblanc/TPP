using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public abstract class Evento
    {
        public string Nombre { get; set; }
        public string Descripción { get; set; }

        private DateTime _inicio;
        public DateTime FechaInicio { get { return _inicio; } }

        public DateTime FechaFin { get; set; }
    }
}
