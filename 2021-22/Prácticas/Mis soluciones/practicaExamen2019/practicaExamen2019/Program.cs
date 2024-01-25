using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace practicaExamen2019
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var md5 = new MD5();
            //md5.Username = "Pepito";
            //md5.Password = "áceituna";
            //Console.WriteLine(md5.ToString());
            //Console.WriteLine(md5.Username);
            //md5.Username = null;
            //md5.Username = "a";

            //var list1 = Functions.Funcion2a(Utils.GetRandomString, 90);
            //Show(list1);

            //var list2 = Functions.Funcion2b(Utils.GetRandomString, 50).Take(5);
            //Show(list2);

            //var list3 = Functions.Funcion3a();
            //Show(list3);

            //Console.WriteLine(Functions.Funcion3b());

            Console.WriteLine(Functions.Funcion3c());
        }

        public static void Show<T>(IEnumerable<T> list)
        {
            Console.Write("[");
            int cont = 1;
            foreach (var elem in list)
            {
                Console.Write($"{cont}: {elem} ");
                ++cont;
            }
            Console.Write("]");
            Console.WriteLine();
        }
    }
}
