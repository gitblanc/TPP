using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cosasDeClase
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
            Console.WriteLine("---------------------------------");
        }

        static void Main(string[] args)
        {
            Query query = new Query();
            query.Query1();
            query.Query2();
            query.Query2b();
            query.Query3();
            query.Query4();
            query.Query4b();
            query.Query5();
            query.Query6();
            query.Homework1();
            query.Homework2();
            query.Homework2b();
            query.Homework2c();
            query.Homework3();
            query.Homework3b();
            query.Homework3c();
            query.Homework4();
            query.Homework4b();

        }

        private void Query1()
        {
            //// Modify this query to show the names of the employees older than 50 years
            var employees = model.Employees
                                 .Where(e => e.Age > 50)
                                 .Select(e => e.Name);
            Show(employees);
        }

        private void Query2()
        {//con tipos anónimos
            // Show the name and email of the employees who work in Asturias
            var employees = model.Employees
                                 .Where(e => e.Province.ToLower().Equals("asturias"))
                                 .Select(e => new
                                 {
                                     Name = e.Name,
                                     Email = e.Email
                                 });
            Show(employees);
        }
        private void Query2b()//con tuplas
        {//con tipos anónimos
         // Show the name and email of the employees who work in Asturias
            var employees = model.Employees
                                 .Where(e => e.Province.ToLower().Equals("asturias"))
                                 .Select(e => ($"Name: {e.Name}", $"Email: {e.Email}"));
            Show(employees);
        }



        // Notice: from now on, check out http://msdn.microsoft.com/en-us/library/9eekhta0.aspx

        private void Query3()
        {
            // Show the names of the departments with more than one employee 18 years old and beyond; 
            // the department should also have any office number starting with "2.1"
            var deps = model.Departments
                            .Where(d => d.Employees.Count(e => e.Age >= 18) > 1)
                            .Where(d => d.Employees.Any(e => e.Office.Number.StartsWith("2.1")))
                            .Select(d => d.Name);
            Show(deps);
        }

        private void Query4()//tipado anónimo
        {
            // Show the phone calls of each employee. 
            // Each line should show the name of the employee and the phone call duration in seconds.
            
        }

        private void Query4b()//con tuplas
        {//tipado anónimo
         // Show the phone calls of each employee. 
         // Each line should show the name of the employee and the phone call duration in seconds.

        }

        private void Query5()
        {
            // Show, grouped by each province, the name of the employees 
            // (both province and employees must be lexicographically ordered)


        }

        private void Query6()
        {
            //Mostrar las llamadas ordenadas por duración y ranking(La de más duración la primera)


        }

        /************ Homework **********************************/

        private void Homework1()
        {
            // Show, ordered by age, the names of the employees in the Computer Science department, 
            // who have an office in the Faculty of Science, 
            // and who have done phone calls longer than one minute



        }

        private void Homework2()//tipado anónimo
        {
            // Show the summation, in seconds, of the phone calls done by the employees of the Computer Science department

        }

        private void Homework2b()//tupla
        {
            // Show the summation, in seconds, of the phone calls done by the employees of the Computer Science department

        }
        private void Homework2c()//normal
        {
            // Show the summation, in seconds, of the phone calls done by the employees of the Computer Science department


        }

        private void Homework3()//tipado dinámico
        {
            // Show the phone calls done by each department, ordered by department names. 
            // Each line must show “Department = <Name>, Duration = <Seconds>”


        }

        private void Homework3b()//normal
        {
            // Show the phone calls done by each department, ordered by department names. 
            // Each line must show “Department = <Name>, Duration = <Seconds>”


        }

        private void Homework3c()//normal y aggregate
        {
            // Show the phone calls done by each department, ordered by department names. 
            // Each line must show “Department = <Name>, Duration = <Seconds>”


        }

        private void Homework4()//normal
        {
            //Show the departments with the youngest employee, 
            // together with the name of the youngest employee and his/ her age
            //  (more than one youngest employee may exist)

        }

        private void Homework4b()//con tipado
        {
            // Show the departments with the youngest employee, 
            // together with the name of the youngest employee and his/her age 
            // (more than one youngest employee may exist)

        }

        private void Homework5()
        {
            // Show the greatest summation of phone call durations, in seconds, 
            // of the employees in the same department, together with the name of the department 
            // (it can be assumed that there is only one department fulfilling that condition)


        }


    }

}
