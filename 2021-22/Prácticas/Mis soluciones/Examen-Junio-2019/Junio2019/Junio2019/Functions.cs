using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Junio2019
{
    internal static class Functions
    {

        //Ejercicio 2 a)

        public static IEnumerable<string> Funcion2a(Func<string> function, int size)
        {
            var result = new string[size];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = function();
            }
            return result;
        }

        //Ejercicio 2 b) es infinito

        public static IEnumerable<string> Funcion2b(Func<string> function, int size)
        {
            while (true)
            {
                if (function().Length <= size)
                    yield return function();
            }
        }

        //Ejercicio 3
        public static IEnumerable<string> Funcion3a(int listsize, int wordsize)
        {
            List<String> lista = new List<String>();
            for (int i = 0; i < listsize; i++)
            {
                lista.Add(" ");

            }
            List<string> lista2 = new List<String>();
            lista2 = lista.Aggregate<string, List<string>>(lista2, (l, cad) =>
            {
                cad = Utils.GetRandomString(wordsize);
                l.Add(cad);
                return l;
            });

            return lista2;
        }

        public static int Funcion3b()
        {
            var lista = Funcion3a(100, 50);
            var randomNumber = Utils.GetRandomNumber(lista.Count());
            var ej1 = new InformationMD5();
            ej1.Username = "tpp";
            ej1.Password = lista.ElementAt(randomNumber);
            var passwd = lista.ElementAt(randomNumber);
            var cont = lista.Where(x => x.Equals(passwd)).Count();
            return cont;
        }

        public static string Funcion3c()
        {
            var list = Funcion3a(200, 500);
            string aux = "";
            aux = list.Where(x => x.Length < 150)
                      .Select(x => x.ToUpper())
                      .Aggregate(aux, (x, cad) =>
                      {
                          x += cad + ";";
                          return x;
                      });
            return aux;
        }
    }
}
