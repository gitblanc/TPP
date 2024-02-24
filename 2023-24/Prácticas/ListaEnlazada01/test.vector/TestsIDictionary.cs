using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace test.vector
{
    [TestClass]
    public class TestsIDictionary
    {
        [TestMethod]
        public void TestAll()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();

            //Probando añadir elementos (.Add(...))
            dict.Add("clave1", "patata");
            dict.Add("clave2", "cebolla");
            dict.Add("clave3", "ajo");
            dict.Add("clave4", "perejil");
            dict.Add("clave5", "recetón");

            //Probando conocer el número de pares de la colección (.Count)
            Assert.AreEqual(5, dict.Count);

            //Probando obtener y reescribir el valor para una clave dada (.ContainsKey(...) y diccionario[clave])
            if (dict.ContainsKey("clave4"))
            {
                Assert.AreEqual("perejil", dict["clave4"]);
                dict["clave4"] = "nuevo_valor";
                Assert.AreEqual("nuevo_valor", dict["clave4"]);
            }

            //Probando saber si una clave está o no en la colección (.ContainsKey(...))
            Assert.IsTrue(dict.ContainsKey("clave3"));
            Assert.IsFalse(dict.ContainsKey("clave30080897"));

            //Probando borrar, cuando exista, el elemento de la colección pasando su clave (.Remove(...))
            Assert.IsTrue(dict.ContainsKey("clave4"));
            Assert.IsTrue(dict.Remove("clave4"));
            Assert.IsFalse(dict.ContainsKey("clave4"));

            //Probando la iteración mediante un foreach
            foreach (KeyValuePair<string, string> keyValuePair in dict)
            {
                Assert.IsTrue(dict[keyValuePair.Key] != null);
            }
        }
    }
}
