using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
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
        ///------------------PRACTICA 5--------------------///
        ///------------------------------------------------///

        //Ejercicio 1: crear el método Contar: Recibe un IEnumerable y un Delegado genérico. Devuelve el número de elementos del IEnumerable
        //que cumplen la condición del delegado. Probar para:
        //- Para obtener cuántos libros tienen menos de N páginas
        //- Para obtener cuántos libros se publicaron más tarde del año N.
        //- Implementar el delegado genérico directamente en las llamadas de prueba al método contar, como una expresión lambda.

        public static int Ejercicio1_P5<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            int cont = 0;
            foreach (var item in collection)
            {
                if (predicate(item))
                    cont += 1;
            }
            return cont;
        }

        //Ejercicio 2: crear el método Contiene: Recibe un IEnumerable y un Delegado genérico. Devuelve la posición del primer elemento que cumple 
        //las condiciones. Devuelve -1 si no encuentra elementos.
        public static int Ejercicio2_P5<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            int cont = 0;
            foreach (var item in collection)
            {
                if (predicate(item))
                    return cont;
                cont += 1;
            }
            return -1;
        }

        //Ejercicio 3: crear el método Filtrar: Recibe un IEnumerable y un Delegado genérico. Devuelve un IEnumerable con los elementos que
        //cumplen la condición.
        public static IEnumerable<T> Ejercicio3_P5<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            List<T> result = new();
            foreach (var item in collection)
            {
                if (predicate(item))
                    result.Add(item);
            }
            return result;
        }

        //Formato que se me ocurre a mí: hacerlo con generadores
        public static IEnumerable<T> Ejercicio3b_P5<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                    yield return item;
            }
        }

        ///------------------------------------------------///
        ///------------------PRACTICA 6--------------------///
        ///------------------------------------------------///

        //Ejercicios de Clausuras

        /* Examen 21/22 EXAMEN
        
        Ejercicio 1 (A – 1,50 puntos).

            Dado un valor inicial, impleméntese una clausura que, en cada invocación,
            devuelva un número aleatorio inferior al anterior devuelto.Una vez llegue al valor
            cero y lo devuelva, el generador se reiniciará al valor inicial de forma automática.

            (B – 1,00 punto).

            Cree una versión del anterior que permita tanto reiniciar el generador de forma manual
            como modificar el valor inicial.
        
        
            Añádase código en el método Main para probar ambas versiones.
        
         */

        public static Func<int> Ejercicio1a_P6(int inicial)
        {
            Random random = new();
            int _value = inicial;

            return () =>
            {
                if (_value > 0)
                {
                    int copia = _value;
                    _value = random.Next(0, _value);
                    return copia;//Hago que la primera vez siempre devuelva el 50
                }
                else
                {
                    _value = inicial;
                    Console.WriteLine("Reiniciando clausura...");
                    return 0;
                }
            };
        }

        //apartado b del ejercicio del examen
        public static Func<int> Ejercicio1b_P6(int inicial, out Action reiniciar, out Action<int> modificarInicial)
        {
            Random random = new();
            int _valorInicial = inicial;
            int _value = inicial;

            reiniciar = () =>
            {
                _value = _valorInicial;

            };
            modificarInicial = nuevoValor => _valorInicial = nuevoValor;

            return () =>
            {
                if (_value > 0)
                {
                    int copia = _value;
                    _value = random.Next(0, _value);
                    return copia;//Hago que la primera vez siempre devuelva el 50
                }
                else
                {
                    _value = _valorInicial;
                    Console.WriteLine("Reiniciando clausura...");
                    return 0;
                }
            };
        }

        /* Ejercicio Clase 1
         

        Implementar una clausura que devuelva el siguiente término de la sucesión de Fibonacci
        cada vez que se invoque la clausura:
        
                1,1,2,3,5,8…
        
        Utilícese como base/idea el ejemplo del contador.
        
        NOTA: No es necesario usar la clase Fibonacci PARA NADA, simplemente para
              aprender a calcular términos de Fibonnaci si no se sabe calcularlos.

        */
        public static Func<int> Ejercicio2_P6()
        {
            int _primero = 0, _segundo = 1;

            return () =>
            {
                int suma = _primero + _segundo;
                int copia_primero = _primero;
                _primero = _segundo;
                _segundo = suma;
                return copia_primero;
            };
        }

        /* Ejercicio Clase 2
         
           Impleméntese mediante un enfoque funcional el bucle While
           Pruébese la implementación para el ejemplo propuesto.

         */

        public static void Ejercicio3_P6(Func<bool> condicion, Action cuerpo)
        {
            if (condicion())
            {
                cuerpo();
                Ejercicio3_P6(condicion, cuerpo);
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
