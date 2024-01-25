using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamUtils;

namespace ConsoleApp1
{
    class Program
    {
        static List<InformacionMD5> lista = new List<InformacionMD5>();
        static InformacionMD5 user1 = new InformacionMD5("tpp", "1");
        static InformacionMD5 user2 = new InformacionMD5("tp", "1");
        
		static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 2 Manera no perezosa");
            Ejercicio2(() => Utils.GetRandomString(4, 8), 2);

        }

        //Apartado 1 del ejercicio2
        public static IEnumerable<String> Ejercicio2(Func<String> f, int size)
        {
            List<String> aux = new List<string>();
            for(int i = 0; i < size; i++)
            {
                aux.Add (f());
            }

            foreach (var e in aux)
            {
                Console.WriteLine(e);
            }

            return aux;

        }

        ////Apartado 2 del ejercicio 2 
        //public static IEnumerable<String> Ejercicio2Lazy(Func<String> f, int size)
        //{
        //    List<String> aux = new List<string>();
        //    aux.Add(f());
        //    yield return aux;
        //}

        public static IEnumerable<String> Ejercicio3A()
        {
            List<String> lista = new List<string>();

            var resultado = lista.Where(x =>
             {
                 while (lista.Count() < 100)
                 {
                     x = Utils.GetRandomString(50);
                     lista.Add(x);
                 }

                 return true;
             });

            foreach (var r in resultado)
            {
                Console.WriteLine(r);
            }
         
            return resultado;
        }

 
    }
}
