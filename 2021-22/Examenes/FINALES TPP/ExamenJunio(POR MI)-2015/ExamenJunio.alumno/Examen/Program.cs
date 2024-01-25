using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace TPP.FinalJunio
{

    public class FinalJunio
    {
        static void Main(string[] args)
        {
            //Inicio de variables
            //Ejercicio1
            Persona[] personas = CrearPersonas();
            IEnumerable<Persona> personasUnicas;

            //Ejercicio2
            int[] vector = CrearVectorAleatorio(15, 0, 15);
            int[] vectorEspejo;

            //Ejercicio3
            Model m = new Model();
           
            //INVOCACIONES A LOS EJERCICIOS

            // Ejercicio 1a.        
            System.Console.WriteLine("Ejercicio1a");
            System.Console.WriteLine("Personas original");
            MostrarPersonas(personas);

            //Invoque aquí al método correspondiente al ejercicio 1a

            System.Console.WriteLine("Personas sin repeticiones");
            //Descomentar cuando se tenga hecho el cálculo de personasUnicas
            //MostrarPersonas(personasUnicas);

            // Ejercicio 1b.
            System.Console.WriteLine("Ejercicio1b");
            System.Console.WriteLine("Personas original");
            MostrarPersonas(personas);

            //Invoque aquí al método correspondiente al ejercicio 1b

            System.Console.WriteLine("Personas sin repeticiones");
            //Descomentar cuando se tenga hecho el cálculo de personasUnicas
            //MostrarPersonas(personasUnicas);


            System.Console.WriteLine("Ejercicio2");

            int edadAcumulada = ejercicio2(m);
            System.Console.WriteLine("Edad Acumulada");
            System.Console.WriteLine(edadAcumulada);

            // Ejercicio 3.
            System.Console.WriteLine("Ejercicio3");
            System.Console.WriteLine("Vector Original");
            MostrarVector(vector);

            vectorEspejo = ejercicio3(vector);

            System.Console.WriteLine("Vector Espejo");
            //Descomentar cuando se tenga hecho el cálculo de vectorEspejo
            //MostrarVector(vectorEspejo);
        }



        //Ejercicio 1a, Defina aquí el método principal para este ejercicio.



        //Ejercicio 1b, Defina aquí el método principal para este ejercicio.
      


        //Ejercicio2. Modifique según necesite.
        public static int ejercicio2(Model m)
        {


            return 0;
        }




        //Ejercicio3. Modifique según necesite.
        public static int[] ejercicio3(int[] vector) 
        {


            return null;
        }




        public static int[] CrearVectorAleatorio(int posiciones, int menor, int mayor)
        {
            int[] vector = new int[posiciones];
            //La semilla siempre es 1 para obtener resultados deterministas
            Random random = new Random(1);
            for (int i = 0; i < posiciones; i++)
                vector[i] = (int)random.Next(menor, mayor + 1);
            return vector;
        }

        public static void MostrarVector(int[] vector)
        {
            for (int i = 0; i < vector.GetLength(0); i++)
            {
                System.Console.Write(vector[i]+" ");
                
            }
            System.Console.WriteLine();
        }

        static Persona[] CrearPersonas()
        {
            string[] nombres = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina" };
            string[] apellidos = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez" };
            int numeroPersonas = 10;

            Persona[] listado = new Persona[numeroPersonas];
            Random random = new Random(1);
            for (int i = 0; i < numeroPersonas; i++)
                listado[i] = new Persona(
                    nombres[random.Next(0, nombres.Length)],
                    apellidos[random.Next(0, apellidos.Length)],
                    apellidos[random.Next(0, apellidos.Length)]
                    );
            return listado;
        }

        /// <summary>
        /// Muestra una colección de personas por consola
        /// </summary>
        static void MostrarPersonas(IEnumerable<Persona> personas)
        {
            foreach (Persona persona in personas)
            {
                Console.WriteLine(persona);
            }
            Console.WriteLine();
        }

        }

  

       
    }


  
