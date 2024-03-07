using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Clausuras
{
    public static class Program
    {
        public static int ContarSi<T>(this IEnumerable<T> coleccion, Predicate<T> condicion)
        {
            int contador = 0;

            foreach (var elemento in coleccion)
                if (condicion(elemento))
                    contador++;

            return contador;
        }

        public static int ContarMenoresQue(IEnumerable<int> coleccion, int n)
        {
            int contador = 0;

            foreach (var elemento in coleccion)
                if (elemento < n)
                    contador++;

            return contador;
        }

        static void Main()
        {
            // Contar cuántos números de una colección son menores que N.

            //.Range permite crear colecciones de enteros. Partimos de 0 hasta llegar a 20 ELEMENTOS 
            // En este caso, [0, 19].

            IEnumerable<int> coleccion = Enumerable.Range(0, 20);

            int n = 5;

            //Concepto de Clausura (cierre, closure).

            //Compárese este Predicado con la función definida más arriba "ContarMenoresQue"
            Predicate<int> EsMenor = numero => numero < n;//aquí está como un delegado la n guarda una referencia a la variable de la línea 40

            int resultado = coleccion.ContarSi(EsMenor);

            Console.WriteLine($"La colección tiene {resultado} valores menores que {n}");

            // ¿Qué ocurre si cambio el valor de n? ¿Dónde está definida?
            n = 2;//que se actualiza el valor de la referencia, es decir, ahora el predicate es numero => numero < 2 (antes era < 5)
            resultado = coleccion.ContarSi(EsMenor);

            // El Predicado "EsMenor" almacena el valor de n? ¿Qué almacena?
            Console.WriteLine($"La colección tiene {resultado} valores menores que {n}");


            //LimpiarPantalla();


            //Un contador mediante el uso de objetos (POO).
            int iteraciones = 15;

            ClaseContador contador = new ClaseContador();

            for (int i = 0; i < iteraciones; i++)
                contador.Incrementar();

            Console.WriteLine($"[Contador Objetos] Valor actual del contador: {contador.Valor}");


            //Equivalente empleando una clausura

            Func<int> contadorClausura = ClausuraContador.CrearContador();

            int valorContador = 0;

            for (int i = 0; i < iteraciones; i++)
                valorContador = contadorClausura();//va a haber un estado, porlo que no devuelve lo mismo siempre

            Console.WriteLine($"[Contador Clausura] Valor actual del contador: {valorContador}");


            //LimpiarPantalla();

            //¿Y si se necesitan varias clausuras para manipular el estado?

            //Un ejemplo simple con un getter y un setter.

            //En POO manipulamos el estado mediante métodos.
            Contenedor<int> contenedor = new Contenedor<int>(5);
            contenedor.SetValor(20);
            Console.WriteLine($"[Objetos] Almacenado: {contenedor.GetValor()}");


            //Sin embargo, mediante clausuras...

            //set recibe el nuevo valor y no devuelve nada.
            Action<int> SetValor;
            //get no recibe nada y devuelve un valor.
            Func<int> GetValor;

            ClausuraContenedor.CrearContador(5, out SetValor, out GetValor);//los out se inicializan primero y su valor se modificará. Después el valor se guardará y se podrá usar más adelante
            Console.WriteLine($"[Clausuras] Almacenado: {GetValor()}");

            SetValor(20);

            Console.WriteLine($"[Clausuras] Almacenado: {GetValor()}");

            // EJERCICIOS EXAMEN
            // Ejercicio 1
            // Versión 1
            Func<int> aleatorio = Ejercicio.MetodoAleatorioInferiorv1();
            int val = aleatorio();
            while (val != 0)
            {
                Console.WriteLine(val);
                val = aleatorio();
            }
            Console.WriteLine(val);
            Console.WriteLine("Versión 2");
            // Versión 2
            Action<int> Modify;
            Action Reset;
            //get no recibe nada y devuelve un valor
            Func<int> GetValorGenerador;
            Ejercicio.MetodoAleatorioInferiorv2(50, out Reset, out GetValorGenerador, out Modify);
            val = GetValorGenerador();
            while (val != 0)
            {
                Console.WriteLine(val);
                val = GetValorGenerador();
            }
            Console.WriteLine(val);
            Console.WriteLine("RESET");
            Reset();
            val = GetValorGenerador();
            while (val != 0)
            {
                Console.WriteLine(val);
                val = GetValorGenerador();
            }
            Console.WriteLine(val);
            Console.WriteLine("MODIFY 450");
            Modify(450);
            val = GetValorGenerador();
            while (val != 0)
            {
                Console.WriteLine(val);
                val = GetValorGenerador();
            }
            Console.WriteLine(val);


            Console.WriteLine("Fibonacci");
            var fiboGenerator = Ejercicio.GetFibonacciGenerator();

            // Generar y mostrar los primeros 10 números de Fibonacci.
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(fiboGenerator());
            }
        }

        static void LimpiarPantalla()
        {
            Console.WriteLine("\nPulse una tecla para continuar al siguiente ejemplo...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
