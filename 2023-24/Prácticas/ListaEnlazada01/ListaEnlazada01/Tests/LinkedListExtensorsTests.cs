using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class LinkedListExtensorsTests
    {
        [TestMethod]
        public void MyFindTests()
        {
            var personas = Factoria.MyCrearPersonas();
            var res = personas.MyFind(p => p.Nombre.Equals("María"));
            Assert.IsTrue(res.Nif.Equals("9876384A"));

            res = personas.MyFind(p => p.Nombre.Equals("wkoduafbovw"));
            Assert.IsNull(res);
        }

        [TestMethod]
        public void MyFilterTests()
        {
            var personas = Factoria.MyCrearPersonas();
            var res = personas.MyFilter(p => p.Nombre.Equals("María"));
            Assert.AreEqual(2, res.Count());
        }

        [TestMethod]
        public void MyReduceTests()
        {
            var personas = Factoria.MyCrearPersonas();
            var numerodemarias = personas.MyReduce((p, acu) =>
            {
                if (p.Nombre.Equals("María"))
                    acu++;
                return acu;
            }, 0);

            Assert.AreEqual(2, numerodemarias);
        }

        [TestMethod]
        public void MyInvertTests()
        {
            var personas = Factoria.MyCrearPersonas();
            var marias = personas.MyFilter(p => p.Nombre.Equals("María"));
            foreach (var m in marias)
                Console.WriteLine(m.ToString());

            var invertidas = marias.MyInvert();
            Assert.AreEqual(2, marias.NumberOfElements);
            foreach (var m in invertidas)
                Console.WriteLine(m.ToString());
        }

        [TestMethod]
        public void MyMapTests()
        {
            var personas = Factoria.MyCrearPersonas();
            var marias = personas.MyMap(p => p.Apellido);
            foreach (var m in marias)
                Console.WriteLine(m.ToString());
        }

        [TestMethod]
        public void MyForEachTests()
        {
            var personas = Factoria.MyCrearPersonas();
            personas.MyForEach(p => Console.WriteLine($"Persona {p.Nombre}"));
        }
    }
}
