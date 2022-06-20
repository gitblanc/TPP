using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Calcula la suma de los cuadrados de parte de los valores de un vector
    /// Computes the addition of the square values of part of a vector
    /// </summary>
    internal class Worker
    {

        /// <summary>
        /// Vector del que vamos a obtener el módulo
        /// </summary>
        private string[] vector;

        private ColaConcurrente<String> cola;
        /// <summary>
        /// Índices que indican el rango de elementos del vector 
        /// con el que vamos a trabajar.
        /// En el rango se incluyen ambos índices.
        /// </summary>
        private int indiceDesde, indiceHasta;

        /// <summary>
        /// Resultado del cálculo
        /// </summary>
        private ColaConcurrente<String> resultado;

        internal ColaConcurrente<String> Resultado
        {
            get { return this.resultado; }
        }

        internal Worker(string[] vector, int indiceDesde, int indiceHasta, ref ColaConcurrente<String> resultado)
        {
            this.vector = vector;
            this.indiceDesde = indiceDesde;
            this.indiceHasta = indiceHasta;
            this.resultado = resultado;
        }

        /// <summary>
        /// Método que realiza el cálculo
        /// </summary>
        internal void Calcular()
        {
            for (int i = this.indiceDesde; i <= this.indiceHasta; i++)
            {
                if(TieneMasVocales(vector[i]))
                {
                    this.resultado.Añadir(vector[i]);
                }
            }

                
        }

        private bool TieneMasVocales(String palabra)
        {
            int contV = 0;
            int contC = 0;
            for(int i = 0; i < palabra.Length; i++)
            {
                if(palabra[i].ToString().ToLower().Equals("a") || palabra[i].ToString().ToLower().Equals("e") || palabra[i].ToString().ToLower().Equals("i") || palabra[i].ToString().ToLower().Equals("o") || palabra[i].ToString().ToLower().Equals("u"))
                {
                    contV++;
                }
                else
                {
                    contC++;
                }
            }

            if (contV > contC)
                return true;
            else
                return false;
        }

    }
}
