using System;
using ModeloClases;

namespace ListaEnlazada01
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Creamos la lista y vamos añadiendo números con un método que los genera
            LinkedList list = new();
            Console.Write($"{list}");

            Random random = new();

            Console.WriteLine("Comprobación del Add()");
            AddFewNumbers(7, list, random);

            Console.WriteLine("Comprobación del GetElement()");
            LinkedNode elem1 = list.GetElement(10);
            bool cond1 = (elem1 != null && elem1.Data.Equals(10));
            LinkedNode elem2 = list.GetElement(6);
            bool cond2 = (elem2 != null && elem2.Data.Equals(6));
            Console.WriteLine($"¿Existe el 10 en la lista? -> {cond1}");
            Console.WriteLine($"¿Existe el 6 en la lista? -> {cond2}");

            Console.WriteLine("Comprobación del Remove()");
            RemoveFewNumbers(2, list, random);
        }

        static void AddFewNumbers(int numbers, LinkedList list, Random random)
        {
            for (int i = 0; i < numbers; i++)
            {
                list.Add(random.Next(0, 11));
                //list.Add(i);
                Console.Write($"{list}");
            }
        }

        static void RemoveFewNumbers(int numbers, LinkedList list, Random random)
        {
            for (int i = 0; i < numbers; i++)
            {
                int elem = random.Next(0, 11);
                Console.WriteLine($"Borrar: {elem}");
                list.Remove(elem);
                Console.Write($"{list}");
            }
        }
    }
}
