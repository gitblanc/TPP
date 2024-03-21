using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloClases
{
    public class Person
    {
        // Propiedades de la clase
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }

        // Constructor para inicializar una nueva instancia de la clase Persona
        public Person(string name, string apellidos, string ciudad)
        {
            Name = name;
            Surname = apellidos;
            City = ciudad;
        }

        // Sobrescribir el método Equals para comparar objetos Persona
        public override bool Equals(object obj)
        {
            // Verificar si el objeto es nulo
            if (obj == null) return false;

            // Verificar si el objeto es de tipo Persona
            Person p = obj as Person;
            if (p == null) return false;

            // Comparar si las propiedades son iguales
            return (Name == p.Name) &&
                   (Surname == p.Surname) &&
                   (City == p.City);
        }

        // Sobrescribir el método GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, City);
        }
    }
}
