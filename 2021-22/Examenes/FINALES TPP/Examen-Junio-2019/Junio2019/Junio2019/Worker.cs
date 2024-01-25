
using System.Collections.Generic;

namespace Junio2019
{

    internal class Worker
    {

        private string[] claves;

        private int fromIndex, toIndex;

        private InformacionSha1 usuario = null;
        private IDictionary<int, InformacionSha1> result;


        internal IDictionary<int, InformacionSha1> Result
        {
            get { return this.result; }
        }

        internal Worker(string[] claves, int fromIndex, int toIndex, InformacionSha1 usuario, ref IDictionary<int, InformacionSha1> res)
        {
            this.claves = claves;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
            this.usuario = usuario;
            this.result = res;
        }

        internal void Compute()
        {
            object ob = new object();
            lock (ob)
            {
                for(int i = fromIndex; i < toIndex; i++)
                {
                    if (claves[i].Equals(usuario.Clave))
                    {
                        result.Add(i, usuario);
                        break;
                       }
                }
            }
        }

    }
}
