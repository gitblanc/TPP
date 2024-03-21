﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloClases
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

        public static Angulo[] CrearAngulos()
        {
            Angulo[] angulos = new Angulo[361];
            for (int angulo = 0; angulo <= 360; angulo++)
                angulos[angulo] = new Angulo(angulo / 180.0 * Math.PI);
            return angulos;
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
    }
}
