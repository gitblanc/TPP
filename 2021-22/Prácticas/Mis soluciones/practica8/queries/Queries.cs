using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab08
{

    class Query
    {

        private Model model = new Model();

        private static void Show<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Number of items in the collection: {0}.", collection.Count());
        }

        static void Main(string[] args)
        {
            Query query = new Query();
            //query.Query1();
            //query.Query2();
            //query.Query2b();
            //query.Query3();
            //query.Query4();
            //query.Query4b();
            //query.Query5();
            //query.Query6();
            //query.Homework1();
            //query.Homework2();
            //query.Homework2b();
            //query.Homework2c();
            //query.Homework3();
            //query.Homework3b();
            //query.Homework3c();
            //query.Homework4();
            //query.Homework4b();

        }

        private void Query1()
        {
            //// Modify this query to show the names of the employees older than 50 years
            var employees = model.Employees
                .Where(x => x.Age > 50)
                .Select(x => x.Name);
            Show(employees);

        }

        private void Query2()
        {//con tipos anónimos
            // Show the name and email of the employees who work in Asturias
            var employees = model.Employees
                .Where(x => x.Province.ToLower().Equals("asturias"))
                .Select(x => new
                {
                    name = x.Name,
                    email = x.Email,
                });
            Show(employees);
        }
        private void Query2b()//con tuplas
        {//con tipos anónimos
            // Show the name and email of the employees who work in Asturias
            var employees = model.Employees
                .Where(x => x.Province.ToLower().Equals("asturias"))
                .Select(x => (x.Name, x.Email));
            Show(employees);
        }



        // Notice: from now on, check out http://msdn.microsoft.com/en-us/library/9eekhta0.aspx

        private void Query3()
        {
            // Show the names of the departments with more than one employee 18 years old and beyond; 
            // the department should also have any office number starting with "2.1"
            var departments = model.Departments
                .Where(d => d.Employees.Count(e => e.Age >= 18) > 1)
                .Where(d => d.Employees.Any(e => e.Office.Number.StartsWith("2.1")))
                .Select(d => d.Name);
            Show(departments);
        }

        private void Query4()//tipado anónimo
        {
            // Show the phone calls of each employee. 
            // Each line should show the name of the employee and the phone call duration in seconds.
            var calls = model.PhoneCalls
                .Where(p => model.Employees.Any(e => e.TelephoneNumber.Equals(p.SourceNumber)))
                .Select(x => new
                {
                    employee = model.Employees.First(e => e.TelephoneNumber.Equals(x.SourceNumber)).Name,
                    date = x.Seconds
                });
            Console.WriteLine("Calls: ");
            Show(calls);
        }

        private void Query4b()//con tuplas
        {//tipado anónimo
            // Show the phone calls of each employee. 
            // Each line should show the name of the employee and the phone call duration in seconds.
            var calls = model.PhoneCalls
                .Where(p => model.Employees.Any(e => e.TelephoneNumber.Equals(p.SourceNumber)))
                .Select(x => (model.Employees.First(e => e.TelephoneNumber.Equals(x.SourceNumber)).Name, $"{x.Seconds} s"));
            Console.WriteLine("Calls: ");
            Show(calls);
        }

        private void Query5()
        {
            // Show, grouped by each province, the name of the employees 
            // (both province and employees must be lexicographically ordered)
            var employees = model.Employees
                .OrderBy(e => e.Name)
                .GroupBy(e => e.Province)
                .OrderBy(p => p.Key);
            Console.WriteLine("Employees by province: ");
            foreach (var province in employees)
            {
                Console.WriteLine(province.Key);
                foreach (var empl in province)
                {
                    Console.WriteLine($"\t{empl.Name}");
                }
            }

        }

        private void Query6()
        {
            //Mostrar las llamadas ordenadas por duración y ranking(La de más duración la primera)
            var calls = model.PhoneCalls
                .OrderByDescending(c => c.Seconds)
                .Zip(Enumerable.Range(1, model.PhoneCalls.Count() + 1),
                (c, i) => $"Rank: {i} - seconds: {c.Seconds} - from-to -> {c.SourceNumber} - {c.DestinationNumber}");
            Show(calls);

        }

        /************ Homework **********************************/

        private void Homework1()
        {
            // Show, ordered by age, the names of the employees in the Computer Science department, 
            // who have an office in the Faculty of Science, 
            // and who have done phone calls longer than one minute

            var employees = model.Employees
                .Where(e => e.Department.Name.ToLower().Equals("computer science"))
                .Where(e => e.Office.Building.ToLower().Equals("faculty of science"))
                .Where(e => model.PhoneCalls.Any(c => c.SourceNumber.Equals(e.TelephoneNumber) && c.Seconds > 60))
                .OrderByDescending(e => e.Age)
                .Select(e => $"{e.Name}");
            Show(employees);

        }

        private void Homework2()//tipado anónimo
        {
            // Show the summation, in seconds, of the phone calls done by the employees of the Computer Science department
            var suma = model.Employees
                .Where(e => e.Department.Name.ToLower().Equals("computer science"))
                .Where(e => model.PhoneCalls.Any(c => c.SourceNumber.Equals(e.TelephoneNumber)))
                .Select(e => new
                {
                    sumaTotal = model.PhoneCalls.Where(c => c.SourceNumber.Equals(e.TelephoneNumber))
                                                .Sum(c => c.Seconds)

                });
            Show(suma);
        }

        private void Homework2b()//tupla
        {
            // Show the summation, in seconds, of the phone calls done by the employees of the Computer Science department
            var suma = model.Employees
                .Where(e => e.Department.Name.ToLower().Equals("computer science"))
                .Where(e => model.PhoneCalls.Any(c => c.SourceNumber.Equals(e.TelephoneNumber)))
                .Select(e => (model.PhoneCalls.Where(c => c.SourceNumber.Equals(e.TelephoneNumber))
                                                .Sum(c => c.Seconds), " s"));
            Show(suma);
        }
        private void Homework2c()//normal
        {
            // Show the summation, in seconds, of the phone calls done by the employees of the Computer Science department
            var suma = model.PhoneCalls
                     .Where(c => model.Employees.Where(e => e.Department.Name.ToLower().Equals("computer science"))
                     .Any(e => e.TelephoneNumber.Equals(c.SourceNumber)))
                     .Aggregate(0, (a, b) => a + b.Seconds);
            Console.WriteLine($"Total: {suma}");

        }

        private void Homework3()//tipado dinámico
        {
            // Show the phone calls done by each department, ordered by department names. 
            // Each line must show “Department = <Name>, Duration = <Seconds>”

            var calls = model.Employees
                .OrderBy(e => e.Department.Name)
                .Select(e => new
                {
                    Departamento = e.Department.Name,
                    Duration = model.PhoneCalls.Where(c => c.SourceNumber.Equals(e.TelephoneNumber))
                                               .Sum(c => c.Seconds)
                });
            Show(calls);
        }

        private void Homework3b()//normal
        {
            // Show the phone calls done by each department, ordered by department names. 
            // Each line must show “Department = <Name>, Duration = <Seconds>”

            var calls = model.Departments
                .OrderBy(d => d.Name)
                .Select(d => $"Department = {d.Name}, Duration = " + d.Employees
                            .SelectMany(e => model.PhoneCalls.Where(c => c.SourceNumber.Equals(e.TelephoneNumber)))
                            .Sum(c => c.Seconds)
                            );
            Show(calls);
        }

        private void Homework3c()//normal y aggregate
        {
            // Show the phone calls done by each department, ordered by department names. 
            // Each line must show “Department = <Name>, Duration = <Seconds>”

            var calls = model.Departments
                .OrderBy(d => d.Name)
                .Select(d => $"Department = {d.Name}, Duration = " + d.Employees
                            .SelectMany(e => model.PhoneCalls.Where(c => c.SourceNumber.Equals(e.TelephoneNumber)))
                            .Aggregate(0, (a,b) => a + b.Seconds)
                            );
            Show(calls);
        }

        private void Homework4()//normal
        {
            //Show the departments with the youngest employee, 
            // together with the name of the youngest employee and his/ her age
            //  (more than one youngest employee may exist)
            var deps = model.Departments
                .OrderBy(d => d.Name)
                .Select(d => $"Department: {d.Name}, Youngest employee: " + d.Employees
                               .Where(e => e.Age.Equals(d.Employees.Select(e => e.Age).Min()))
                                          .Select(e => $"{e.Name} {e.Age}")
                                          .First()
                );
            Show(deps);
        }

        private void Homework4b()//con tipado
        {
            // Show the departments with the youngest employee, 
            // together with the name of the youngest employee and his/her age 
            // (more than one youngest employee may exist)
            var deps = model.Employees
                .GroupBy(e => e.Department.Name, (d, e) => new
                {
                    DepName = d,
                    Empl = e,
                    MinAge = e.Select(e => e.Age).Min()
                }).Select(d => $"Department: {d.DepName}, Youngest employee: {d.Empl.First(e => e.Age.Equals(d.MinAge)).Name}" +
                $"  {d.MinAge}");
            Show(deps);
        }

        private void Homework5()
        {
            // Show the greatest summation of phone call durations, in seconds, 
            // of the employees in the same department, together with the name of the department 
            // (it can be assumed that there is only one department fulfilling that condition)

            var departments = model.Employees.Join(
                model.PhoneCalls, e => e.TelephoneNumber, c => c.SourceNumber,
                (e, c) => new
                {
                    Department = e.Department.Name,
                    Duration = c.Seconds,
                }
                ).GroupBy(
                    e => e.Department,
                    (dep, calls) => new
                    {
                        Department = dep,
                        CallsDuration = calls.Aggregate(0, (a, b) => a + b.Duration),
                    }
                );
            var departmentsAndDuration = departments.FirstOrDefault(d => d.CallsDuration == departments.Max(d => d.CallsDuration));
            Console.WriteLine($"Department = {departmentsAndDuration.Department}, Duration = {departmentsAndDuration.CallsDuration} s");
        }


    }

}
