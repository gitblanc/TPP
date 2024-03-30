using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO.MemoryMappedFiles;
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

        //-------------------------------------------------------------------------------------------------------
        // -- A partir de aquí, pongo ejercicios extra que se me han ido ocurriendo relacionados con Funciones --
        // ---------------------,generadores, memoizacion, currificacion, clausuras etc etc----------------------
        //-------------------------------------------------------------------------------------------------------

        /*
         * Currificación de un Filtrador y Transformador de Colecciones: Implementa un método que utilice currificación 
         * para aceptar primero un Predicate<TP> para filtrado, luego un Func<TP, TResult> para transformación, y finalmente 
         * un IEnumerable<T> sobre el cual aplicar estas operaciones, retornando un IEnumerable<TResult>.
         */

        //Primera versión sin currificar
        public static IEnumerable<TR> Ejercicio6a_P6<TP, TR>(Predicate<TP> filtrado, Func<TP, TR> transformer, IEnumerable<TP> collection)
        {
            List<TR> res = new();
            foreach (var elem in collection)
            {
                if (filtrado(elem))
                    res.Add(transformer(elem));
            }

            return res;
        }

        //Primera versión currificada 1 vez
        public static Func<IEnumerable<TP>, IEnumerable<TR>> Ejercicio6b_P6<TP, TR>(Predicate<TP> filtrado, Func<TP, TR> transformer)//, IEnumerable<TP> collection)
        {
            return collection =>
            {
                List<TR> res = new();
                foreach (var elem in collection)
                {
                    if (filtrado(elem))
                        res.Add(transformer(elem));
                }

                return res;
            };
        }

        //Primera versión currificada 2 vez
        public static Func<Func<TP, TR>, Func<IEnumerable<TP>, IEnumerable<TR>>> Ejercicio6c_P6<TP, TR>(Predicate<TP> filtrado)//, Func<TP, TR> transformer)//, IEnumerable<TP> collection)
        {
            return transformer =>
            {
                return collection =>
                {
                    List<TR> res = new();
                    foreach (var elem in collection)
                    {
                        if (filtrado(elem))
                            res.Add(transformer(elem));
                    }

                    return res;
                };
            };
        }

        /*
         * Generador Infinito de Números Aleatorios con Estado: Utiliza un generador para implementar un 
         * método que produzca una secuencia (potencialmente) infinita de pares de números aleatorios (del 0 al 10). 
         * Sin embargo, cada par generado debe ser diferente al anterior (sin repetición inmediata). 
         * Implementa esto usando técnicas de memoización para recordar el último par generado
         */


        public static IEnumerable<(int, int)> Ejercicio7_P6(int desde, int cuantos)
        {
            return RandomGeneradorLazy().Skip(desde).Take(cuantos);
        }

        //El generador
        private static IEnumerable<(int, int)> RandomGeneradorLazy()
        {
            PrintInGreen("Entra en generador perezoso de números aleatorios");
            while (true)
                yield return RandomNumerosMemoization.RandomNumber();
        }

        //La clase con la caché que genera las tuplas de números random
        internal class RandomNumerosMemoization
        {
            //private static IDictionary<(int, int), (int, int)> _cache = new Dictionary<(int, int), (int, int)>(); Esto sería SIN REPETICIÓN
            private static (int, int)? prevValues = null;//Esto es para SIN REPETICIÓN INMEDIATA
            private static Random random = new();
            public static (int, int) RandomNumber()
            {
                var newValue = (random.Next(0, 11), random.Next(0, 11));
                //while (_cache.Keys.Contains((random.Next(0, 101), random.Next(0, 101)))) Esto sería SIN REPETICIÓN
                while (newValue.Equals(prevValues))
                {
                    newValue = (random.Next(0, 11), random.Next(0, 11));
                    Console.WriteLine($"La tupla {prevValues} era la anterior -> nueva tupla: {newValue}");
                }
                //_cache.Add((value1, value2), (value1, value2)); Esto sería SIN REPETICIÓN
                prevValues = newValue;
                return newValue;
            }
        }

        /*
         * Método Extensor de Tuplas para Mapeo y Filtrado Condicional: Crea un método extensor currificado para IDictionary<TKey, TValue> 
         * que permita filtrar la colección basándose en una condición aplicada a TKey y luego mapear TValue a un nuevo valor. 
         * El resultado debe ser un IDictionary<TKey, TResult>.
         */
        //Sin currificar
        public static IDictionary<Tkey, TRes> Ejercicio8a_P6<Tkey, TValue, TRes>(this IDictionary<Tkey, TValue> dictionary, Predicate<Tkey> condition, Func<TValue, TRes> mapper)
        {
            Dictionary<Tkey, TRes> res = new();
            foreach (var item in dictionary)
            {
                if (condition(item.Key))
                {
                    res[item.Key] = mapper(item.Value);
                }
            }

            return res;
        }

        //Currificado (1 vez)
        public static Func<Func<TValue, TRes>, IDictionary<Tkey, TRes>> Ejercicio8b_P6<Tkey, TValue, TRes>(this IDictionary<Tkey, TValue> dictionary, Predicate<Tkey> condition)//, Func<TValue, TRes> mapper)
        {
            return mapper =>
            {
                Dictionary<Tkey, TRes> res = new();
                foreach (var item in dictionary)
                {
                    if (condition(item.Key))
                    {
                        res[item.Key] = mapper(item.Value);
                    }
                }

                return res;
            };
        }

        //ESTO ESTA MAL, PORQUE NO SE LE ESTARÍA PASANDO NINGÚN PARÁMETRO (FIJARSE QUE ES EXTENSOR)
        //public static Func<Predicate<Tkey>, Func<Func<TValue, TRes>, IDictionary<Tkey, TRes>>> Ejercicio8c_P6<Tkey, TValue, TRes>(this IDictionary<Tkey, TValue> dictionary)//, Predicate<Tkey> condition)//, Func<TValue, TRes> mapper)
        //{
        //    return condition =>
        //    {
        //        return mapper =>
        //        {
        //            Dictionary<Tkey, TRes> res = new();
        //            foreach (var item in dictionary)
        //            {
        //                if (condition(item.Key))
        //                {
        //                    res[item.Key] = mapper(item.Value);
        //                }
        //            }

        //            return res;
        //        };
        //    };
        //}

        /*
         * EJERCICIO EXAMEN LUNES (Siento la explicación, es lo que me pasaron)
         * Dado una colección y un n, patir la colección dada en partes de tamaño n y devolver una colección de colecciones
         */

        /* ¿Qué pasa si el tamaño es mayor al de la colección pasada?
         * - Asumo que se devolverá una lista con una única lista dentro
         * 
         * ¿Qué pasa si al dividir en x trozos de tamaño n, hay un trozo que no tiene dicho tamaño (sino que tiene n-1 por ejemplo)?
         * - Asumo que quedarán x listas de tamaño n y una de tamaño n-1
        */
        public static IEnumerable<IEnumerable<T>> Ejercicio9_P6<T>(IEnumerable<T> collection, int n)
        {
            var part = new List<T>();

            foreach (var item in collection)
            {
                part.Add(item);
                if (part.Count == n)
                {
                    yield return new List<T>(part);
                    part.Clear();
                }
            }

            if (part.Count > 0)
            {
                yield return part; // Devolvemos los que quedasen sueltos
            }
        }

        /*
         * EJERCICIO EXAMEN LUNES (Siento la explicación, es lo que me pasaron)
         * Dado una colección y un n, sacar n elementos de la colección de forma aleatoria. Sólo se pueden repetir si ya se seleccionaron
         * todos los elementos al menos 1 vez
         * 
         * ¿Qué pasa si el usuario pide coger más elementos de los que hay en la colección?
         * - Asumo que sólo cogerá los que tenga la lista (es decir, todos)
         */

        public static IEnumerable<T> Ejercicio10_P6<T>(IEnumerable<T> collection, int n)
        {
            if (n > collection.Count())
                return ElementosAleatoriosColeccionGenerador(collection).Take(collection.Count());
            return ElementosAleatoriosColeccionGenerador(collection).Take(n);
        }

        private static IEnumerable<T> ElementosAleatoriosColeccionGenerador<T>(IEnumerable<T> collection)
        {
            PrintInGreen("Entra en generador perezoso de elementos aleatorios de la colección");
            while (true)
                yield return ElementosAleatoriosColeccion<T>.RandomElement(collection);//Acordarse de especificar el <T>, sino error de compilación
        }

        internal class ElementosAleatoriosColeccion<T>
        {
            private static Dictionary<T, T> _cache = new();
            private static Random random = new();

            public static T RandomElement(IEnumerable<T> collection)
            {
                //Sacamos un elemento random de la colección y lo añadimos a la caché
                //Mientras el elemento generado esté en la caché, generamos otro elemento random
                var elem = collection.ElementAt(random.Next(0, collection.Count()));
                while (_cache.Keys.Contains(elem))
                {
                    elem = collection.ElementAt(random.Next(0, collection.Count()));
                }

                _cache.Add(elem, elem);
                return elem;
            }
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

        /// <summary>
        /// Método Find (no extensor)
        /// A partir de una colección de elementos, nos devuelve el primero que cumpla un criterio 
        /// dado o su valor por defecto en el caso de no existir ninguno.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="predicate"></param>
        /// <returns>Element found or its default</returns>

        public static T Ejercicio2_P7<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
                if (predicate(item))
                    return item;
            return default;
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

        public static void Ejercicio9_P8()
        {
            Console.WriteLine("---Ejercicio 9 P8---");
            //Los nombres de los empleados que pertenecen al departamento de “Computer Science”, tienen un despacho en la
            //“Faculty of Science” y han realizado al menos una llamada con duración superior a 1 minuto.
            var result = modelo.Employees.Where(e => e.Department.Name.ToLower().Equals("computer science")
                && e.Office.Building.ToLower().Equals("faculty of science") && modelo.PhoneCalls.Any(ll => ll.Seconds > 60)).Select(e => e.Name);

            Show(result);
        }

        public static void Ejercicio10_P8()
        {
            Console.WriteLine("---Ejercicio 10 P8---");
            //La suma en segundos de las llamadas cuyo número de origen es el de un empleado del departamento “Computer Science”.
            var result = modelo.PhoneCalls.Join(
                modelo.Employees.Where(e => e.Department.Name.ToLower().Equals("computer science")),
                ll => ll.SourceNumber,
                e => e.TelephoneNumber,
                (ll, e) => new
                {
                    Empleado = e,
                    Llamada = ll
                }
                ).Sum(a => a.Llamada.Seconds);

            PrintInGreen($"Total de segundos: {result}");
        }

        public static void Ejercicio11_P8()
        {
            Console.WriteLine("---Ejercicio 11 P8---");
            //Las llamadas de teléfono realizadas por cada departamento, ordenadas por nombre de departamento.
            //Cada línea debe tener el formato:
            //  Departamento=Nombre;Duración=Segundos
            //Solución 1 sin agrupar por departamentos (el enunciado no pone que haya que agrupar :/, pero lo hago más abajo igualmente)
            //var result = modelo.PhoneCalls.Join(
            //    modelo.Employees,
            //    ll => ll.SourceNumber,
            //    e => e.TelephoneNumber,
            //    (ll, e) => new
            //    {
            //        Departamento = e.Department.Name,
            //        Duracion = ll.Seconds
            //    }).OrderBy(a => a.Departamento).Select(a => $"Departamento={a.Departamento}; Duración={a.Duracion}");

            //Solución 2 agrupando por departamentos (yo creo que es la más natural que te salga)
            var result = modelo.Employees.GroupBy(
                d => d.Department.Name,
                (nombre, empleados) => new
                {
                    Nombre = nombre,
                    Duracion = empleados.Join(
                        modelo.PhoneCalls,
                        e => e.TelephoneNumber,
                        ll => ll.SourceNumber,
                        (e, ll) => ll
                        ).Sum(ll => ll.Seconds)
                }
                ).OrderBy(a => a.Nombre).Select(a => $"Departamento={a.Nombre};Duración={a.Duracion}");

            // Solución 3 (creo que es la más eficiente)
            //var result = modelo.Departments.Select(dep =>
            //    new
            //    {
            //        Nombre = dep.Name,
            //        Duracion = dep.Employees.SelectMany(e => modelo.PhoneCalls.Where(ll => ll.SourceNumber.Equals(e.TelephoneNumber))).Sum(ll => ll.Seconds)
            //    }
            //    ).OrderBy(a => a.Nombre).Select(a => $"Departamento={a.Nombre};Duración={a.Duracion}");

            Show(result);
        }

        public static void Ejercicio12_P8()
        {
            Console.WriteLine("---Ejercicio 12 P8---");
            //El nombre del departamento con el empleado más joven, junto con el nombre de éste y su edad.
            //Tened en cuenta que puede existir más de un resultado.

            var result = modelo.Employees.Where(e => e.Age.Equals(modelo.Employees.Min(e => e.Age)))
                .Select(e => $"{e.Department.Name} - {e.Name} - {e.Age}");

            Show(result);
        }

        public static void Ejercicio13_P8()
        {
            Console.WriteLine("---Ejercicio 13 P8---");
            //El nombre del departamento que tenga la mayor duración de llamadas telefónicas, sumando la duración
            //de las llamadas de todos los empleados que pertenecen al mismo. Puede asumirse que solamente un
            //departamento cumplirá esta condición.

            var result = modelo.Departments.Select(d => new
            {
                Departamento = d.Name,
                Duracion = d.Employees.SelectMany(e => modelo.PhoneCalls.Where(ll => ll.SourceNumber.Equals(e.TelephoneNumber))).Sum(ll => ll.Seconds)
            }
            ).OrderBy(a => a.Duracion).Select(a => a.Departamento).FirstOrDefault();

            PrintInGreen(result);
        }

        //--------------------------------------------------------------------------------------------------
        // -- A partir de aquí, pongo ejercicios extra que se me han ido ocurriendo relacionados con LinQ --
        //--------------------------------------------------------------------------------------------------
        public static void Ejercicio14_P8()
        {
            Console.WriteLine("---Ejercicio 14 P8---");
            //Mostrar el nombre de tres de los empleados (hay 4) más antiguos que aún trabajan en el departamento de
            //'Computer Science' o 'Medicine' y listarlos por fecha de nacimiento.

            var result = modelo.Employees.Where(e => e.Department.Name.ToLower().Equals("computer science") || e.Department.Name.ToLower().Equals("medicine"))
                .OrderBy(e => e.DateOfBirth).Select(e => $"{e.Name} {e.DateOfBirth}").Take(3);//si quitas el Take salen 4

            Show(result);
        }

        public static void Ejercicio15_P8()
        {
            Console.WriteLine("---Ejercicio 15 P8---");
            //Encontrar el(los) departamento(s) con el mayor número de empleados y mostrar el nombre
            //del departamento junto con el número de empleados.

            var max = modelo.Departments.Max(d => d.Employees.Count()); //si lo sacamos fuera, evitamos calcular por cada departamento el máximo
            var result = modelo.Departments.Where(d => d.Employees.Count() == max)
                .Select(d => $"{d.Name} {d.Employees.Count()}");

            Show(result);
        }

        public static void Ejercicio16_P8()
        {
            Console.WriteLine("---Ejercicio 16 P8---");
            //Obtener una lista de los números de teléfono que han recibido llamadas pero nunca han realizado una,
            //incluyendo el total de segundos recibidos.

            //Opción 1: la más natural
            var source = modelo.PhoneCalls.Select(ll => ll.SourceNumber).Distinct();
            var destination = modelo.PhoneCalls.Select(ll => ll.DestinationNumber).Distinct();
            var result = destination.Where(ll => !source.Contains(ll));

            //Opción 2: más eficiente
            var result2 = modelo.PhoneCalls.Select(ll => ll.SourceNumber).Except(modelo.PhoneCalls.Select(ll => ll.DestinationNumber));

            Show(result);
            Show(result2);
            PrintInGreen("No te rayes que no hay ningún número de tlfno que no llamase nunca. Prueba a añadirlo tú mismo. Por eso no ves resultados :^");
        }

        public static void Ejercicio17_P8()
        {
            Console.WriteLine("---Ejercicio 17 P8---");
            //Listar todos los empleados (por su nombre) que han hecho al menos una llamada de más de 20
            //segundos a otro empleado del mismo departamento.

            var result = modelo.Employees.Where(e =>
                modelo.PhoneCalls.Any(ll => ll.SourceNumber.Equals(e.TelephoneNumber) && ll.Seconds > 20 && modelo.Employees.Any(e2 =>
                    e2.Department.Equals(e.Department) && e2.TelephoneNumber.Equals(ll.DestinationNumber) && !e2.TelephoneNumber.Equals(ll.SourceNumber))))
                        .Select(e => e.Name);

            Show(result);

            PrintInGreen("No te rayes que no hay ningun empleado que llame a otro de su mismo departamento. Prueba a añadirlo tú mismo. Por eso no ves resultados :^");
        }

        public static void Ejercicio18_P8()
        {
            Console.WriteLine("---Ejercicio 18 P8---");
            //Calcular el promedio de duración de las llamadas realizadas por cada empleado, mostrando solo aquellos empleados
            //con un promedio superior a 10 segundos. Ordenar los resultados por el promedio de duración de forma descendente.

            var result = modelo.Employees.Join(modelo.PhoneCalls, // Unir con PhoneCalls
              employee => employee.TelephoneNumber, // Clave primaria de Employee
              phoneCall => phoneCall.SourceNumber, // Clave foránea en PhoneCalls
              (employee, phoneCall) => new { Employee = employee, PhoneCall = phoneCall }) // Seleccionar ambos en un tipo anónimo
                .Where(x => x.PhoneCall.Seconds > 10) // Filtrar llamadas de más de 10 segundos
                .GroupBy(x => x.Employee) // Agrupar por empleado
                .Select(group => new
                {
                    EmployeeName = group.Key.Name,
                    AverageDuration = group.Average(x => x.PhoneCall.Seconds) // Calcular el promedio de duración
                })
                .Where(x => x.AverageDuration > 10) // Filtrar empleados con promedio de duración mayor a 10
                .OrderByDescending(x => x.AverageDuration) // Ordenar por promedio descendente
                .Select(a => $"{a.EmployeeName}: {a.AverageDuration} segs");

            Show(result);
        }

        public static void Ejercicio19_P8()
        {
            Console.WriteLine("---Ejercicio 19 P8---");
            //Identificar el día con mayor número de llamadas realizadas y mostrar la fecha junto con el número de llamadas.

            var result = modelo.PhoneCalls.GroupBy(ll => ll.Date.Day).Select(grupo => new
            {
                Day = grupo.Key,
                Llamadas = grupo.Count()
            }
            ).OrderByDescending(a => a.Llamadas).First();

            PrintInGreen(result);
        }

        public static void Ejercicio20_P8()
        {
            Console.WriteLine("---Ejercicio 20 P8---");
            //Para cada oficina, encontrar el empleado más joven y listar el nombre de la oficina
            //junto con el nombre completo del empleado y su fecha de nacimiento.

            var result = modelo.Employees.GroupBy(e => e.Office).Select(grupo => new
            {
                Oficina = grupo.Key,
                Empleado = modelo.Employees.Where(e => e.Office.Equals(grupo.Key)).OrderBy(e => e.Age).FirstOrDefault()
            }).Select(a => $"{a.Oficina.Building}: {a.Empleado.Name} {a.Empleado.Surname} {a.Empleado.Age} {a.Empleado.DateOfBirth}");

            Show(result);
        }

        public static void Ejercicio21_P8()
        {
            Console.WriteLine("---Ejercicio 21 P8---");
            //Crear un listado de todos los empleados que no han realizado ni recibido ninguna llamada telefónica.

            var empleadosQueLlaman = modelo.Employees.Join(
                modelo.PhoneCalls,
                e => e.TelephoneNumber,
                ll => ll.SourceNumber,
                (e, ll) => e).Distinct();

            var empleadosQueReciben = modelo.Employees.Join(
                modelo.PhoneCalls,
                e => e.TelephoneNumber,
                ll => ll.DestinationNumber,
                (e, ll) => e).Distinct();

            var empleadosConLlamadas = empleadosQueLlaman.Union(empleadosQueReciben).Select(e => e.TelephoneNumber);

            var result = modelo.Employees.Where(e => !empleadosConLlamadas.Contains(e.TelephoneNumber)).Select(e => e.Name);

            Show(result);
        }

        public static void Ejercicio22_P8()
        {
            Console.WriteLine("---Ejercicio 22 P8---");
            //Obtener el nombre del empleado que ha gastado la mayor cantidad total de segundos
            //en llamadas telefónicas, junto con el tiempo total gastado en llamadas.

            var empleadosQueLlaman = modelo.Employees.Join(
                modelo.PhoneCalls,
                e => e.TelephoneNumber,
                ll => ll.SourceNumber,
                (e, ll) => new { Empleado = e, Llamada = ll }
                );

            var empleadosQueReciben = modelo.Employees.Join(
                modelo.PhoneCalls,
                e => e.TelephoneNumber,
                ll => ll.DestinationNumber,
                (e, ll) => new { Empleado = e, Llamada = ll }
                );

            var empleadosConLlamadas = empleadosQueLlaman.Union(empleadosQueReciben).GroupBy(a => a.Empleado)
                .Select(grupo => new
                {
                    Empleado = grupo.Key.Name,
                    Duracion = grupo.Sum(a => a.Llamada.Seconds) // grupo.Aggregate(0, (acu, a) => acu + a.Llamada.Seconds)
                }).OrderByDescending(a => a.Duracion).FirstOrDefault();

            PrintInGreen(empleadosConLlamadas);
        }

        public static void Ejercicio23_P8()
        {
            Console.WriteLine("---Ejercicio 23 P8---");
            //Listar los departamentos cuyos empleados en conjunto han realizado llamadas (las han comenzado ellos)
            //de un total acumulado de más de 40 segundos, incluyendo el nombre del departamento y el tiempo total de llamadas.

            var result = modelo.Employees.Join(
                modelo.PhoneCalls,
                e => e.TelephoneNumber,
                ll => ll.SourceNumber,
                (e, ll) => new { Empleado = e, Llamada = ll }
                ).GroupBy(a => a.Empleado.Department).Select(grupo => new
                {
                    Departamento = grupo.Key.Name,
                    TotalLlamadas = grupo.Sum(a => a.Llamada.Seconds)
                }
                ).Where(a => a.TotalLlamadas > 40).Select(a => $"{a.Departamento}, con un total de {a.TotalLlamadas} segundos");

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
