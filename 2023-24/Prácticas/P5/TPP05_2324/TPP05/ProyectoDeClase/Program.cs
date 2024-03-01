using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Modelo;

namespace ProyectoDeClase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Libro[] libros = Factoria.CrearLibros();
            Predicate<Libro> contarPaginas = l => l.NumPaginas < 4;
            // CONTAR
            // Primera parte: contar cuántos libros tienen menos de N = 4 páginas
            //Forma 1
            Console.WriteLine(Contar(libros, contarPaginas));
            //Forma 2
            Console.WriteLine(Contar(libros, l => l.NumPaginas < 4));

            // Segunda parte: contar cuántos libros se publicaron más tarde del año N = 2020
            Predicate<Libro> contarYears = l => l.YearPublicacion > 2020;
            //Forma 1
            Console.WriteLine(Contar(libros, contarYears));
            //Forma 2
            Console.WriteLine(Contar(libros, l => l.YearPublicacion > 2020));

            // PRUEBAS
            string vocales = "aeiouAEIOU";
            string vocalesConAcento = "áéíóúÁÉÍÓÚ";
            string consonantes = "qwrtypsdfghjklñzxcvbnm";

            string cad = "pátataw";

            //Contar vocales
            Predicate<char> contarVocales = c => vocales.Contains(c);
            Console.WriteLine($"Contar vocales 1: {Contar(cad, contarVocales)}");
            Console.WriteLine($"Contar vocales 2: {Contar(cad, c => vocales.Contains(c))}");

            //Obtener consonantes
            Predicate<char> contarConsonantes = c => consonantes.Contains(c);
            Action<char> mostrarConsonante = c =>
            {
                Console.WriteLine(c.ToString());
            };
            // Forma 1
            Mostrar(Filtrar(cad, contarConsonantes), c => mostrarConsonante(c));
            // Forma 2
            Mostrar(Filtrar(cad, c => consonantes.Contains(c)), c => Console.WriteLine(c.ToString()));

            // Si contiene alguna vocal con tilde
            Predicate<char> sacarVocalesConTilde = v => vocalesConAcento.Contains(v);
            Action<char> mostrarVocalesConTilde = c =>
            {
                Console.WriteLine(c.ToString());
            };

            // Forma 1
            Mostrar(Filtrar(cad, sacarVocalesConTilde), c => mostrarVocalesConTilde(c));
            // Forma 2
            Mostrar(Filtrar(cad, c => vocalesConAcento.Contains(c)), c => Console.WriteLine(c.ToString()));

            // FUNCIONES LAMBDA
            // multiplicación de dos enteros
            Console.WriteLine("FUNCIONES LAMBDA");
            Func<int, int, int> multiplicarEnteros = (num1, num2) => num1 * num2;
            Func<int, int, int> multiplicarEnteros2 = MultiplicarEnteros;

            Console.WriteLine(multiplicarEnteros(2, 4));
            Console.WriteLine(multiplicarEnteros2(9, 8));

            // comprobar que una cadena tiene una determinada longitud
            Predicate<string> comprobarLongitud = c => c.Length == 5;
            Predicate<string> comprobarLongitud2 = ComprobarLongitud;

            Console.WriteLine(comprobarLongitud("cadena"));
            Console.WriteLine(comprobarLongitud2("caden"));

            // saber si un entero es divisible por otro entero
            Func<int, int, bool> esDivisible = (num1, num2) => num1 % num2 == 0;
            Func<int, int, bool> esDivisible2 = EsDivisible;

            Console.WriteLine(esDivisible(4, 2));
            Console.WriteLine(esDivisible2(9, 8));
        }

        public static bool EsDivisible(int num1, int num2)
        {
            return num1 % num2 == 0;
        }

        public static int MultiplicarEnteros(int num1, int num2)
        {
            return num1 * num2;
        }

        public static bool ComprobarLongitud(string cad)
        {
            return cad.Length == 5;
        }

        //Recibe un IEnumerable y un Delegado genérico (escoger nosotros cuál es el adecuado)
        public static int Contar<T>(IEnumerable<T> vector, Predicate<T> function)
        {
            int cont = 0;
            foreach (var item in vector)
                if (function(item))
                    cont++;
            return cont;
        }

        public static int Contiene<T>(IEnumerable<T> vector, Predicate<T> function)
        {
            int pos = 0;
            foreach (var item in vector)
            {
                if (function(item))
                    return pos;
            }
            return -1;
        }

        public static IEnumerable<T> Filtrar<T>(IEnumerable<T> vector, Predicate<T> function)
        {
            IEnumerable<T> res = new List<T>();
            foreach (var item in vector)
            {
                if (function(item))
                    res = res.Append(item);//Fijarse que devuelve un nuevo IEnumerable con el que queremos añadir
            }
            return res;
        }

        // recibe un IEnumerable y un delegado genérico (Action<T>). Mostrará el título y autor por pantalla
        public static void Mostrar<T>(IEnumerable<T> vector, Action<T> function)
        {
            foreach (var item in vector)
            {
                function(item);
            }
        }
    }
}
