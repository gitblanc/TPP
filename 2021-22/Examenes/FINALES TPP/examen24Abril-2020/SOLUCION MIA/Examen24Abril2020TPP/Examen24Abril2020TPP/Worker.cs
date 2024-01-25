using System;
using System.Collections.Generic;
using System.Text;

namespace Examen24Abril2020TPP
{
    class Worker
    {

        private string[] palabras;

        private int indiceDesde, indiceHasta;

        private ColaConcurrente<string> cola;


        internal Worker(string[] palabras, int indiceDesde, int indiceHasta, ref ColaConcurrente<string> cola)
        {
            this.palabras = palabras;
            this.indiceDesde = indiceDesde;
            this.indiceHasta = indiceHasta;
            this.cola = cola;
        }

        internal void Calcular()
        {
            this.cola = new ColaConcurrente<string>();
            for(int i = this.indiceDesde; i <= this.indiceHasta; i++)
            {
                if(MasVocales(palabras[i]))
                {
                    //AQUI IRIA UN LOCK
                    cola.Añadir(palabras[i]);
                }
            }
        }

        internal Boolean MasVocales(string palabra)
        {
            int vocales = 0;
            int consonantes = 0;
            for(int i = 0; i < palabra.Length; i++)
            {
                if(palabra[i].ToString().ToLower().Equals("a") || palabra[i].ToString().ToLower().Equals("e") ||
                    palabra[i].ToString().ToLower().Equals("i") || palabra[i].ToString().ToLower().Equals("o") ||
                    palabra[i].ToString().ToLower().Equals("u"))
                {
                    vocales++;
                }
                else
                {
                    consonantes++;
                }

            }
            return vocales > consonantes;
        }

    }
}
