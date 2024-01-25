using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junio2019
{
    class UsuariosMD5
    {
        IEnumerable<InformacionMD5> usuariosMD5;

        public UsuariosMD5(IEnumerable<InformacionMD5> usuarios)
        {
            this.usuariosMD5 = usuarios;
        }

        
    }
}
