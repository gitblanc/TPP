using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloClases;


namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestInt()
        {
            LinkedList list = new();

            Assert.AreEqual(0, list.NumberOfElements);

            list.Add(3);
            list.Add(8);
            list.Add(2);
            list.Add(1);
            list.Add(5);
            list.Add(2);
            list.Add(10);
            Assert.AreEqual("[3]->[8]->[2]->[1]->[5]->[2]->[10]->null, elems: 7\r\n", list.ToString());
            Assert.AreEqual(7, list.NumberOfElements);
            // Eliminamos el 3 (cabeza)
            Assert.IsTrue(list.Remove(3));
            Assert.IsFalse(list.ContainsElement(3));
            Assert.AreEqual(6, list.NumberOfElements);
            // Borramos un elemento repetido (se borra el primero que encuentra)
            Assert.IsTrue(list.Remove(2));
            Assert.IsTrue(list.ContainsElement(2));
            Assert.AreEqual(5, list.NumberOfElements);
            // Intenta borrar un elemento que no existe
            Assert.IsFalse(list.Remove(7456));
            Assert.AreEqual(5, list.NumberOfElements);
            // Borramos el último elemento
            Assert.IsTrue(list.Remove(10));
            Assert.IsFalse(list.ContainsElement(10));
            Assert.AreEqual(4, list.NumberOfElements);
            Assert.IsTrue(list.Remove(8));
            Assert.AreEqual(3, list.NumberOfElements);
            Assert.IsTrue(list.Remove(2));
            Assert.AreEqual(2, list.NumberOfElements);
            Assert.IsTrue(list.Remove(1));
            Assert.AreEqual(1, list.NumberOfElements);
            Assert.IsTrue(list.Remove(5));
            Assert.AreEqual(0, list.NumberOfElements);
            Assert.IsFalse(list.Remove(8456467));
            Assert.AreEqual(0, list.NumberOfElements);
        }

        [TestMethod]
        public void TestDouble()
        {
            LinkedList list = new();

            Assert.AreEqual(0, list.NumberOfElements);

            list.Add(3.2);
            list.Add(8.0);
            list.Add(2.0);
            list.Add(1.0);
            list.Add(5.0);
            list.Add(2.0);
            list.Add(10.0);
            Assert.AreEqual(7, list.NumberOfElements);
            // Eliminamos el 3.2 (cabeza)
            Assert.IsTrue(list.Remove(3.2));
            Assert.IsFalse(list.ContainsElement(3.2));
            Assert.AreEqual(6, list.NumberOfElements);
            // Borramos un elemento repetido (se borra el primero que encuentra)
            Assert.IsTrue(list.Remove(2.0));
            Assert.IsTrue(list.ContainsElement(2.0));
            Assert.AreEqual(5, list.NumberOfElements);
            // Intenta borrar un elemento que no existe
            Assert.IsFalse(list.Remove(7456.0));
            Assert.AreEqual(5, list.NumberOfElements);
            // Borramos el último elemento
            Assert.IsTrue(list.Remove(10.0));
            Assert.IsFalse(list.ContainsElement(10.0));
            Assert.AreEqual(4, list.NumberOfElements);
            Assert.IsTrue(list.Remove(8.0));
            Assert.AreEqual(3, list.NumberOfElements);
            Assert.IsTrue(list.Remove(2.0));
            Assert.AreEqual(2, list.NumberOfElements);
            Assert.IsTrue(list.Remove(1.0));
            Assert.AreEqual(1, list.NumberOfElements);
            Assert.IsTrue(list.Remove(5.0));
            Assert.AreEqual(0, list.NumberOfElements);
            Assert.IsFalse(list.Remove(8456467.02134));
            Assert.AreEqual(0, list.NumberOfElements);
        }

        [TestMethod]
        public void TestString()
        {
            LinkedList list = new();

            Assert.AreEqual(0, list.NumberOfElements);

            string s1 = "Eduardo";
            string s2 = "Jesús";
            string s3 = "Felipe";
            string s4 = "Carla";
            string s5 = "Jesús";
            string s6 = "Eustaquio";
            string s7 = "Aceituna";

            list.Add(s1);
            list.Add(s2);
            list.Add(s3);
            list.Add(null);
            list.Add(null);
            list.Add(s4);
            list.Add(s5);
            list.Add(s6);
            list.Add(s7);
            // Comprobación del método Contains (con null)
            Assert.IsTrue(list.ContainsElement(null));
            Assert.AreEqual(9, list.NumberOfElements);
            // Eliminamos la cabeza
            Assert.IsTrue(list.Remove(s1));
            Assert.IsFalse(list.ContainsElement(s1));
            Assert.AreEqual(8, list.NumberOfElements);
            // Borramos un elemento repetido (se borra el primero que encuentra)
            Assert.IsTrue(list.Remove(s2));
            Assert.IsTrue(list.ContainsElement(s2));
            Assert.AreEqual(7, list.NumberOfElements);
            // Intenta borrar un elemento que no existe
            Assert.IsFalse(list.Remove("Julián"));
            // Borramos el último elemento
            Assert.IsTrue(list.Remove(s7));
            Assert.IsFalse(list.ContainsElement(s7));
            Assert.AreEqual(6, list.NumberOfElements);
            Assert.IsTrue(list.Remove(s3));
            Assert.AreEqual(5, list.NumberOfElements);
            Assert.IsTrue(list.Remove(s4));
            Assert.AreEqual(4, list.NumberOfElements);
            Assert.IsTrue(list.Remove(s5));
            Assert.AreEqual(3, list.NumberOfElements);
            // Eliminamos el primer null
            Assert.IsTrue(list.Remove(null));
            Assert.IsTrue(list.ContainsElement(null));
            Assert.AreEqual(2, list.NumberOfElements);
            Assert.IsTrue(list.Remove(s6));
            Assert.AreEqual(1, list.NumberOfElements);
            Assert.IsFalse(list.Remove("No existooo"));
            Assert.AreEqual(1, list.NumberOfElements);
            // Eliminamos el segundo null
            Assert.IsTrue(list.Remove(null));
            Assert.IsFalse(list.ContainsElement(null));
            Assert.AreEqual(0, list.NumberOfElements);
        }

        [TestMethod]
        public void TestPerson()
        {
            LinkedList list = new();

            Assert.AreEqual(0, list.NumberOfElements);

            Person p1 = new("Eduardo", "a", "Oviedo");
            Person p2 = new("Jesús", "a", "Oviedo");
            Person p3 = new("Félix", "v", "Oviedo");
            Person p4 = new("María", "b", "Oviedo");
            Person p5 = new("Carla", "b", "Oviedo");
            Person p6 = new("Jesús", "a", "Oviedo");
            Person p7 = new("Pepe", "c", "Oviedo");

            list.Add(p1);
            list.Add(p2);
            list.Add(p3);
            list.Add(null);
            list.Add(null);
            list.Add(p4);
            list.Add(p5);
            list.Add(p6);
            list.Add(p7);
            // Comprobación del método Contains (con null)
            Assert.IsTrue(list.ContainsElement(null));
            Assert.AreEqual(9, list.NumberOfElements);
            // Eliminamos la cabeza
            Assert.IsTrue(list.Remove(p1));
            Assert.IsFalse(list.ContainsElement(p1));
            Assert.AreEqual(8, list.NumberOfElements);
            // Borramos un elemento repetido (se borra el primero que encuentra)
            Assert.IsTrue(list.Remove(p2));
            Assert.IsTrue(list.ContainsElement(p2));
            Assert.AreEqual(7, list.NumberOfElements);
            // Intenta borrar un elemento que no existe
            Assert.IsFalse(list.Remove(new Person("A", "B", "Oviedo")));
            // Borramos el último elemento
            Assert.IsTrue(list.Remove(p7));
            Assert.IsFalse(list.ContainsElement(p7));
            Assert.AreEqual(6, list.NumberOfElements);
            Assert.IsTrue(list.Remove(p3));
            Assert.AreEqual(5, list.NumberOfElements);
            Assert.IsTrue(list.Remove(p4));
            Assert.AreEqual(4, list.NumberOfElements);
            Assert.IsTrue(list.Remove(p5));
            Assert.AreEqual(3, list.NumberOfElements);
            // Eliminamos el primer null
            Assert.IsTrue(list.Remove(null));
            Assert.IsTrue(list.ContainsElement(null));
            Assert.AreEqual(2, list.NumberOfElements);
            Assert.IsTrue(list.Remove(p6));
            Assert.AreEqual(1, list.NumberOfElements);
            // Eliminamos el segundo null
            Assert.IsTrue(list.Remove(null));
            Assert.IsFalse(list.ContainsElement(null));
            Assert.AreEqual(0, list.NumberOfElements);
        }
    }
}
