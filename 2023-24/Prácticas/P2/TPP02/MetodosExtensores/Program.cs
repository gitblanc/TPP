using System;

namespace MetodosExtensores
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demostración de métodos extensores.
            string prueba = "murciélago";
            //¡OJO! Fíjate que, en este caso, no pasamos ningún parámetro.
            int vocalesSinTilde = prueba.ContarVocalesSinTilde();
            Console.WriteLine("El texto {0} contiene {1} vocales sin tilde", prueba, vocalesSinTilde);


            //Ejercicios
            //Crear un método extensor de string que, a partir de un texto, cuente las repeticiones de una letra (debe recibir la letra, obviamente).

            //Crear un método extensor de DateTime Estacion() que devuelva la estación (string). No es necesario utilizar nada de la práctica anterior.

            //Crear un método extensor de vuestra clase Lista denominado Sum() que devuelva la suma de todos los elementos de la lista.            


        }
    }
}
