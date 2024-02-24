using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloClases;

namespace Tests
{
    [TestClass]
    public class MyStackTests
    {
        [TestMethod]
        public void TestInt()
        {
            MyStack<int> stack = new(5);
            //PUSH
            Assert.IsTrue(stack.IsEmpty);
            Assert.IsFalse(stack.IsFull);

            Assert.IsTrue(stack.Push(2));
            Assert.IsFalse(stack.IsEmpty);
            Assert.IsTrue(stack.Push(1));
            Assert.IsTrue(stack.Push(4));
            Assert.IsTrue(stack.Push(2));
            Assert.IsTrue(stack.Push(6));
            Assert.IsTrue(stack.IsFull);
            try
            {
                stack.Push(7);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            //POP
            Assert.AreEqual(6, stack.Pop());
            Assert.IsFalse(stack.IsFull);
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(4, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            try
            {
                stack.Pop();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Assert.IsFalse(stack.IsFull);
            Assert.IsTrue(stack.IsEmpty);
        }

        [TestMethod]
        public void TestString()
        {
            string s1 = "Eduardo";
            string s2 = "Jesús";
            string s3 = "Felipe";
            string s4 = "Carla";
            string s5 = "Jesús";
            string s6 = "Eustaquio";
            string s7 = "Aceituna";

            MyStack<string> stack = new(6);
            //PUSH
            Assert.IsTrue(stack.IsEmpty);
            Assert.IsFalse(stack.IsFull);

            Assert.IsTrue(stack.Push(s1));
            Assert.IsFalse(stack.IsEmpty);
            Assert.IsTrue(stack.Push(s2));
            Assert.IsTrue(stack.Push(s3));
            Assert.IsTrue(stack.Push(s4));
            Assert.IsTrue(stack.Push(s5));
            Assert.IsTrue(stack.Push(s6));
            Assert.IsTrue(stack.IsFull);
            try
            {
                stack.Push(s7);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            //POP
            Assert.AreEqual(s6, stack.Pop());
            Assert.IsFalse(stack.IsFull);
            Assert.AreEqual(s5, stack.Pop());
            Assert.AreEqual(s4, stack.Pop());
            Assert.AreEqual(s3, stack.Pop());
            Assert.AreEqual(s2, stack.Pop());
            Assert.AreEqual(s1, stack.Pop());
            try
            {
                stack.Pop();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Assert.IsFalse(stack.IsFull);
            Assert.IsTrue(stack.IsEmpty);
        }
    }
}
