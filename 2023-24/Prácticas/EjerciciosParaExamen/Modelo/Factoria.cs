using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Factoria
    {
        public static Persona[] CrearPersonas()
        {
            string[] nombres = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina", "María", "Juan" };
            string[] apellidos1 = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez", "Díaz", "Hevia" };
            string[] nifs = { "9876384A", "103478387F", "23476293R", "4837649A", "67365498B", "98673645T", "56837645F", "87666354D", "9376384K" };
            int[] edades = { 15, 16, 17, 18, 19, 20, 21, 22, 23 };
            Persona[] personas = new Persona[nombres.Length];
            for (int i = 0; i < personas.Length; i++)
                personas[i] = new Persona(nombres[i], apellidos1[i], nifs[i], edades[i]);
            return personas;
        }

        public static Persona[] CrearOtrasPersonas()
        {
            string[] nombres = { "Pepe", "Aceituno", "Pepe", "Luis", "Carlos", "Miguel", "Maleandro", "Coyote", "Juan" };
            string[] apellidos1 = { "Díaz", "Pérez", "Hevia", "García", "Rodrígaez", "Pérez", "Sánchez", "Díaz", "Hevia" };
            string[] nifs = { "9876384A", "103478387F", "23476293R", "4837649A", "67365498B", "98673645T", "56837645F", "87666354D", "9376384K" };
            int[] edades = { 15, 16, 17, 18, 19, 20, 21, 22, 23 };
            Persona[] personas = new Persona[nombres.Length];
            for (int i = 0; i < personas.Length; i++)
                personas[i] = new Persona(nombres[i], apellidos1[i], nifs[i], edades[i]);
            return personas;
        }

        public static Angulo[] CrearAngulos()
        {
            Angulo[] angulos = new Angulo[361];
            for (int angulo = 0; angulo <= 360; angulo++)
                angulos[angulo] = new Angulo(angulo / 180.0 * Math.PI);
            return angulos;
        }

        public static PuntoDeInteres[] CrearPuntosInteres()
        {
            string[] nombres = { "p1", "p2", "p3", "p4", "p5", "p6", "p7", "p8", "p9" };
            double[] latitudes = { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9 };
            double[] longitudes = { 0.01, 0.02, 0.03, 0.04, 0.05, 0.06, 0.07, 0.08, 0.09 };
            PuntoDeInteres[] ptos = new PuntoDeInteres[nombres.Length];
            for (int i = 0; i < ptos.Length; i++)
                ptos[i] = new PuntoDeInteres(latitudes[i], longitudes[i], nombres[i]);
            return ptos;
        }

        public static LinkedList<Persona> MyCrearPersonas()
        {
            string[] nombres = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina", "María", "Juan" };
            string[] apellidos1 = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez", "Díaz", "Hevia" };
            string[] nifs = { "9876384A", "103478387F", "23476293R", "4837649A", "67365498B", "98673645T", "56837645F", "87666354D", "9376384K" };
            int[] edades = { 15, 16, 17, 18, 19, 20, 21, 22, 23 };
            LinkedList<Persona> personas = new LinkedList<Persona>();
            for (int i = 0; i < edades.Length; i++)
                personas.Add(new Persona(nombres[i], apellidos1[i], nifs[i], edades[i]));
            return personas;
        }

        public static object[] CrearArrayPersonasPtosInteres()
        {
            Persona[] p = CrearPersonas();
            PuntoDeInteres[] ptos = CrearPuntosInteres();
            object[] result = new object[p.Length * 2];
            for (int i = 0; i < p.Length; i++)
                result[i] = p[i];
            for (int i = 0; i < ptos.Length; i++)
                result[i + p.Length] = ptos[i];
            return result;
        }
    }
}
