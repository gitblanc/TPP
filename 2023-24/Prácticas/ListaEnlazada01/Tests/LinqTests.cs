using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloClases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class LinqTests
    {
        //Link to the official documentation: http://msdn.microsoft.com/en-us/library/system.linq.enumerable.aspx
        //Link to .NET 5.0 docs: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable?view=net-5.0&redirectedfrom=MSDN

        /*
         * Métodos similares:
         * 
         * Buscar -> Where
         * Filtrar -> Where
         * Reducir -> Aggregate
         * Map -> Select
         * 
         */

        [TestMethod]
        public void BuscarTest()
        {
            // Pruebe la búsquedas de personas por nombre y aquellas cuyo nif termina en una letra dada
            var personas = Factoria.CrearPersonas();
            var res = personas.Where(p => p.Nombre.Equals("María"));
            Assert.IsTrue(res.Count() == 2);
            var res2 = personas.Where(p => p.Nif.EndsWith("K"));
            Assert.IsTrue(res2.Count() == 1);

            // Pruebe la búsqueda de ángulos rectos y en un cuadrante
            var angulos = Factoria.CrearAngulos();
            var res3 = angulos.Where(a => a.Grados == 90);
            Assert.IsTrue(res3.Count() == 1);
        }

        [TestMethod]
        public void FiltrarTest()
        {
            // Pruebe la búsquedas de personas por nombre y aquellas cuyo nif termina en una letra dada
            var personas = Factoria.CrearPersonas();
            var res = personas.Where(p => p.Nombre.Equals("María"));
            Assert.IsTrue(res.Count() == 2);
            var res2 = personas.Where(p => p.Nif.EndsWith("K"));
            Assert.IsTrue(res2.Count() == 1);

            // Pruebe la búsqueda de ángulos rectos y en un cuadrante
            var angulos = Factoria.CrearAngulos();
            var res3 = angulos.Where(a => a.Grados == 90);
            Assert.IsTrue(res3.Count() == 1);
        }

        [TestMethod]
        public void ReducirTest()
        {
            // Pruébese para calcular la suma de todos los grados de los ángulos de la colección y para calcular el seno máximo.
            var angulos = Factoria.CrearAngulos();
            var res = angulos.Aggregate(0.0, (acu, a) => acu + a.Grados);// Es importante poner el valor por defecto de acu
            Assert.AreEqual(64980, res);

            // Pruébese para conocer la distribución de personas por nombre (esto es, decir que hay 10 personas con nombre "María",
            // 3 con nombre "Pedro"...)
            var personas = Factoria.CrearPersonas();
            var numerodemarias = personas.Aggregate(0, (acu, p) =>
            {
                if (p.Nombre.Equals("María"))
                    acu++;
                return acu;
            });
            Assert.AreEqual(2, numerodemarias);
        }

        [TestMethod]
        public void MapTest()
        {
            // Pruébese obteniendo los "apellidos, nombre" (como un único string) de cada una de las personas de la lista
            var personas = Factoria.CrearPersonas();
            var result = personas.Select(p => $"{p.Apellido}, {p.Nombre}");
            foreach (var a in result)
                Console.WriteLine(a.ToString());

            // Pruébese obteniendo la lista de los cuadrantes de los ángulos
            var angulos = Factoria.CrearAngulos();
            var res2 = angulos.Select(a1 =>
            {
                var a = a1.Grados % 360;
                if (a < 0) a += 360;

                if (a > 0 && a < 90) return 1; // Primer cuadrante
                else if (a > 90 && a < 180) return 2; // Segundo cuadrante
                else if (a > 180 && a < 270) return 3; // Tercer cuadrante
                else if (a > 270 && a < 360) return 4; // Cuarto cuadrante
                else return 0; // El ángulo es exactamente 0°, 90°, 180°, 270°, o 360°
            });
            foreach (var a in res2)
                Console.WriteLine(a.ToString());
        }
    }
}
