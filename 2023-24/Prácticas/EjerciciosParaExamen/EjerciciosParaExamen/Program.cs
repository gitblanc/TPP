using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Modelo;

namespace EjerciciosParaExamen
{
    internal class Program
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
    }
}
