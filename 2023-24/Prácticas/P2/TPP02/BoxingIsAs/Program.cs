using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Modelo;
namespace BoxingIsAs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Conversión automática de tipos integrados a objetos (Boxing) y viceversa (Unboxing):
            int entero = 5;
            //Boxing (todas las clases heredan de object -> no hay problema)
            object enteroObjeto = entero;

            //¡Ojo! ¿Qué está ocurriendo?
            entero = 500;
            Console.WriteLine("Boxing entero: {0} . enteroObjeto: {1}", entero, enteroObjeto);

            //La línea inferio no compila, no existe una conversión implícita.
            //entero = enteroObjeto;
            //Unboxing
            entero = (int)enteroObjeto;
            Console.WriteLine("Unboxing {0}", entero);



            Console.WriteLine("\nUso del is:");
            //Uso del is
            Persona p1 = new Persona("Pepa", "Suárez", "1111B");
            Persona p2 = new Persona("Pepe", "Pérez", "0000A");

            //Devolverá true o false.
            if (p2 is Persona)
                Console.WriteLine("p2 es Persona.");

            object p3 = p1;
            if (p3 is Persona)
                Console.WriteLine("p3 es Persona.");


            Console.WriteLine("\nUso del as:");

            //Uso del as -> Si no se puede realizar la conversión, devuelve null.
            //Por tanto, es aplicable siempre y cuando el tipo objetivo pueda ser null.

            // Esto se solucionaría con un is
            // El as te ahorra tener que hacer el casting
            // El is se usa cuando no voy a usar la referencia del objeto
            Persona p4 = p3 as Persona;
            if (p4 != null)
                Console.WriteLine("p3 es Persona.");
            //Recordemos que c era 5.
            Persona p5 = enteroObjeto as Persona;
            if (p5 != null)
                Console.WriteLine("p5 es Persona.");
            else
                Console.WriteLine("p5 no es Persona (null).");

            // ¿Qué ocurre si en lugar de usar as utilizamos un cast directamente?
            // ¿Realmente es buen ejemplo el propuesto para el operador as?

            //EJERCICIO: Crear un método privado y estático que reciba un array de object con objetos Persona y PuntoDeInteres
            //Devolverá un ArrayList (o List) de Persona con los objetos que sean de tipo persona y otro con los PuntoDeInteres
        }

        private static (List<Persona>, List<PuntoDeInteres>) MetodoArrayPersonas(Object[] array) 
        {
            List<Persona> personas = new();
            List<PuntoDeInteres> pD = new();
            foreach (Object o in array) {
                Persona p = o as Persona;
                if (p != null)
                    personas.Add(p);
                
                PuntoDeInteres p1 = o as PuntoDeInteres;
                if (p1 != null)
                    pD.Add(p1);
            }

            return (personas, pD); //¿Mejor con un out?
        }
    }
}
