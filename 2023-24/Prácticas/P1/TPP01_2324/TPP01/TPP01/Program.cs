﻿using System;
//Añade el using que falta.
using TPP01.Modelo;//Hay que agregar la referencia al proyecto -> Dependencias >> seleccionar Autor -> poner la clase en public

namespace TPP01
{
    class Program
    {

        static void Main(string[] args)
        {
            //Proyecto -> Propiedades de TPP01 -> Depurar -> Argumentos de aplicación.
            if (args.Length < 2 || !args[0].Equals("OK") )
            { 
                Console.WriteLine("Establezca al menos dos parámetros de entrada, siendo el primero la cadena: OK");
                Environment.Exit(0);
            }

            //Instanciamos a la autora utilizando el constructor.
            Autor a1 = new Autor("Wisława", "Szymborska");
            Console.WriteLine("Nuevo registro: {0}", a1);

            //Instanciamos al autor utilizando un inicializador de objeto.
            Autor a2 = new Autor { Nombre = "Hermann", Apellido = "Hesse" };
            Console.WriteLine("Nuevo registro: {0}", a2);





#if DEBUG
            Console.WriteLine("Ejecución modo DEBUG");
#elif RELEASE
            Console.WriteLine("Ejecución modo RELEASE");
#endif

        }
    }
}
