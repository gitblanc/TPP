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
        private static Model modelo = new Model();

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

        // Currificación

        //Ejercicio 1..

        //Implementar de forma currificada el método Buscar entregado en la sesión anterior.
        //Demostrar el uso de su invocación y de la aplicación parcial.
        //public static T Find<T>(IEnumerable<T> collection, Predicate<T> predicate)
        //{
        //    foreach (var item in collection)
        //    {
        //        if (predicate(item))
        //            return item;
        //    }
        //    return default;
        //}

        // Versión currificada
        public static Func<Predicate<T>, T> Ejercicio4_P6<T>(IEnumerable<T> collection)//, Predicate<T> predicate)
        {
            return predicate =>
            {
                foreach (var item in collection)
                {
                    if (predicate(item))
                        return item;
                }
                return default;
            };
        }

        //Ejercicio 2. EXAMEN

        // Si - > 5 / 3 = 1 ; Resto = 2

        // Entonces -> 3 * 1 + 2 = 5;

        //Currifíquese la función y compruébese mediante el uso de la aplicación parcial el siguiente ejemplo:

        // Se sabe que la división:  20 / 6 = 3. Se desconoce el valor del resto.
        // Partiendo del valor 0, e incrementalmente, obténgase el resto.

        //public static bool ComprobarDivision(int divisor, int dividendo, int cociente, int resto)
        //{
        //    return dividendo == cociente * divisor + resto;
        //}

        //A continuación voy a poner el proceso de ir currificando
        public static Predicate<int> Ejercicio5a_P6(int divisor, int dividendo, int cociente)//, int resto)
        {
            return resto =>
            {
                return dividendo == cociente * divisor + resto;
            };
        }

        public static Func<int, Predicate<int>> Ejercicio5b_P6(int divisor, int dividendo)//, int cociente)//, int resto)
        {
            return cociente =>
            {
                return resto =>
                {
                    return dividendo == cociente * divisor + resto;
                };
            };
        }

        public static Func<int, Func<int, Predicate<int>>> Ejercicio5c_P6(int divisor)//, int dividendo)//, int cociente)//, int resto)
        {
            return dividendo =>
            {
                return cociente =>
                {
                    return resto =>
                    {
                        return dividendo == cociente * divisor + resto;
                    };
                };
            };
        }

        ///------------------------------------------------///
        ///------------------PRACTICA 7--------------------///
        ///------------------------------------------------///

        /* EJERCICIO EXAMEN: Implementa el método Zip de LINQ:
             * - Colecciones potecialmente infinitas.
             * - Trabajará con tuplas .
             * 
        */
        public static IEnumerable<(T, Q)> Ejercicio1_P7<T, Q>(IEnumerable<T> collection1, IEnumerable<Q> collection2)
        {
            var iterator1 = collection1.GetEnumerator();
            var iterator2 = collection2.GetEnumerator();

            while (iterator1.MoveNext() && iterator2.MoveNext())
                yield return (iterator1.Current, iterator2.Current);
        }

        ///------------------------------------------------///
        ///------------------PRACTICA 8--------------------///
        ///------------------------------------------------///
        ///

        public static void Ejercicio1_P8()
        {
            Console.WriteLine("---Ejercicio 1 P8---");
            // Modificar la consulta para mostrar los empleados cuyo nombre empieza por F.
            //var resultado = modelo.Employees;
            var result = modelo.Employees.Where(e => e.Name.StartsWith('F')).Select(e => e.Name);
            Show(result);
        }

        public static void Ejercicio2_P8()
        {
            Console.WriteLine("---Ejercicio 2 P8---");
            //Mostrar Nombre y fecha de nacimiento de los empleados de Cantabria con el formato:
            // Nombre=<Nombre>,Fecha=<Fecha>

            var result = modelo.Employees.Where(e => e.Province.ToLower().Equals("cantabria"))
                .Select(e => $"{e.Name} {e.DateOfBirth}");
            Show(result);

            /*El resultado esperado es:
              Alvaro 19/10/1945 0:00:00
              Dario 16/12/1973 0:00:0066
            */
        }

        public static void Ejercicio3_P8()
        {
            Console.WriteLine("---Ejercicio 3a P8---");
            //Mostrar los nombres de los departamentos que tengan más de un empleado mayor de edad.

            var result = modelo.Departments.Where(d => d.Employees.Count(e => e.Age >= 18) > 1).Select(d => d.Name);
            Show(result);
            /*El resultado esperado es:
                Computer Science
                Medicine
            */

            Console.WriteLine("---Ejercicio 3b P8---");
            //Posteriormente, cree una nueva versión de la consulta para que:
            //Muestre los nombres de los departamentos que tengan más de un empleado mayor de edad
            //y
            //que el despacho (Office.Number) COMIENCE por "2.1"

            var resultb = modelo.Departments.Where(d => d.Employees.Count(e => e.Age >= 18 && e.Office.Number.StartsWith("2.1")) > 1)
                .Select(d => d.Name);
            Show(resultb);

            //El resultado esperado es: Medicine
        }

        public static void Ejercicio4_P8()
        {
            Console.WriteLine("---Ejercicio 4 P8---");
            //El nombre de los departamentos donde ningún empleado tenga despacho en el Building "Faculty of Science".

            //var result = modelo.Departments.Where(d => d.Employees.Count(e => e.Office.Building.ToLower().Equals("faculty of science")) == 0);
            var result = modelo.Departments.Where(d => !d.Employees.Any(e => e.Office.Building.ToLower().Equals("faculty of science"))); // es más eficiente
            Show(result);

            //Resultado esperado: [Department: Mathematics]
        }

        public static void Ejercicio5_P8()
        {
            Console.WriteLine("---Ejercicio 5 P8---");
            // Mostrar las llamadas de teléfono de más de 5 segundos de duración para cada empleado que tenga más de 50 años
            //Cada línea debería mostrar el nombre del empleado y la duración de la llamada en segundos.
            //El resultado debe estar ordenado por duración de las llamadas (de más a menos).

            var result = modelo.PhoneCalls.Where(ll => ll.Seconds > 5).Join(
                modelo.Employees.Where(e => e.Age > 50),
                ll => ll.SourceNumber,
                e => e.TelephoneNumber,
                (ll, e) => new
                {
                    Nombre = e.Name,
                    Duracion = ll.Seconds
                }
                ).OrderByDescending(a => a.Duracion);
            Show(result);

            /*
                { Nombre = Eduardo, Duracion = 23 }
                { Nombre = Eduardo, Duracion = 22 }
                { Nombre = Alvaro, Duracion = 15 }
                { Nombre = Alvaro, Duracion = 10 }
                { Nombre = Felipe, Duracion = 7 }
            */
        }

        public static void Ejercicio6_P8()
        {
            Console.WriteLine("---Ejercicio 6 P8---");
            //Mostrar la llamada realizada más larga para cada empleado, mostrando por pantalla: Nombre_empleado : duracion_llamada_mas_larga

            var result = modelo.PhoneCalls.Join(
                modelo.Employees,
                ll => ll.SourceNumber,
                e => e.TelephoneNumber,
                (ll, e) => new
                {
                    Empleado = e,
                    Llamadas = ll
                }
                ).GroupBy(a => a.Empleado)
                .Select(grupo =>
                    new
                    {
                        Nombre = grupo.Key.Name,
                        Maxima = grupo.Max(a => a.Llamadas.Seconds)
                    }
                );

            Show(result);

            /* ¡OJO NO ESTÁ APLICADO EL FORMATO 
                { Nombre = Alvaro, Maxima = 15 }
                { Nombre = Bernardo, Maxima = 63 }
                { Nombre = Eduardo, Maxima = 23 }
                { Nombre = Felipe, Maxima = 7 }
             */
        }

        public static void Ejercicio7_P8()
        {
            Console.WriteLine("---Ejercicio 7 P8---");
            // Mostrar, agrupados por provincia, el nombre de los empleados
            //Tanto la provincia como los empleados de cada provicia seguirán un orden alfabético.

            var result = modelo.Employees.GroupBy(
                e => e.Province,
                (provincia, empleados) => new
                {
                    Nombre = provincia,
                    Empleados = empleados.OrderBy(e => e.Name).Aggregate("", (acu, e) => $"{acu} {e.Name}")
                }
                ).OrderBy(group => group.Nombre).Select(group => $"{group.Nombre} : {group.Empleados}");
            Show(result);

            /*Resultado esperado:
                Alicante : Carlos
                Asturias : Bernardo Felipe
                Cantabria : Alvaro Dario               
                Granada : Eduardo

            */
        }

        public static void Ejercicio8_P8()
        {
            Console.WriteLine("---Ejercicio 8 P8---");
            //Consulta examen Lunes
            //Nombre y edad de los empleados que estén por debajo de la media de edad

            var media = modelo.Employees.Average(e => e.Age);
            var result = modelo.Employees.Where(e => e.Age < media).Select(e => $"{e.Name} {e.Age}");

            Show(result);
        }

        ///------------------------------------------------///
        ///--------------------HELPERS---------------------///
        ///------------------------------------------------///

        private static void Show<T>(IEnumerable<T> colección)
        {
            foreach (var item in colección)
            {
                PrintInGreen(item);
            }
            Console.WriteLine("Elementos en la colección: {0}.", colección.Count());
        }

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
