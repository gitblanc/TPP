using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace practicaExamen2019
{
    public class Functions
    {
        static public IEnumerable<string> Funcion2a(Func<string> function, int size)
        {
            var result = new List<string>();
            for (int i = 0; i < size; i++)
            {
                result.Add(function());
            }
            return result;
        }

        static public IEnumerable<string> Funcion2b(Func<int, string> function, int wordsize)
        {
            while (true)
                yield return function(wordsize);
        }


        static public IEnumerable<string> Funcion3a(int size, int wordsize)
        {
            var list = new List<string>();
            for (int i = 0; i < size; i++)
                list.Add("");

            var list2 = new List<string>();
            list2 = list.Aggregate(list2, (x, cad) =>
            {
                cad = Utils.GetRandomString(wordsize);
                x.Add(cad);
                return x;
            });
            return list2;
        }

        static public int Funcion3b()
        {
            var array = Funcion3a(100, 50);
            var pos = Utils.GetRandomNumber(array.Count());
            var md5 = new MD5();
            md5.Username = "tpp";
            md5.Password = array.ElementAt(pos);
            var pass = array.ElementAt(pos);

            var contador = 0;
            contador = array.Aggregate(contador, (a, b) =>
             {
                 if (b.Equals(pass))
                     contador++;
                 return contador;
             });
            return contador;

            //lista.Where(x => x.Equals(passwd)).Count(); otra forma
        }

        static public string Funcion3c()
        {
            var list = Funcion3a(200, 500);
            var result = list.Where(x => x.Length < 150)
                             .Select(x => x.ToUpper())
                             .Aggregate("", (a, b) =>
                             {
                                 a += $"{b};";
                                 return a;
                             });
            return result;
        }
    }
}
