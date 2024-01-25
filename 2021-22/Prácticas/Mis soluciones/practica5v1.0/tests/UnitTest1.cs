using Microsoft.VisualStudio.TestTools.UnitTesting;
using clases;
using System.Collections.Generic;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        Person[] factory;
        Angle[] angles;

        [TestMethod]
        public void TestMethod1()
        {
            factory = Factory.CreatePeople();
            angles = Factory.CreateAngles();
            Assert.AreEqual(factory[3].IDNumber, factory.Find(x => x.Surname.ToLower().Equals("garcía")).IDNumber);
            Assert.AreEqual(factory[4].ToString(), ((Person[]) factory.Filter(x => x.Surname.ToLower().Equals("rodríguez")))[0].ToString());
            Assert.AreEqual(64980, (double) angles.Reduce(funcion, 0.0));
        }

        public double funcion(Angle a, double x1)
        {
            return x1 + a.Degrees;
        }
    }
}
