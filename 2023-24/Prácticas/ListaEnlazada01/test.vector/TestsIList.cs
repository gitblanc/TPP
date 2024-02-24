using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace test.vector
{
    [TestClass]
    public class TestsIList
    {
        [TestMethod]
        public void TestAll()
        {
            IList<string> list = new List<string>();

            //Probando el Añadir (.Add(...))
            list.Add("pepe");
            list.Add("manuel");
            list.Add("cebolla");
            list.Add("maria");
            list.Add("patata");
            list.Add("cobilongo");
            list.Add("aceituna");
            list.Add("jirafa");
            list.Add("espinaca");
            list.Add("anacardo");

            //Probando el conocer el número de elementos (.Count)
            Assert.AreEqual(10, list.Count);

            //Probando obtener y reescribir el elemento de la posición i-ésima ([...])
            Assert.AreEqual("anacardo", list[9]);
            list[9] = "cambiado";//cambiamos el 10 por 57
            Assert.AreEqual("cambiado", list[9]);

            //Probando saber si un número está o no en el vector (.Contains(...))
            Assert.IsFalse(list.Contains("anacardo"));
            Assert.IsTrue(list.Contains("cambiado"));

            //Probando el primer índice de un elemento dado (si existe)
            Assert.AreEqual('c', list[9][0]);

            //Probando borrar la primera aparición de un elemento dado (.Remove(...))
            Assert.IsTrue(list.Contains("jirafa"));
            Assert.IsTrue(list.Remove("jirafa"));
            Assert.IsFalse(list.Contains("jirafa"));

            //Probando una iteración mediante el foreach
            foreach (var elem in list)
            {
                Assert.IsTrue(elem != null);
            }
        }
    }
}
