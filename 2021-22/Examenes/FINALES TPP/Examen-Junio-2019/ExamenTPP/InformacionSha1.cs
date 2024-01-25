using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamUtils;
namespace ConsoleApp1
{
    class InformacionSha1
    {
        //Clase Informacion correspondiente al ejercicio 1 para usuarios cuya clave se hashea con MD5
	private String usuario;
	private String clave;
	
        public string Usuario //Clase usuario de tipo string
        {
            get
            {
                return usuario;
            }

            set
            {
                if (usuario != null && usuario.Length >= 3 && usuario.Length <= 15 )
                {
                  
                    this.usuario = usuario;
                }
            }
        }

        public string Clave
        {
            private get { return clave; }

            set
            {
                this.clave = Utils.CreateSha1(clave);
            }
        }

        public InformacionSha1(string usuario, string clave)
        {
            this.usuario = usuario;
            this.clave = clave;
        }

        public bool Validate(string usuarioParam, string claveParam)
        {
            if (usuarioParam.Equals(usuario) && claveParam.Equals(clave))
            {
                return true;
            }

            return false;
        }

        public bool Validate(string usuarioParam)
        {
            if(usuarioParam.Equals(usuarioParam))
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return this.usuario;
        }

    }
}
