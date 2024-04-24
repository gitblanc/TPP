using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioMasterWorker
{
    internal class Worker
    {
        private BitcoinValueData[] _data;
        private int _indiceDesde, _indiceHasta;
        //private long _resultado = 0;
        private long _valor;
        private List<double> _lista;
        private readonly object _object = new object(); // no lleva el static porque la lista es un recurso compartido

        //public long Resultado { get { return this._resultado; } }

        public Worker(BitcoinValueData[] data, int indiceDesde, int indiceHasta, long valorPrefijado, List<double> lista)
        {
            this._data = data;
            this._indiceDesde = indiceDesde;
            this._indiceHasta = indiceHasta;
            this._valor = valorPrefijado;
            this._lista = lista;
        }

        internal void Calcular()
        {
            for (int i = this._indiceDesde; i <= this._indiceHasta; i++)
            {
                if (_data[i].Value > _valor)// número de veces que está por encima del valor predefinido
                                            //_resultado += 1;
                {
                    lock (_object)
                    {
                        if (_lista.Contains(_data[i].Value))
                            _lista.Add(_data[i].Value);
                    }
                }
            }
        }
    }
}
