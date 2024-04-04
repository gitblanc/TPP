using System;

// Colecciones genéricas.
using System.Collections.Generic;
// LINQ
using System.Linq;

using Modelo;

namespace Linq
{
    class Program
    {

        private static Model modelo = new Model();

        static void Main()
        {
            SintaxisLinq();
            EjemploJoin();
            EjemploGroupBy();

            /*
             Consulta1();
             Consulta2();
             Consulta3();
             Consulta4();
             Consulta5();
             Consulta6();
             Consulta7();
             */

        }

        private static void SintaxisLinq()
        {
            //Obtener las llamadas de más de 15 segundos de duración


            //Sintaxis de consulta (Esta sintaxis es una mierda
            var c1 =
                from pc in modelo.PhoneCalls
                where pc.Seconds > 15
                select pc;//fijarse que el select está al final
            Show(c1);

            Console.WriteLine();

            //Equivalente con sintaxis de métodos.
            //¡OJO! SE DEFINE LA CONSULTA. NO SE EJECUTA. ¿POR QUÉ?
            var c1_m = modelo.PhoneCalls.Where(ll => ll.Seconds > 15);
            //¿Qué ocurre si la consulta anterior la finalizamos con un .ToList()?

            Show(c1_m);
            Limpiar();
        }

        private static void EjemploJoin()
        {
            //JOIN
            //Mostrar las llamadas de cada empleado con el formato: "<Nombre>;<Duración de la llamada>"

            //El método Join, une dos colecciones a partir de un atributo común:
            //Lo utilizamos sobre un IEnumerable (modelo.PhoneCalls)
            var result = modelo.PhoneCalls.Join(

                modelo.Employees, //para unir sus elementos con los de un segundo IEnumerable (modelo.Employees)

                llamada => llamada.SourceNumber, //Atributo clave del primer IEnumerable (PhoneCalls)

                emp => emp.TelephoneNumber, //Atributo clave del 2º IEnumerable (Employees)

                (llamada, emp) => $"{emp.Name};{llamada.Seconds}" // Función que recibe y trata cada par de llamada-empleado de claves coincidentes.
            );

            Show(result);
            Limpiar();
        }


        private static void EjemploGroupBy()
        {
            //GROUP BY (estructura ideal para el goupby -> diccionario)
            //Esto es un 0 en el examen (no es funcional)
            //GroupBy: Vamos a mostrar la duración de las llamadas agrupadas por número de teléfono (origen)

            var llamadas = modelo.PhoneCalls;
            var resultado = llamadas.GroupBy(ll => ll.SourceNumber);

            //resultado ahora mismo es un  IEnumerable<IGrouping>
            Console.WriteLine("Imprimiendo directamente:");
            Show(resultado);

            //Un grupo es una entrada de un Dictionary (la key con el value)
            Console.WriteLine("\nImprimiendo mediante recorrido:");
            foreach (var grupo in resultado)//iteras las keys
            {
                //Cada IGrouping tiene una Key:
                Console.Write("\nClave [" + grupo.Key + "] : ");
                //Y tenemos un listado. En este caso, de llamadas:
                foreach (var llamada in grupo)//iteras los values
                {
                    Console.Write(llamada.Seconds + " ");
                }
            }

            //Sin embargo GroupBy nos presenta otras opciones, vamos a combinar éstas
            //con los objetos anónimos:

            var opcion2 = llamadas.GroupBy(
                ll => ll.SourceNumber, //Agrupamos por número de origen

                //el primer parámetro es el número de origen (clave)
                //el segundo parámetro es un IEnumerable<PhoneCall> asociados a esa clave.
                (numero, llamadasEncontradas) =>// numero hace referencia a la Key y las llamadas Encontradas son el Value (grupo, valor)
                new //Vamos emplear una función que cree objetos anónimos con la info que necesitamos
                {
                    Key = numero,
                    //Duraciones sigue siendo un IEnumerable.
                    //Duraciones = llamadasEncontradas.Select(ll => ll.Seconds) //De esta forma la consola devuelve una lista de llamadas y no fufa
                    Duraciones = llamadasEncontradas.Select(ll => ll.Seconds).Aggregate("", (acumulated, actual) => $"{acumulated}, {actual}")//Ahora se devuelve un string por pantalla
                    //Con esta forma no podemos usar el resto de atributos de una llamada
                }
                );

            Console.WriteLine("\n\nImprimiendo directamente:");
            Show(opcion2);
            Console.WriteLine("\nImprimiendo con el Aggregate:");
            var conAggregate = opcion2.Select(a => $"{a.Key} : {a.Duraciones.Aggregate("", (acumulado, actual) => $"{acumulado} {actual}")}");
            //¿Podríamos hacer el Aggregate directamente en el objeto anónimo?
            Show(conAggregate);
            Limpiar();

            Console.WriteLine("----------Mis consultas------------");
            Consulta1();
            Consulta2();
            Consulta3();
            Consulta4();
            Consulta5();
            Consulta6();
            Consulta7();
            ConsultaExamen();
        }

