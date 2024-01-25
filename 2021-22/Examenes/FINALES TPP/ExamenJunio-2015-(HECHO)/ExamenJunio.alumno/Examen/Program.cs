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
        static int[] vector;
        static void Main(string[] args)
        {
            //Inicio de variables
            //Ejercicio1
            Persona[] personas = CrearPersonas();
            IEnumerable<Persona> personasUnicas;

            //Ejercicio2
            vector = CrearVectorAleatorio(15, 0, 15);
            int[] vectorEspejo;

            //Ejercicio3
            Model m = new Model();
           
            //INVOCACIONES A LOS EJERCICIOS

            // Ejercicio 1a.        
            System.Console.WriteLine("Ejercicio1a");
            System.Console.WriteLine("Personas original");
            MostrarPersonas(personas);


            personasUnicas = personas.EvitarRepetidos();

            System.Console.WriteLine("Personas sin repeticiones");
            //Descomentar cuando se tenga hecho el cálculo de personasUnicas
            MostrarPersonas(personasUnicas);

            // Ejercicio 1b.
            System.Console.WriteLine("Ejercicio1b");
            System.Console.WriteLine("Personas original");
            MostrarPersonas(personas);

            //Invoque aquí al método correspondiente al ejercicio 1b
            personasUnicas = UnicasSup<Persona>(personas, (x, y) => x.Nombre == y.Nombre);

            System.Console.WriteLine("Personas sin repeticiones");
            //Descomentar cuando se tenga hecho el cálculo de personasUnicas
            MostrarPersonas(personasUnicas);

			 // Ejercicio 2.
            System.Console.WriteLine("Ejercicio2");

            int edadAcumulada = ejercicio2(m);
            System.Console.WriteLine("Edad Acumulada");
            System.Console.WriteLine(edadAcumulada);

            // Ejercicio 3.
            System.Console.WriteLine("Ejercicio3");
            System.Console.WriteLine("Vector Original");
            MostrarVector(vector);

            vectorEspejo = ejercicio3(3,vector);

            System.Console.WriteLine("Vector Espejo");
            //Descomentar cuando se tenga hecho el cálculo de vectorEspejo
            MostrarVector(vectorEspejo);

	
            Intercambiar(0, 7, ref vector);
            //vector2 = Intercambiar(3, 3, 8, vector2);
            //vector2 = Intercambiar(3, 6, 8, vector2);
            MostrarVector(vector);
        }



        //Ejercicio 1a, Defina aquí el método principal para este ejercicio.


      public static IEnumerable<T> UnicasSup<T>(IEnumerable<T> personas, Func<T,T,bool> f)
        {
            IList<T> res = new List<T>();
            bool repetido = false;
            foreach (var item in personas)
            {
				repetido = false;
                foreach (var item2 in res)
                    if (f(item,item2))
                    {
                        repetido = true;
                        break;
                    }
                if (!repetido)
                    res.Add(item);
            }

            return res;
        }


        //Ejercicio2. Modifique según necesite.
        public static int ejercicio2(Model m)
        {
            var res = m.Employees.Where(x => x.Province.ToLower().Equals("asturias") && x.Department!=null && x.Department.Name.ToLower().Equals("computer science"));
            
            return res.Sum(x=> x.Age);
        }

        //Ejercicio3. Modifique según necesite.
        public static int[] ejercicio3(int n, int[]vector) 
        {        
            var centro = vector.Length / 2;
            var inicio = 0;
			var hasta=n;
           Action[] actions = new Action[n];
            for (int i = 0; i < n; i++)
            {
                actions[i] = (() => Intercambiar(inicio,hasta,  ref vector));

                inicio += n;
				if(hasta<centro)
				{
					hasta+=n;
				}else
				{
					hasta=centro-1;
				}
            }

            Parallel.Invoke(actions); 
            MostrarVector(vector);
            return vector;
   
        }
		//ejercicio 3 realizado con Hilos----------------
	public static int[] ejercicio3V2(int n, int[]vector) 
        {        
            var centro = vector.Length / 2;
            var inicio = 0;
			var hasta=n;
			Thread[] hilos = new Thread[n];
            for (int i = 0; i < n; i++)
            {
                hilos[i] = new Thread(() => Intercambiar(inicio,hasta,  ref vector));
                inicio += n;
				if(hasta<centro)
				{
					hasta+=n;
				}else
				{
					hasta=centro-1;
				}
				hilos[i].start();
            }
			for (int i = 0; i < hilos.Count(); i++)
			{
				hilos[i].Join();
			}
            MostrarVector(vector);
            return vector;
        }
		//inicio =3, hasta=6 -> segundo hilo
        public static void Intercambiar(int inicio,int hasta, ref int[]  vector)
        {
            int aux = 0;
            for (int i = inicio; i <hasta ; i++)
            {
				lock(ob){
					if (i < vector.Count()) { 
					aux = vector[i];
					vector[i] = vector[vector.Count()-i-1];
					vector[vector.Count()-i-1] = aux;
				}
			}
            }
            

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


  
