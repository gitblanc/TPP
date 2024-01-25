using System;
using System.Collections.Generic;
using clases;

namespace practica6v1._0
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fibonacci Eager: ");
            FibonacciEager fe = new FibonacciEager();
            fe.Fibonacci(15).Show();
            FibonacciLazy fl = new FibonacciLazy();
            fl.Fibonacci(15).Show();
        }

        public static void Show<T>(this IEnumerable<T> collection)
        {
            Console.Write("[");
            foreach (var elem in collection)
                Console.Write($"{elem.ToString()} ");
            Console.Write("]");
            Console.WriteLine();
        }
    }
}
