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

            //Probando el A�adir (.Add(...))
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

            //Probando el conocer el n�mero de elementos (.Count)
            Assert.AreEqual(10, list.Count);

            //Probando obtener y reescribir el elemento de la posici�n i-�sima ([...])
            Assert.AreEqual("anacardo", list[9]);
            list[9] = "cambiado";//cambiamos el 10 por 57
            Assert.AreEqual("cambiado", list[9]);

            //Probando saber si un n�mero est� o no en el vector (.Contains(...))
            Assert.IsFalse(list.Contains("anacardo"));
            Assert.IsTrue(list.Contains("cambiado"));

            //Probando el primer �ndice de un elemento dado (si existe)
            Assert.AreEqual('c', list[9][0]);

            //Probando borrar la primera aparici�n de un elemento dado (.Remove(...))
            Assert.IsTrue(list.Contains("jirafa"));
            Assert.IsTrue(list.Remove("jirafa"));
            Assert.IsFalse(list.Contains("jirafa"));

            //Probando una iteraci�n mediante el foreach
            foreach (var elem in list)
            {
                Assert.IsTrue(elem != null);
            }
        }
    }
}
