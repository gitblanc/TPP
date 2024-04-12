using System;

namespace ObligatoriaSesion10
{
    internal class Worker
    {
        private BitcoinValueData[] _data;
        private int _indiceDesde, _indiceHasta;
        private long _resultado = 0;
        private long _valor;

        public long Resultado { get { return this._resultado; } }

        public Worker(BitcoinValueData[] data, int indiceDesde, int indiceHasta, long valorPrefijado)
        {
            this._data = data;
            this._indiceDesde = indiceDesde;
            this._indiceHasta = indiceHasta;
            this._valor = valorPrefijado;
        }

        internal void Calcular()
        {
            for (int i = this._indiceDesde; i <= this._indiceHasta; i++)
            {
                if (_data[i].Value > _valor)// número de veces que está por encima del valor predefinido
                    _resultado += 1;
            }
        }
    }
}