using System;

namespace Currificacion
{
    public static class Program
    {
        static void Main()
        {
            // La currificación consiste en que las funciones siempre reciban un parámetro
            //La currificación es una técnica que consiste en transformar
            //una función que recibe N parámetros en una que recibe un ÚNICO parametro.

            //La función recibe un parámetro
            //y devuelve una clausura que pide el siguiente parámetro
            //y devuelve una clausura... Así hasta completar la operación (devolviendo un valor).

            Suma(3, 5); // No es una función currificada.

            //SumaCurrificada me devuelve la clausura SumaTres ¿Guarda estado?

            Func<int, int> SumaTres = SumaCurrificada(3);

            //SumaTres(4) ya devuelve el valor buscado. Si hubiera un tercer valor...
            //Tendríamos otra clausura y así sucesivamente.

            int resultado = SumaTres(4); //3 + 4

            //o directamente:
            resultado = SumaCurrificada(3)(4);
            Console.WriteLine("Invocación currificada: {0}", resultado);


            //La currificación permite hacer uso de la aplicación parcial:
            //Paso de menor número de parámetros en la invocación 

            Console.WriteLine("Aplicación parcial: {0}", SumaTres(20));
            Console.WriteLine("Aplicación parcial: {0}", SumaTres(100));

            //¿Qué ventajas presenta la aplicación parcial?


            // EJERCICIOS EXAMEN
            // Nota: en la versión currificada, el primer parámetro es lo que devuelve la división, el segundo es el dividendo, el tercero es el divisor y el cuarto es el resto
            Console.WriteLine($"División sin currificar: {Ejercicio.ComprobarDivision(5, 3, 1, 2)}");
            Console.WriteLine($"División aplicación parcial 1: {Ejercicio.ComprobarDivisionCurrificada1(5, 3, 1)(2)}");
            Console.WriteLine($"División aplicación parcial 2: {Ejercicio.ComprobarDivisionCurrificada2(5, 3)(2)(1)}");
            Console.WriteLine($"División currificada: {Ejercicio.ComprobarDivisionCurrificada3(5)(2)(1)(3)}");
            //Ejemplo al reves
            Console.WriteLine($"División currificada modificada: {Ejercicio.ComprobarDivisionCurrificada3(1)(5)(3)(2)}");
            // Se sabe que la división:  20 / 6 = 3. Se desconoce el valor del resto.
            // Partiendo del valor 0, e incrementalmente, obténgase el resto.
            int resto = 0;
            while (!Ejercicio.ComprobarDivisionCurrificada3(3)(20)(6)(resto))
            {
                resto += 1;
            }
            Console.WriteLine($"resto de hacer 20/6: {resto}");
        }

        static int Suma(int a, int b)
        {
            return a + b;
        }

        //PASOS PARA CURRIFICAR
        static Func<int, int> SumaCurryByMe(int a)//, int b)
        {
            return b => a + b;//return a + b;
        }


        /// <summary>
        /// En esta función establecemos TODA la currificación
        /// </summary>
        /// <param name="a">Primer parámetro</param>
        /// <returns>Devuelve la clausura que solicita el siguiente valor</returns>
        static Func<int, int> SumaCurrificada(int a)
        {
            //Clausura: Func que nos pide el parámetro b y guarda la referencia de a.
            return b => a + b;
        }
    }
}
