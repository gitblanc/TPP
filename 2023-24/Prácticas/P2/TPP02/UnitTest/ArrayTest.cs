using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    //Ejercicios:
    // -Seguir el tutorial: https://docs.microsoft.com/es-es/visualstudio/test/quick-start-test-driven-development-with-test-explorer?view=vs-2022
    // -Seguir el tutorial: https://docs.microsoft.com/es-es/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022

    /// <summary>
    /// Este proyecto se ha creado como "Proyecto de prueba unitaria".
    /// Clase para testing.
    /// </summary>
    [TestClass]
    public class ArrayTest
    {
        private int[] array;

        /// <summary>
        /// El m�todo con la anotaci�n TestInitialize se ejecutar�
        /// antes de cada uno de los tests.
        /// El nombre del m�todo da igual, lo importante es la anotaci�n.
        /// Es un m�todo opcional.
        /// </summary>
        [TestInitialize]
        public void InitializeTests()
        {
            this.array = new int[] { 1, 2, 3, 4, 5, 6 };
        }

        /* Existen otras anotaciones interesantes:
         * ClassInitialize: Se ejecuta UNA UNICA VEZ antes de iniciar la bater�a de test.
         * ClassCleanup: Se ejecuta UNA UNICA VEZ despu�s de finalizar la bater�a de test.
         * TestCleanup: Se ejecuta CADA VEZ que finaliza un test.
         */



        /// <summary>
        /// Los m�todos con la anotaci�n TestMethod
        /// se ejecutar�n como pruebas unitarias.
        /// </summary>
        [TestMethod]
        [Timeout(5000)]  //Anotaci�n opcional que permite establece el tiempo m�ximo para ejecutar el test.
        public void RecuperarValorTest()
        {
            const int primero = 1, ultimo = 6;
            //Uso de asertos, deben coincidir ambos valores para que no salte el aserto.
            Assert.AreEqual(primero, array[0], "El primer elemento no coincide");
            Assert.AreEqual(3, array[array.Length - 1], "El �ltimo elemento no coincide");
        }

        /// <summary>
        /// Otra prueba unitaria para probar la modificaci�n de valores
        /// </summary>
        [TestMethod]

        public void ModificarValorTest()
        {
            const int a = 0, b = 1;
            array[1] = a;
            array[2] = b;
            Assert.AreEqual(a, array[1], "Posici�n 1 no se modific� correctamente.");
            Assert.AreEqual(b, array[2], "Posici�n 3 no se modific� correctamente.");
        }

        /// <summary>
        /// Esta prueba unitaria ser� correcta si como resultado se obtiene
        /// una excepci�n "IndexOutOfRangeException".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void LimitesDelArrayTest()
        {
            //Deber�a saltar una excepci�n.
            array[-1] = 2;
        }
    }
}
