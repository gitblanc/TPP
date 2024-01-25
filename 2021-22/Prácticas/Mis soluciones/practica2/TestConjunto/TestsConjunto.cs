using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases;

namespace TestConjunto
{
    [TestClass]
    public class TestsConjunto
    {
        private Conjunto c2;
        private Conjunto c1;

        [TestInitialize]
        public void Initialize()
        {
            c1 = new Conjunto();
            c2 = new Conjunto();
            c1.Add(1);
            c1.Add(2);
            c1.Add(3);
            c2.Add(2);
            c2.Add(3);
            c2.Add(4);
        }

        [TestMethod]
        public void TestOperators()
        {
            //Assert.AreEqual("[1 2 3 [2 3 4 ] ]", (c1 + c2).ToString());
            //Assert.AreEqual("[1 2 3 ]", (c1 - c2).ToString());
            //Assert.AreEqual("[1 2 3 4 ]", (c1 | c2).ToString());
            //Assert.AreEqual("[2 3 ]", (c1 & c2).ToString());
            //Assert.AreEqual("[1 ]", (c1 - c2).ToString());
            //Assert.AreEqual("[4 ]", (c2 - c1).ToString());
            //Assert.IsTrue((c2 ^3));
            //Assert.IsFalse((c2 ^ 28345675));
        }
    }
}
