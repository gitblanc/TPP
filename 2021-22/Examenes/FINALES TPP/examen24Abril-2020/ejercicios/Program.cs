using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPP.Examen.PL5.Restaurante;

namespace TPP.Examen.PL5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio1();
            //Ejercicio2();
            //Ejercicio3();
        }

        public static void Ejercicio1()
        {
            Cocina restaurante = new CocinaMonohilo();
            restaurante.AtenderPedidos(Modelo.GetPedidoAleatorio());
        }

        public static void Ejercicio2()
        {
            var ingredientes = Modelo.GetIngredientes();
            var menu = Modelo.GetMenu();
            //Consulta1: Los nombres de las pizzas del menú sin tomate

            //Consulta2: Nombres de todos ingredientes con alergenos que se utilizan en la elaboración de las pizzas del menú
        }

        public static void Ejercicio3()
        {
            //DeleteIfFollowing: Pruebalo definiendo varias listas y utilizando diferentes criterios
        }

    }
}
