using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Modelo;

namespace EjerciciosParaExamen
{
    internal static class Program
    {
        //Acordarse de añadir las dependencias del Modelo de clases en la aplicación de consola (Program) para poder usarlas
        static void Main(string[] args)
        {
            PrintInRed("///------------------------------------------------///\r\n///------------------PRACTICA 2--------------------///\r\n///------------------------------------------------///");
            var personaspuntos = Factoria.CrearArrayPersonasPtosInteres();
            var resEj1_P2 = EjerciciosExamen.Ejercicio1_P2(personaspuntos);

            (List<Persona>, List<PuntoDeInteres>) resEj1b_P2;
            EjerciciosExamen.Ejercicio1b_P2(personaspuntos, out resEj1b_P2); //Funciona pero me da chapa hacer un Show adaptado para mostrarlo por consola, así que mejor depurar y verlo

            PrintInRed("///------------------------------------------------///\r\n///------------------PRACTICA 4--------------------///\r\n///------------------------------------------------///");

            var resEj1_P4 = EjerciciosExamen.Ejercicio1_P4(Factoria.CrearPersonas(), Factoria.CrearOtrasPersonas());
            Show(resEj1_P4);

            var resEj1b_P4 = EjerciciosExamen.Ejercicio1b_P4(Factoria.CrearPersonas(), Factoria.CrearOtrasPersonas());
            Console.WriteLine("---Ejercicio 1b P4---");
            Show(resEj1b_P4);
            Show(resEj1b_P4.Take(1));//Cogemos sólo 1 elemento de la lista generada con yield
            Show(resEj1b_P4.Skip(2).Take(2));//Cogemos sólo 2 elemento de la lista generada con yield habiéndonos saltado los 2 primeros

            PrintInRed("///------------------------------------------------///\r\n///------------------PRACTICA 5--------------------///\r\n///------------------------------------------------///");
            var libros = Factoria.CrearLibros();
            var resEj1_P5 = EjerciciosExamen.Ejercicio1_P5(libros, l => l.NumPaginas < 4);
            PrintInGreen($"Libros con menos de 4 páginas: {resEj1_P5}, de un total de {libros.Length} libros.");
            resEj1_P5 = EjerciciosExamen.Ejercicio1_P5(libros, l => l.YearPublicacion > 2020);
            PrintInGreen($"Libros publicados después de 2020: {resEj1_P5}, de un total de {libros.Length} libros.");

            string vocales = "aeiouAEIOU";
            string consonantes = "qwrtypsdfghjklñzxcvbnm";
            string cad = "pátataw";

            var resEj2_P5 = EjerciciosExamen.Ejercicio2_P5(cad, c => vocales.Contains(c));
            PrintInGreen($"Contar vocales: {resEj2_P5}");
            resEj2_P5 = EjerciciosExamen.Ejercicio2_P5(cad, a => consonantes.Contains(a));
            PrintInGreen($"Posición de la primera consonante: {resEj2_P5}");

            var resEj3_P5 = EjerciciosExamen.Ejercicio3_P5(cad, c => consonantes.Contains(c));//Reduce la cadena a sus consonantes únicamente
            Show(resEj3_P5);

            var resEj3b_P5 = EjerciciosExamen.Ejercicio3b_P5(cad, c => consonantes.Contains(c));//Reduce la cadena a sus consonantes únicamente con generadores
            Show(resEj3b_P5);
            Show(resEj3b_P5.Skip(1).Take(2));//saltamos 1 elemento y cogemos los 2 siguientes

            PrintInRed("///------------------------------------------------///\r\n///------------------PRACTICA 6--------------------///\r\n///------------------------------------------------///");
            var resEj1a_P6 = EjerciciosExamen.Ejercicio1a_P6(50);
            Console.WriteLine("---Ejercicio 1a P6---");
            for (int i = 0; i < 10; i++)//Llamo 10 veces a la clausura para que me dé 10 números
            {
                PrintInGreen($"Llamada número {i} a la clausura 1 de la P6: {resEj1a_P6()}");
            }

            Console.WriteLine("---Ejercicio 1b P6---");
            Action reiniciar;
            Action<int> modificarInicial;
            var resEj1b_P6 = EjerciciosExamen.Ejercicio1b_P6(50, out reiniciar, out modificarInicial); //No hay que pasar modificarInicial(34) -> esto se hace después
            for (int i = 0; i < 10; i++)//Llamo 10 veces a la clausura para que me dé 10 números, para ver que funciona igual que el apartado a)
            {
                PrintInGreen($"Llamada número {i} a la clausura 2 de la P6: {resEj1b_P6()}");
            }

            Console.WriteLine("Se reinicia forzosamente");
            reiniciar();

            for (int i = 0; i < 10; i++)
            {
                PrintInGreen($"Llamada número {i} a la clausura 2 de la P6: {resEj1b_P6()}");
            }

            Console.WriteLine("Se cambia el valor original por 34");
            modificarInicial(34);

            for (int i = 0; i < 10; i++)//Llamo 10 veces a la clausura para que me dé 10 números, para ver que funciona igual que el apartado a), pero cambiando el valor inicial
            {
                PrintInGreen($"Llamada número {i} a la clausura 2 de la P6: {resEj1b_P6()}");
            }

            Console.WriteLine("---Ejercicio 2 P6---");
            var resEj2_P6 = EjerciciosExamen.Ejercicio2_P6();

            Console.WriteLine("Los 10 primeros términos de la sucesión de Fibonacci");
            for (int i = 0; i < 10; i++)
            {
                PrintInGreen($"Término {i + 1} = {resEj2_P6()}");
            }

            Console.WriteLine("---Ejercicio 3 P6---");
            PrintInGreen("Descoméntalo y verás un bucle JODIDAMENTE infinito... :D");
            // Bucle infinito COMO UNA CASA DE GRANDE
            //Func<bool> condicion = () => true;
            //Action cuerpo = () =>
            //{
            //    PrintInGreen("Cuerpo del bucle");
            //};
            //EjerciciosExamen.Ejercicio3_P6(condicion, cuerpo);

            Console.WriteLine("---Ejercicio 4 P6---");
            var resEj4_P6 = EjerciciosExamen.Ejercicio4_P6(Factoria.CrearPersonas())(p => p.Edad > 18);
            PrintInGreen(resEj4_P6.ToString());

            Console.WriteLine("---Ejercicio 5a P6---");
            var resEj5a_P6 = EjerciciosExamen.Ejercicio5a_P6(5, 3, 1)(2);
            PrintInGreen(resEj5a_P6);

            Console.WriteLine("---Ejercicio 5b P6---");
            var resEj5b_P6 = EjerciciosExamen.Ejercicio5b_P6(5, 3)(1)(2);
            PrintInGreen(resEj5b_P6);

            Console.WriteLine("---Ejercicio 5c P6---");
            var resEj5c_P6 = EjerciciosExamen.Ejercicio5c_P6(5)(3)(1)(2);
            PrintInGreen(resEj5c_P6);

            Console.WriteLine("---Ejercicio 5c2 P6---");
            var resEj5c2_P6 = EjerciciosExamen.Ejercicio5c_P6(1)(5)(3)(2);
            PrintInGreen(resEj5c2_P6);

            Console.WriteLine("---Ejercicio 5c3 P6---");
            // Se sabe que la división:  20 / 6 = 3. Se desconoce el valor del resto.
            // Partiendo del valor 0, e incrementalmente, obténgase el resto.
            var resto = 0;
            while (true)
            {
                if (EjerciciosExamen.Ejercicio5c_P6(3)(20)(6)(resto))
                {
                    PrintInGreen($"resto de 20/6: {resto}");
                    break;
                }
                resto += 1;
            }

            Console.WriteLine("---Ejercicio 7 P6---");
            const int desde = 0, cantidad = 100, mostrarNElementos = 100;
            var resEj7_P6 = EjerciciosExamen.Ejercicio7_P6(desde, cantidad); //El iterador
            Console.Write("{0} elementos tras el término {1} (perezosa/lazy):\n\t", mostrarNElementos, desde);
            resEj7_P6.ForEach(item => PrintInGreen($"{item} "), mostrarNElementos);

            Console.WriteLine("---Ejercicio 9 P6---");
            var collection = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int n = 3;

            var partitionedCollection = EjerciciosExamen.Ejercicio9_P6(collection, n);

            foreach (var part in partitionedCollection)
            {
                foreach (var item in part)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("---Ejercicio 10 P6---");
            var resEj10_P6 = EjerciciosExamen.Ejercicio10_P6(collection, 40);//Cogemos la colección del ejercicio anterior
            resEj10_P6.ForEach(item => PrintInGreen($"{item} "));

            PrintInRed("///------------------------------------------------///\r\n///------------------PRACTICA 7--------------------///\r\n///------------------------------------------------///");

            Console.WriteLine("---Ejercicio 1 P7---");
            var resEj1_P7 = EjerciciosExamen.Ejercicio1_P7(Factoria.CrearPersonas(), Factoria.CrearLibros());
            Show(resEj1_P7);

            PrintInRed("///------------------------------------------------///\r\n///------------------PRACTICA 8--------------------///\r\n///------------------------------------------------///");
            EjerciciosExamen.Ejercicio1_P8();
            EjerciciosExamen.Ejercicio2_P8();
            EjerciciosExamen.Ejercicio3_P8();
            EjerciciosExamen.Ejercicio4_P8();
            EjerciciosExamen.Ejercicio5_P8();
            EjerciciosExamen.Ejercicio6_P8();
            EjerciciosExamen.Ejercicio7_P8();
            EjerciciosExamen.Ejercicio8_P8();
            EjerciciosExamen.Ejercicio9_P8();
            EjerciciosExamen.Ejercicio10_P8();
            EjerciciosExamen.Ejercicio11_P8();
            EjerciciosExamen.Ejercicio12_P8();
            EjerciciosExamen.Ejercicio13_P8();
            //Los que se me fueron ocurriendo de LinQ
            EjerciciosExamen.Ejercicio14_P8();
            EjerciciosExamen.Ejercicio15_P8();
            EjerciciosExamen.Ejercicio16_P8();
            EjerciciosExamen.Ejercicio17_P8();
            EjerciciosExamen.Ejercicio18_P8();
            EjerciciosExamen.Ejercicio19_P8();
            EjerciciosExamen.Ejercicio20_P8();
            EjerciciosExamen.Ejercicio21_P8();
            EjerciciosExamen.Ejercicio22_P8();
            EjerciciosExamen.Ejercicio23_P8();
        }

        private static void PrintInRed(string text)
        {
            var colorActual = Console.ForegroundColor;

            // Cambiar el color del texto a Rojo
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine();
            Console.WriteLine(text);
            Console.WriteLine();

            // Restablecer al color original
            Console.ForegroundColor = colorActual;
        }

        private static void Show<T>(IEnumerable<T> colección)
        {
            foreach (var item in colección)
            {
                PrintInGreen(item);
            }
            Console.WriteLine("Elementos en la colección: {0}.", colección.Count());
        }

        private static void PrintInGreen<T>(T text)
        {
            var colorActual = Console.ForegroundColor;

            // Cambiar el color del texto a Verde
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(text);

            // Restablecer al color original
            Console.ForegroundColor = colorActual;
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action, int? maximoElementos = null)
        {
            int contador = 0;
            foreach (T item in enumerable)
            {
                if (maximoElementos.HasValue && maximoElementos.Value < contador++)
                    break;
                action(item);
            }
        }
    }
}
