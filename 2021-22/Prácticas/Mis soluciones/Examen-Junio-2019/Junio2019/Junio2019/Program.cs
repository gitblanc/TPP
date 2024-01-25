using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junio2019
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio 1
            var usuario = "Pepito";
            var usuarioNotValid = "a";
            var key1 = "patatuela";
            var md5 = new InformationMD5();
            md5.Username = usuario;
            md5.Password = key1;
            var sha1 = new InformationSHA1();
            sha1.Username = usuario;
            sha1.Password = key1;
            Console.WriteLine(md5.ToString());
            Console.WriteLine(sha1.ToString());
            //md5.Username = usuarioNotValid;
            //Console.Write(md5.ToString());
            Console.Write(md5.Username);

            //Ejercicio 2
            //var size = Utils.GetRandomNumber(20);
            //var wordsSize = Utils.GetRandomNumber(5);
            //var lista2a = Functions.Funcion2a(Utils.GetRandomString, size);
            //foreach (var elem in lista2a)
            //    Console.WriteLine(elem);

            //var lista2b = Functions.Funcion2b(Utils.GetRandomString, 5).Take(20);
            //int cont = 1;
            //foreach (var elem in lista2b)
            //{
            //    Console.WriteLine($"{cont} {elem}");
            //    ++cont;
            //}

            //Ejercicio 3
            //var lista = Functions.Funcion3a(100, 50);
            //foreach(var elem in lista)
            //    Console.WriteLine(elem);
            //Console.WriteLine();
            //Console.WriteLine(Functions.Funcion3b());
            //Console.WriteLine(Functions.Funcion3c());
        }
    }
}
