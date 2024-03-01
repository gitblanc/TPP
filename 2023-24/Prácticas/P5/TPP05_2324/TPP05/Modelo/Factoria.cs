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

        public static Angulo[] CrearAngulos()
        {
            Angulo[] angulos = new Angulo[361];
            for (int angulo = 0; angulo <= 360; angulo++)
                angulos[angulo] = new Angulo(angulo / 180.0 * Math.PI);
            return angulos;
        }

        public static Libro[] CrearLibros()
        {
            string[] titulos = { "tituloA", "tituloB", "tituloC", "tituloD" };
            string[] autores = { "autorA", "autorB", "autorC", "autorD" };
            int[] numpaginas = { 1, 2, 3, 4 };
            int[] years = { 2019, 2020, 2021, 2022 };
            string[] generos = { "generoA", "generoB", "generoC", "generoD" };
            Libro[] libros = new Libro[titulos.Length];
            for (int i = 0; i < libros.Length; i++)
                libros[i] = new Libro(titulos[i], autores[i], numpaginas[i], years[i], generos[i]);
            return libros;
        }
    }
}
