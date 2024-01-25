using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junio2019
{
    class Program
    {
        static List<InformacionMD5> lista = new List<InformacionMD5>();
        static InformacionMD5 user1 = new InformacionMD5("tpp", "1");
        static InformacionMD5 user2 = new InformacionMD5("tp", "1");
        
		static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 2 Manera no perezosa");
            IEnumerable<string> lista = Ejercicio2(() => Utils.GetRandomString(4, 8), 2);
            foreach (var e in lista)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Ejercicio 2 Manera perezosa");
            IEnumerable<string> lista2 = Ejercicio2LazyTamaño(() => Utils.GetRandomString(4, 8), 2);
            foreach (var e in lista2)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Ejercicio 3A");
            IEnumerable<string> lista3 = Ejercicio3A();
            foreach (var e in lista3)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Ejercicio 3B");
            Console.WriteLine(Ejercicio3B());

            Console.WriteLine("Ejercicio 3C");
            Ejercicio3C();

        }

        //Apartado 1 del ejercicio2
        public static IEnumerable<String> Ejercicio2(Func<String> f, int size)
        {
            List<String> aux = new List<string>();
            for (int i = 0; i < size; i++)
            {
                aux.Add(f());
            }

            return aux;

        }

        ////Apartado 2 del ejercicio 2 
        public static IEnumerable<String> Ejercicio2Lazy(Func<String> f)
        {
            while (true)
            {
                String cadena = f();
                yield return cadena;
            }
        }

        public static IEnumerable<string> Ejercicio2LazyTamaño(Func<String> f, int size)
        {
            IEnumerable<string> lista2 = Ejercicio2Lazy(f).Skip(0).Take(size);
            return lista2;
        }

        public static IEnumerable<String> Ejercicio3A()
        {
            List<String> lista = new List<String>();
            for (int i = 0; i < 100; i++)
            {
                lista.Add(" ");

            }
            List<string> lista2 = new List<String>();
            lista2 = lista.Aggregate<string, List<string>>(lista2, (l, cad) =>
            {
                cad = Utils.GetRandomString(50);
                l.Add(cad);
                return l;
            });

            return lista2;

        }

        public static int Ejercicio3B()
        {
            IEnumerable<String> lista = Ejercicio3A();
            String contraseña = lista.ElementAt(Utils.GetRandomNumber(lista.Count()));
            InformacionMD5 us = new InformacionMD5("tpp", contraseña);
            var r = lista.Where(s => s.Equals(contraseña));
            int res = r.Count();
            return res;
        }

        public static void Ejercicio3C()
        {
            List<string> lista = new List<string>();
            string resultado = "";
            for(int i = 0; i < 200; i++)
            {
                lista.Add(Utils.GetRandomString(500));
            }
            resultado = lista.Where(s => s.Length < 150).Select(s => s.ToUpper()).
                Aggregate(resultado, (r, cad) =>
                {
                    r += cad + ";";
                    return r;
                });
            Console.WriteLine(resultado);
        }

        public static IDictionary<int, InformacionSha1> Ejercicio4()
        {
            InformacionSha1[] usuarios = null;

            usuarios[0] = new InformacionSha1("Luis", "abc");
            usuarios[1] = new InformacionSha1("Pepe", "3n4");
            usuarios[2] = new InformacionSha1("Jose", "xxx");
            usuarios[3] = new InformacionSha1("Paco", "fuj");
            usuarios[4] = new InformacionSha1("Carlos", "1jf");
            usuarios[5] = new InformacionSha1("Carla", "aoj");
            usuarios[6] = new InformacionSha1("Lucía", "24k");
            usuarios[7] = new InformacionSha1("Carmen", "ajg");
            usuarios[8] = new InformacionSha1("Andrea", "tfe");
            usuarios[9] = new InformacionSha1("Sara", "ber");


            string[] claves = null;
            for(int i = 0; i < 1000; i++) {
                claves[i] = Utils.GetRandomString(3);
            }

            IDictionary<int, InformacionSha1> result = null;

            Master master = new Master(claves, usuarios);
            result = master.ComputeModulus();

            return result;
        }

    }
}