        private static void Consulta1()
        {
            // Modificar la consulta para mostrar los empleados cuyo nombre empieza por F.
            //var resultado = modelo.Employees;
            var resultado = modelo.Employees.Where(e => e.Name.StartsWith('F'));
            var resultado2 = modelo.Employees.Where(e => e.Name.StartsWith('F')).Select(e => e.Name);

            Show(resultado);
            Show(resultado2);
            //El resultado esperado es: Felipe
        }

        private static void Consulta2()
        {

            //Mostrar Nombre y fecha de nacimiento de los empleados de Cantabria con el formato:
            // Nombre=<Nombre>,Fecha=<Fecha>

            var resultado = modelo.Employees.Where(e => e.Province.ToLower().Equals("cantabria")).Select(e => $"{e.Name} {e.DateOfBirth}");

            Show(resultado);
            /*El resultado esperado es:
              Alvaro 19/10/1945 0:00:00
              Dario 16/12/1973 0:00:0066
            */
        }



        // A partir de aquí, necesitaréis métodos presentes en: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable?view=net-5.0

        private static void Consulta3()//DIFICIL
        {

            //Mostrar los nombres de los departamentos que tengan más de un empleado mayor de edad.

            //var result = modelo.Departments.Where(d => d.Employees.Any(e => e.Age >= 18)).Select(d => d.Name);
            var result = modelo.Departments.Where(d => d.Employees.Count(e => e.Age >= 18) > 1).Select(e => e.Name);
            Show(result);

            /*El resultado esperado es:
                Computer Science
                Medicine
            */


            //Posteriormente, cree una nueva versión de la consulta para que:
            //Muestre los nombres de los departamentos que tengan más de un empleado mayor de edad
            //y
            //que el despacho (Office.Number) COMIENCE por "2.1"

            var result2 = modelo.Departments.Where(d => d.Employees.Count(e => e.Age >= 18 && e.Office.Number.StartsWith("2.1")) > 1).Select(e => e.Name);
            Show(result2);
            //El resultado esperado es: Medicine
        }

        private static void Consulta4()//DIFICIL
        {

            //El nombre de los departamentos donde ningún empleado tenga despacho en el Building "Faculty of Science".
            var result = modelo.Departments.Where(d => d.Employees.Count(e => e.Office.Building.ToLower().Equals("faculty of science")) == 0).Select(d => d.Name);
            Show(result);
            //Resultado esperado: [Department: Mathematics]
        }

