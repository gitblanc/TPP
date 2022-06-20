using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class UsuariosSha1
    {
        IEnumerable<InformacionSha1> usuariosSha1;

        public UsuariosSha1(IEnumerable<InformacionSha1> usuarios)
        {
            this.usuariosSha1 = usuarios;
        }
    }
}
