using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen24Abril2020TPP
{
    static class Extensores
    {

        //EJERCICIO 1
        public static IEnumerable<int> Vocales(this string palabra)
        {
            IList<int> repeticiones = new List<int>();
            int contadorA = 0;
            int contadorE = 0;
            int contadorI = 0;
            int contadorO = 0;
            int contadorU = 0;
            for (int i = 0; i < palabra.Length; i++)
            {
                if (palabra[i].ToString().ToLower().Equals("a"))
                {
                    contadorA++;
                }
                else if (palabra[i].ToString().ToLower().Equals("e"))
                {
                    contadorE++;
                }
                else if (palabra[i].ToString().ToLower().Equals("i"))
                {
                    contadorI++;
                }
                else if (palabra[i].ToString().ToLower().Equals("o"))
                {
                    contadorO++;
                }
                else if (palabra[i].ToString().ToLower().Equals("u"))
                {
                    contadorU++;
                }
            }

            repeticiones.Add(contadorA);
            repeticiones.Add(contadorE);
            repeticiones.Add(contadorI);
            repeticiones.Add(contadorO);
            repeticiones.Add(contadorU);

            return repeticiones;
        }
    }
}
