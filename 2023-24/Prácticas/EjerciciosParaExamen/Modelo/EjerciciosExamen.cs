using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    // Los ejercicios seguirán el formato: EjercicioX_PY -> siendo X el número de ejercicio de la práctica Y
    public static class EjerciciosExamen
    {
        ///------------------------------------------------///
        ///------------------PRACTICA 2--------------------///
        ///------------------------------------------------///

        //EJERCICIO 1: Crear un método privado (lo haré público para poder usarlo xd) y estático que reciba un array de object
        //con objetos Persona y PuntoDeInteres.
        //Devolverá un ArrayList (o List) de Persona con los objetos que sean de tipo persona y otro con los PuntoDeInteres

        public static (List<Persona>, List<PuntoDeInteres>) Ejercicio1_P2(object[] array)
        {
            Console.WriteLine("---Ejercicio 1 P2---");
            List<Persona> personas = new();
            List<PuntoDeInteres> ptosInteres = new();
            foreach (var item in array)
            {
                Persona p = item as Persona;
                if (p != null)
                {
                    personas.Add(p);
                }
                else
                {
                    PuntoDeInteres pto = item as PuntoDeInteres;
                    if (pto != null)
                    {
                        ptosInteres.Add(pto);
                    }
                }
                //Si no es un tipo no reconocido
            }
            Show(personas, "Total de Personas");
            Show(ptosInteres, "Total de Puntos de Interés");
            return (personas, ptosInteres);
        }

        //EJERCICIO 1b: igual que el anterior pero pasando como out el resultado -> ahora es void
        public static void Ejercicio1b_P2(object[] array, out (List<Persona>, List<PuntoDeInteres>) result)
        {
            Console.WriteLine("---Ejercicio 1b P2---");
            List<Persona> personas = new();
            List<PuntoDeInteres> ptosInteres = new();
            foreach (var item in array)
            {
                Persona p = item as Persona;
                if (p != null)
                {
                    personas.Add(p);
                }
                else
                {
                    PuntoDeInteres pto = item as PuntoDeInteres;
                    if (pto != null)
                    {
                        ptosInteres.Add(pto);
                    }
                }
                //Si no es un tipo no reconocido
            }
            Show(personas, "Total de Personas");
            Show(ptosInteres, "Total de Puntos de Interés");
            result = (personas, ptosInteres);
        }

        ///------------------------------------------------///
        ///------------------PRACTICA 4--------------------///
        ///------------------------------------------------///

        /*
         * EJEMPLO EXAMEN
         * EJERCICIO1: Crear un método que reciba dos colecciones que implementen IEnumerable<T>
         * Y devuelva como resultado un IEnumerable<T> con los valores que coincidan en la misma posición.
         * Resolver el ejercicio utilizando ITERADORES (IEnumerator).
         * Probar enviando:
         * Un array de caracteres y un string.
         * Una lista de caracteres y un string.
         * Vuestra lista con caracteres y otra lista vuestra con caracteres.
         * El resultado se recorre en un foreach y se imprime elemento a elemento.
        */

        //Pd: tuve que redefinir el Equals en la clase Persona

        public static IEnumerable<T> Ejercicio1_P4<T>(IEnumerable<T> coleccion1, IEnumerable<T> coleccion2)
        {
            Console.WriteLine("---Ejercicio 1 P4---");
            var iterador1 = coleccion1.GetEnumerator();
            var iterador2 = coleccion2.GetEnumerator();
            List<T> result = new();
            while (iterador1.MoveNext() && iterador2.MoveNext())
            {
                if (iterador1.Current.Equals(iterador2.Current))
                    result.Add(iterador1.Current);
            }
            return result;
        }

        /* Variación del ejercicio anterior que se me ocurrió a mi:
         * Ejercicio 1b: hacer que el método anterior sea de tipo generador (Lazy)
         */

        public static IEnumerable<T> Ejercicio1b_P4<T>(IEnumerable<T> coleccion1, IEnumerable<T> coleccion2)
        {
            var iterador1 = coleccion1.GetEnumerator();
            var iterador2 = coleccion2.GetEnumerator();
            while (iterador1.MoveNext() && iterador2.MoveNext())
            {
                if (iterador1.Current.Equals(iterador2.Current))
                {
                    yield return iterador1.Current; // Utilizamos 'yield return' para devolver el elemento actual
                }
            }
        }



        ///------------------------------------------------///
        ///--------------------HELPERS---------------------///
        ///------------------------------------------------///

        private static void Show<T>(IEnumerable<T> colección, string mensaje)
        {
            Console.WriteLine(mensaje);
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