        private static void Consulta5()
        {
            // Mostrar las llamadas de teléfono de más de 5 segundos de duración para cada empleado que tenga más de 50 años
            //Cada línea debería mostrar el nombre del empleado y la duración de la llamada en segundos.
            //El resultado debe estar ordenado por duración de las llamadas (de más a menos).
            var result = modelo.PhoneCalls.Where(ll => ll.Seconds > 5).Join(
                modelo.Employees.Where(e => e.Age > 50), //para empleados de más de 50 años

                ll => ll.SourceNumber, //Atributo clave del primer IEnumerable (PhoneCalls)

                emp => emp.TelephoneNumber, //Atributo clave del 2º IEnumerable (Employees)

                (llamada, emp) => //$"Nombre= {emp.Name}, Duracion = {llamada.Seconds}" // Función que recibe y trata cada par de llamada-empleado de claves coincidentes.
                new
                {
                    Nombre = emp.Name,
                    Duracion = llamada.Seconds
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



        private static void Consulta6()
        {
            Console.WriteLine("Consulta 6");
            //Mostrar la llamada realizada más larga para cada empleado, mostrando por pantalla: Nombre_empleado : duracion_llamada_mas_larga
            // Con esta forma hay elementos nulos (porque hay llamadas que no corresponden a un empleado)
            //var result = modelo.PhoneCalls.GroupBy(
            //    ll => ll.SourceNumber,
            //    (numero, llamadasEncontradas) =>
            //    new
            //    {
            //        Nombre = modelo.Employees.Where(e => e.TelephoneNumber.Equals(numero)).Select(e => e.Name).FirstOrDefault(),
            //        Duracion = llamadasEncontradas.Select(ll => ll.Seconds).Max()
            //    }
            //    ).Where(a => !string.IsNullOrEmpty(a.Nombre))
            //    .Select(a => $"Nombre = {a.Nombre}, Maxima = {a.Duracion}");
            //// Agrupando por el nombre es confiar en el modelo
            //var result = modelo.PhoneCalls.Join(
            //    modelo.Employees,
            //    ll => ll.SourceNumber,
            //    e => e.TelephoneNumber,
            //    (ll, e) =>
            //    new
            //    {
            //        Empleado = e,
            //        Llamada = ll
            //    }
            //    ).GroupBy(a => a.Empleado.Name)
            //    .Select(grupo => new
            //    {
            //        Nombre = grupo.Key,
            //        Duracion = grupo.Max(a => a.Llamada.Seconds)
            //    });
            // Es mejor agrupar por el empleado y que decida el Equals
            var result = modelo.PhoneCalls.Join(
                modelo.Employees,
                ll => ll.SourceNumber,
                e => e.TelephoneNumber,
                (ll, e) =>
                new
                {
                    Empleado = e,
                    Llamada = ll
                }
                ).GroupBy(a => a.Empleado)
                .Select(grupo => new
                {
                    Nombre = grupo.Key.Name,
                    Duracion = grupo.Max(a => a.Llamada.Seconds)
                });


            Show(result);
            /* ¡OJO NO ESTÁ APLICADO EL FORMATO 
                { Nombre = Alvaro, Maxima = 15 }
                { Nombre = Bernardo, Maxima = 63 }
                { Nombre = Eduardo, Maxima = 23 }
                { Nombre = Felipe, Maxima = 7 }
             */
        }


        private static void Consulta7()
        {
            // Mostrar, agrupados por provincia, el nombre de los empleados
            //Tanto la provincia como los empleados de cada provicia seguirán un orden alfabético.
            Console.WriteLine("Consulta 7");
            var result = modelo.Employees.GroupBy(
                pr => pr.Province,
                (provincia, empleadosProvinciales) =>
                new
                {
                    Provincia = provincia,
                    Empleados = empleadosProvinciales.OrderBy(e => e.Name).Aggregate("", (acu, actual) => $"{acu} {actual.Name}")
                }
                ).OrderBy(a => a.Provincia).Select(a => $"{a.Provincia} :{a.Empleados}");

            Show(result);
            /*Resultado esperado:
                Alicante : Carlos
                Asturias : Bernardo Felipe
                Cantabria : Alvaro Dario               
                Granada : Eduardo

            */
        }

        private static void ConsultaExamen()
        {
            //Consulta examen Lunes
            //Nombre y edad de los empleados que estén por debajo de la media de edad
            var sumaEdades = modelo.Employees.Aggregate(0, (acumulated, e) => acumulated + e.Age);
            var media = sumaEdades / modelo.Employees.Count();
            var result = modelo.Employees.Where(e => e.Age < media).Select(e => $"{e.Name} {e.Surname}");

            //También se podría mirar con el Average

            Show(result);
        }

        public static void Consulta8()
        {
            Console.WriteLine("---Consulta8---");
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
            //"No te rayes que no hay ningún número de tlfno que no llamase nunca. Prueba a añadirlo tú mismo. Por eso no ves resultados
        }

        public static void Consulta9()
        {
            Console.WriteLine("---Consulta9---");
            //Listar todos los empleados (por su nombre) que han hecho al menos una llamada de más de 20
            //segundos a otro empleado del mismo departamento.

            var result = modelo.Employees.Where(e =>
                modelo.PhoneCalls.Any(ll => ll.SourceNumber.Equals(e.TelephoneNumber) && ll.Seconds > 20 && modelo.Employees.Any(e2 =>
                    e2.Department.Equals(e.Department) && e2.TelephoneNumber.Equals(ll.DestinationNumber) && !e2.TelephoneNumber.Equals(ll.SourceNumber))))
                        .Select(e => e.Name);

            Show(result);

            //"No te rayes que no hay ningun empleado que llame a otro de su mismo departamento. Prueba a añadirlo tú mismo. Por eso no ves resultados
        }

        public static void Consulta10()
        {
            Console.WriteLine("---Consulta10---");
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

        public static void Consulta11()
        {
            Console.WriteLine("---Consulta11---");
            //Identificar el día con mayor número de llamadas realizadas y mostrar la fecha junto con el número de llamadas.

            var result = modelo.PhoneCalls.GroupBy(ll => ll.Date.Day).Select(grupo => new
            {
                Day = grupo.Key,
                Llamadas = grupo.Count()
            }
            ).OrderByDescending(a => a.Llamadas).First();

            PrintInGreen(result);
        }

        public static void Consulta12()
        {
            Console.WriteLine("---Consulta12---");
            //Para cada oficina, encontrar el empleado más joven y listar el nombre de la oficina
            //junto con el nombre completo del empleado y su fecha de nacimiento.

            var result = modelo.Employees.GroupBy(e => e.Office).Select(grupo => new
            {
                Oficina = grupo.Key,
                Empleado = modelo.Employees.Where(e => e.Office.Equals(grupo.Key)).OrderBy(e => e.Age).FirstOrDefault()
            }).Select(a => $"{a.Oficina.Building}: {a.Empleado.Name} {a.Empleado.Surname} {a.Empleado.Age} {a.Empleado.DateOfBirth}");

            Show(result);
        }

        public static void Consulta13()
        {
            Console.WriteLine("---Consulta13---");
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

        public static void Consulta14()
        {
            Console.WriteLine("---Consulta14---");
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


        private static void Show<T>(IEnumerable<T> colección)
        {
            foreach (var item in colección)
            {
                PrintInGreen(item);
            }
            Console.WriteLine("Elementos en la colección: {0}.", colección.Count());
        }

        private static void Limpiar()
        {
            Console.WriteLine("Pulse una tecla para continuar la ejecución...");
            Console.ReadKey();
            Console.Clear();
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
