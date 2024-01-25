using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Julio2013
{
    class Program
    {

        static string[] permisos = { "ACCESO_SSOO", "VER_PERFIL_USUARIO",
                                        "VER_CORREOS_USUARIO", "USAR_CAMARA"};

        static void Mostrar(IEnumerable<Aplicacion> apps)
        {
            foreach (Aplicacion a in apps)
                Console.WriteLine(a);
        }

        static IEnumerable<DatosApp> Init(int numeroDeAplicaciones)
        {
            var datos = new DatosApp[numeroDeAplicaciones];
            int cont = 0;
            for (int i = 0; i < numeroDeAplicaciones; i++)
                datos[i] = DatosApp.randomDatosAppFactory(cont++, permisos);
            return datos;
        }

        //----------------------------------------------------

        // Ejercicio 1----------------------------------------------------------------------
        public static Q CrearDatosAplicacion<T, Q>(Q aplicaciones, IEnumerable<T> datosApp, int n, Func<Q, T, Q> f)
        {
            Q acum = aplicaciones;
            for (int i = 0; i < n; i++)
            {
                acum = f(acum, datosApp.ElementAt(i));
            }
            return acum;
        }

        // Ejercicio 2. Hacer la versión con un Init (lazy) y método de extensión
        static IEnumerable<DatosApp> InitLazyInfinito()
        {
            int cont = 0;
            while (true)
            {
                yield return DatosApp.randomDatosAppFactory(cont++, permisos);
            }
        }

        static IEnumerable<DatosApp> InitLazy(int desde, int numeroDeAplicaciones)
        {
            return InitLazyInfinito().Skip(desde).Take(numeroDeAplicaciones);
        }

        //Ejercicio 4---------------------------------------

        static void ejercicio4(IEnumerable<Aplicacion> aplicaciones)
        {
            IDictionary<string, List<string>> resultado4 = new Dictionary<string, List<string>>();
            resultado4 = aplicaciones.Aggregate<Aplicacion, IDictionary<String, List<string>>>(resultado4,
            (dic, apli) =>
            {
                var permisos = apli.Permisos;
                foreach (String p in permisos)
                {
                    if (p != null && resultado4.ContainsKey(p))
                    {
                        resultado4[p].Add(apli.Nombre);
                    }
                    else
                    {
                        List<string> lista = new List<string>();
                        lista.Add(apli.Nombre);
                        if(p != null)
                            resultado4.Add(p, lista);
                    }
                }
                return resultado4;
            });

            
            foreach (KeyValuePair<String, List<string>> d in resultado4)
            {
                Console.Write(d.Key + " -> ");
                foreach (string p in d.Value)
                {
                    Console.Write(p + ", ");
                }
                Console.WriteLine();
            }
            
        }

        //BLOQUE 2-------------------------------------
        static void hilo1(IDictionary<string, Aplicacion> diccinonario, IEnumerable<Aplicacion> aplicaciones)
        {
            Object ob = new Object();
            foreach (Aplicacion a in aplicaciones)
            {
                var permiso = a.Permisos.FirstOrDefault(p => p != null && p.Equals("VER_PERFIL_USUARIO"));

                if (permiso != null && a.MB > 10)
                {
                    lock (ob)
                    {
                        a.AddPermiso("ACCESO_DATOS_PERSONALES");
                        a.IncrementarNumeroDeRevisiones();
                        if (!diccinonario.ContainsKey(a.Nombre))
                        {
                            diccinonario.Add(a.Nombre, a);

                        }
                    }
                }
            }
        }

        static void hilo2(IDictionary<string, Aplicacion> diccinonario, IEnumerable<Aplicacion> aplicaciones)
        {
            Object ob = new Object();
            foreach (Aplicacion a in aplicaciones)
            {
                var permiso = a.Permisos.FirstOrDefault(p => p != null && p.Equals("USAR_CAMARA"));

                if (permiso != null)
                {
                    lock (ob)
                    {
                        a.AddPermiso("ACCESO_DISPOSITIVOS");
                        a.IncrementarNumeroDeRevisiones();
                        if (!diccinonario.ContainsKey(a.Nombre))
                        {
                            diccinonario.Add(a.Nombre, a);

                        }
                    }
                }
            }
        }

        static void hilo3(IDictionary<string, Aplicacion> diccinonario, IEnumerable<Aplicacion> aplicaciones)
        {
            Object ob = new Object();
            foreach (Aplicacion a in aplicaciones)
            {
                    lock (ob)
                    {
                        a.AddPermiso("ESCRIBIR_TAREA_SD");
                        a.IncrementarNumeroDeRevisiones();
                        if (!diccinonario.ContainsKey(a.Nombre))
                        {
                            diccinonario.Add(a.Nombre, a);

                        }
                    }
            }
        }

        public void ejercicio5(IDictionary<string, Aplicacion> diccinonario, IEnumerable<Aplicacion> aplicaciones)
        {
            Thread h1 = new Thread(() => hilo1(diccinonario, aplicaciones));
            Thread h2 = new Thread(() => hilo2(diccinonario, aplicaciones));
            Thread h3 = new Thread(() => hilo3(diccinonario, aplicaciones));
            h1.Start();
            h2.Start();
            h3.Start();
            h1.Join();
            h2.Join();
            h3.Join();
        }

        public static void ejercicio5TPL(IDictionary<string, Aplicacion> diccinonario,
                           IEnumerable<Aplicacion> aplicaciones)
        {

            Parallel.Invoke(
                  () => hilo1(diccinonario, aplicaciones),
                  () => hilo2(diccinonario, aplicaciones),
                  () => hilo3(diccinonario, aplicaciones)
                  );
        }

        static void Main(string[] args)
        {
            var datosApp = Init(10); //IEnumerable<DatosApp>

            /*
            
            //-Ejercicio 1-------Prueba-----------------------
            Console.WriteLine("\n\n----------------------Ejercicio 1------------------------------");
            IList<Aplicacion> listaAplicaciones = new List<Aplicacion>();
            int n = 0;
            IEnumerable<Aplicacion> aplicaciones = CrearDatosAplicacion<DatosApp, IList<Aplicacion>>(listaAplicaciones, datosApp, 10,
            (listaA, d) =>
            {
                Aplicacion apli = new Aplicacion("Aplicacion" + n, (int)(d.Numero * 0.20));
                listaA.Add(apli);
                n++;
                return listaA;
            });
            Mostrar(aplicaciones);

            //-Ejercicio 2---------Prueba------------------
            Console.WriteLine("\n\n----------------------Ejercicio 2------------------------------");
            var datosAppLazy = InitLazy(0, 10);

            foreach (DatosApp a in datosAppLazy)
                Console.Write(a.Numero + " , ");
            Console.WriteLine();

            Console.WriteLine("\n\n----------------------Ejercicio 3 (UNA FUNCION)---------------------------");

            aplicaciones.AddPermisos(apli => apli.AddPermiso("VER_CORREOS_USUARIO"));
            Mostrar(aplicaciones);

            IEnumerable<Aplicacion> aplicacionesFinal = new List<Aplicacion>();

            aplicacionesFinal = aplicaciones.ProcesadorAplicaciones(apli =>
            {
                var permiso = apli.Permisos.FirstOrDefault(p => p != null && p.Equals("VER_CORREOS_USUARIO")
                || p.Equals("VER_PERFIL_USUARIO"));

                if (permiso != null && permiso.Equals("VER_CORREOS_USUARIO"))
                {
                    return true;
                }
                else return false;

            }, apli =>
            {
                apli.AddPermiso("DESISTALAR_A_PETICION_DEL_USUARIO");
            });

            Mostrar(aplicacionesFinal);
            

            Console.WriteLine("\n\n----------------------Ejercicio 4------------------------------");
            ejercicio4(listaAplicaciones);

            */

            IDictionary<string, Aplicacion> diccionario = new Dictionary<string, Aplicacion>();
            IEnumerable<Aplicacion> aplicaciones = new Aplicacion[20];
            ejercicio5TPL(diccionario, aplicaciones);


        }
    }
}
