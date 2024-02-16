using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Estancia : Evento
    {
        public uint NumParticipantes { get; set; }

        public bool IncluyeComida { get; set; }
    }
}
