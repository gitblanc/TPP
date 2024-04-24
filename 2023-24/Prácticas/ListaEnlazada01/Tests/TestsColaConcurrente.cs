using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloClases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class TestsColaConcurrente
    {
        [TestMethod]
        public void Test1()
        {
            var cola = new ColaConcurrente<int>();
            int numThreads = 4;
            int elemsToAdd = 500;

            Thread[] hilos = new Thread[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                hilos[i] = new Thread(() =>
                {
                    for (int j = 0; j < elemsToAdd; j++)
                    {
                        cola.Add(j);
                    }
                });
            }

            foreach (Thread hilo in hilos)
            {
                hilo.Start();
            }

            foreach (Thread hilo in hilos)
            {
                hilo.Join();//Esperamos a que todos terminen
            }

            Assert.AreEqual(cola.NumeroElementos, 2000);

            for (int i = 0; i < numThreads; i++)
            {
                hilos[i] = new Thread(() =>
                {
                    for (int j = 0; j < elemsToAdd; j++)
                    {
                        cola.Extract();
                    }
                });
            }

            foreach (Thread hilo in hilos)
            {
                hilo.Start();
            }

            foreach (Thread hilo in hilos)
            {
                hilo.Join();//Esperamos a que todos terminen
            }

            Assert.AreEqual(0, cola.NumeroElementos);
        }

        [TestMethod]
        public void Test2()
        {
            var cola = new ColaConcurrente<int>();
            int numThreads = 2;
            int elemsToAdd = 500;

            Thread[] hilos = new Thread[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                if (i == 0)//Números pares
                {
                    hilos[i] = new Thread(() =>
                    {
                        for (int j = 0; j < elemsToAdd; j++)
                        {
                            if (j % 2 == 0)
                                cola.Add(j);
                        }
                    });
                }
                else
                { //números impares
                    hilos[i] = new Thread(() =>
                    {
                        for (int j = 0; j < elemsToAdd; j++)
                        {
                            if (j % 2 != 0)
                                cola.Add(j);
                        }
                    });
                }
            }

            foreach (Thread hilo in hilos)
            {
                hilo.Start();
            }

            foreach (Thread hilo in hilos)
            {
                hilo.Join();//Esperamos a que todos terminen
            }

            Assert.AreEqual(500, cola.NumeroElementos);
        }
    }
}
