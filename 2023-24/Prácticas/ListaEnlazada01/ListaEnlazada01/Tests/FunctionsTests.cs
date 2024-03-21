using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloClases;
using System.Reflection.Metadata.Ecma335;
using System.Collections;

namespace Tests
{
    [TestClass]
    public class FunctionsTests
    {
        [TestMethod]
        public void TestFind()
        {
            // Pruebas con personas
            Persona[] personas = Factoria.CrearPersonas();
            ModeloClases.LinkedList<Persona> list = new();//darse cuenta de que estamos usando nuestra lista

            foreach (var p in personas)
                list.Add(p);

            Assert.AreEqual(personas[6], MyFunctions.Find(list, p => p.Nombre.Equals("Cristina")));
            Assert.AreEqual(personas[0], MyFunctions.Find(list, p => p.Nif.EndsWith("A")));

            // Pruebas con Angulos
            Angulo[] angulos = Factoria.CrearAngulos();
            ModeloClases.LinkedList<Angulo> list2 = new();

            foreach (var a in angulos)
                list2.Add(a);

            Assert.AreEqual(angulos[90], MyFunctions.Find(list2, a => a.Grados == 90));
            Assert.AreEqual(angulos[0], MyFunctions.Find(list2, a => a.Radianes < Math.PI / 2));
        }

        [TestMethod]
        public void TestFilter()
        {
            // Pruebas con personas
            Persona[] personas = Factoria.CrearPersonas();
            ModeloClases.LinkedList<Persona> list = new();//darse cuenta de que estamos usando nuestra lista

            foreach (var p in personas)
                list.Add(p);

            var newListPersonas = MyFunctions.Filter(list, p => p.Nombre.Equals("Juan") && p.Nif.EndsWith("F"));
            foreach (var p in newListPersonas)
            {
                Assert.IsTrue(p.Nombre.Equals("Juan") && p.Nif.EndsWith("F"));
            }

            // Pruebas con Angulos
            Angulo[] angulos = Factoria.CrearAngulos();
            ModeloClases.LinkedList<Angulo> list2 = new();

            foreach (var a in angulos)
                list2.Add(a);

            var newListAngulos = MyFunctions.Filter(list2, a => a.Grados == 90);
            foreach (var a in newListAngulos)
            {
                Assert.IsTrue(a.Grados == 90);
            }
        }

        [TestMethod]
        public void TestReduce()
        {
            // Pruebas con angulos
            Angulo[] angulos = Factoria.CrearAngulos();
            ModeloClases.LinkedList<Angulo> list = new();
            foreach (var a in angulos)
                list.Add(a);

            // suma de todos los ángulos
            Assert.AreEqual(64980, MyFunctions.Reduce(angulos, (Angulo a, float res) => a.Grados + res));
            // calcular el seno máximo
            Assert.AreEqual(1, MyFunctions.Reduce(angulos, (Angulo a, double res) =>
            {
                return a.Coseno() > res ? a.Coseno() : res;
            }));

            // Pruebas con Personas
            Persona[] personas = Factoria.CrearPersonas();
            ModeloClases.LinkedList<Persona> list2 = new();

            foreach (var p in personas)
                list2.Add(p);


            Assert.AreEqual(2, MyFunctions.Reduce(list2, (Persona p, int res) =>
            {
                if (p.Nombre.Equals("Juan"))
                    res += 1;
                return res;
            }
            ));
        }
    }
}
