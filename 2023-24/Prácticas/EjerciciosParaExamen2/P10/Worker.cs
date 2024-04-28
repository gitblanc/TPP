using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P10
{
    //Worker es internal
    internal class Worker
    {
        private BitcoinValueData[] _vector;

        private int _indiceDesde, _indiceHasta;
        private double _maxValue;

        private double _resultado;

        internal double Resultado { get { return this._resultado; } }

        internal Worker(BitcoinValueData[] vector, int indiceDesde, int indiceHasta, double maxValue)
        {
            this._vector = vector;
            this._indiceDesde = indiceDesde;
            this._indiceHasta = indiceHasta;
            this._maxValue = maxValue;
        }

        internal void Calcular()
        {
            this._resultado = 0;
            for (int i = this._indiceDesde; i <= this._indiceHasta; i++)
            {
                if (this._vector[i].Value > this._maxValue)
                    this._resultado += 1;
            }
        }
    }
}
