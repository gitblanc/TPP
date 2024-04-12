using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasterWorkerClase
{
    internal class Worker
    {
        private short[] _v1, _v2;//los dos vectores
        private long _resultado = 0;//resultado -> si son iguales será 1, sino 0
        private int _desde, _hasta;

        internal long Resultado
        {
            get { return this._resultado; }
        }

        internal Worker(short[] vector1, short[] vector2, int desde, int hasta)
        {
            this._v1 = vector1;
            this._v2 = vector2;
            this._desde = desde;
            this._hasta = hasta;
        }

        internal void Calcular()
        {
            for (int i = _desde; i <= _hasta - _v2.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < _v2.Length; j++)
                {
                    if (_v1[i + j] != _v2[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match) this._resultado += 1;
            }
        }
    }
}
