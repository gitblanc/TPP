
using NUnit.Framework;
using Examen24Abril2020TPP;
using System;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           

        }

        [Test]
        public void Test1()
        {
            string[] str = Program.CrearPalabrasAleatorias(1000, 3, 5);
            Predicate<string>[] p = new Predicate<string>[] { (p => p.Length % 2 == 0), (p => p.Length > 4 ) };
            var d = Program.Ejercicio2<string>(str, p);

            Assert.Pass();
        }
    }
}