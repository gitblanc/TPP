using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using ModeloClases;

namespace ModeloClases
{
    public static class LinqQueries
    {
        private static Model modelo = new Model();

        public static void Consulta1()
        {
            // Los nombres de los empleados que pertenecen al departamento de “Computer Science”,
            // tienen un despacho en la “Faculty of Science” y han realizado al menos una llamada
            // con duración superior a 1 minuto.

            PrintInRed("--------Consulta 1--------");

            var result = modelo.Employees.Where(e => e.Department.Name.ToLower().Equals("computer science")
                && e.Office.Building.ToLower().Equals("faculty of science")
                && modelo.PhoneCalls.Any(ll => ll.SourceNumber.Equals(e.TelephoneNumber) && ll.Seconds > 60))
                .Select(e => e.Name);

            Show(result);
        }

        public static void Consulta2()
        {
            // La suma en segundos de las llamadas cuyo número de origen es el de un
            // empleado del departamento “Computer Science”.

            PrintInRed("--------Consulta 2--------");

            //Forma 1
            var result1 = modelo.PhoneCalls.Join(
                modelo.Employees.Where(e => e.Department.Name.ToLower().Equals("computer science")),
                ll => ll.SourceNumber,
                e => e.TelephoneNumber,
                (ll, e) => ll
                ).Aggregate(0, (acu, actual) => acu + actual.Seconds);

            //Forma 2 (Es la que más me gusta)
            var empleado = modelo.Employees.Where(e => e.Department.Name.ToLower().Equals("computer science")).First();
            var result2 = modelo.PhoneCalls.Where(ll => ll.SourceNumber.Equals(empleado.TelephoneNumber))
                .Aggregate(0, (acu, actual) => acu + actual.Seconds);

            //Forma 3
            var numerosTelefonoCS = modelo.Employees
            .Where(e => e.Department.Name == "Computer Science")
            .Select(e => e.TelephoneNumber)
            .ToList();

            var result3 = modelo.PhoneCalls
                .Where(pc => numerosTelefonoCS.Contains(pc.SourceNumber))
                .Sum(pc => pc.Seconds);

            PrintInGreen(result1);
            PrintInGreen(result2);
            PrintInGreen(result3);
            PrintInRed("-------Fin consulta-------");
        }

        public static void Consulta3()
        {
            // Las llamadas de teléfono realizadas por cada departamento, ordenadas por
            // nombre de departamento. Cada línea debe tener el formato:
            //
            //      Departamento = Nombre; Duración = Segundos

            PrintInRed("--------Consulta 3--------");

            var result = modelo.Departments.Select(dep =>
                new
                {
                    Nombre = dep.Name,
                    LLamadas = dep.Employees.SelectMany(e => modelo.PhoneCalls.Where(ll => ll.SourceNumber.Equals(e.TelephoneNumber))).Sum(ll => ll.Seconds)
                }
                ).OrderBy(a => a.Nombre);

            Show(result);
        }

        public static void Consulta4()
        {
            // El nombre del departamento con el empleado más joven, junto
            // con el nombre de éste y su edad. Tened en cuenta que puede
            // existir más de un resultado.

            PrintInRed("--------Consulta 4--------");

            var result = modelo.Departments.Select(dep =>
                new
                {
                    Nombre = dep.Name,
                    Empleado = dep.Employees.OrderBy(e => e.Age).Select(e => $"{e.Name}, {e.Age}" // o -> dep.Employees.OrderByDescending(e => e.DateOfBirth).Select(e => $"{e.Name}, {e.Age}"
                    //new
                    //{
                    //    Nombre = e.Name,
                    //    Edad = e.Age
                    //}
                    ).FirstOrDefault()
                }
            ).Select(a => $"{a.Nombre}: {a.Empleado}");

            Show(result);
        }

        public static void Consulta5()
        {
            // El nombre del departamento que tenga la mayor duración de llamadas telefónicas,
            // sumando la duración de las llamadas de todos los empleados que pertenecen al mismo.
            // Puede asumirse que solamente un departamento cumplirá esta condición.

            PrintInRed("--------Consulta 5--------");

            var result = modelo.Departments.Select(dep =>
                new
                {
                    Nombre = dep.Name,
                    LLamadas = dep.Employees.SelectMany(e => modelo.PhoneCalls
                    .Where(ll => ll.SourceNumber.Equals(e.TelephoneNumber)))
                    .Sum(ll => ll.Seconds)
                }
                )
                .OrderByDescending(a => a.LLamadas).Select(a => a.Nombre).FirstOrDefault();
            //.Select(a => $"{a.Nombre} {a.LLamadas}"); // <---- Para saber el total de las llamadas de cada departamento

            //Show(result);
            PrintInGreen(result);
        }

        private static void Show<T>(IEnumerable<T> colección)
        {
            foreach (var item in colección)
            {
                PrintInGreen(item);
            }
            Console.WriteLine("Elementos en la colección: {0}.", colección.Count());
            PrintInRed("-------Fin consulta-------");
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
