using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModeloClases
{
    public static class ProcesadorTextos
    {
        /// <summary>
        /// Lee un fichero
        /// </summary>
        /// <param name="fileName">Nombre del fichero de entrada</param>
        /// <returns>String con el texto del fichero</returns>
        public static String LeerFicheroTexto(string nombreFichero)
        {
            using (StreamReader stream = File.OpenText(nombreFichero))
            {
                StringBuilder text = new StringBuilder();
                string linea;
                while ((linea = stream.ReadLine()) != null)
                {
                    text.AppendLine(linea);
                }
                return text.ToString();
            }
        }

        /// <summary>
        /// Devuelve el número de signos de puntuación ( . , ; : ) en el texto.
        /// </summary>
        public static int ContarSignosPuntuacion(string text)
        {
            return text.Count(c => c == '.' || c == ',' || c == ';' || c == ':');
        }

        /// <summary>
        /// Divide un texto en palabras
        /// </summary>
        public static string[] DividirEnPalabras(String texto)
        {
            return texto.Split(new char[] { ' ', '\r', '\n', ',', '.', ';', ':', '-', '!', '¡', '¿', '?', '/', '«',
                                            '»', '_', '(', ')', '\"', '*', '\'', 'º', '[', ']', '#' },
                StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Método genérico que muestra los elemenos de una colección.
        /// Recibe el máximo número de elementos a mostrar.
        /// </summary>
        public static void Mostrar<T>(IEnumerable<T> coleccion, TextWriter stream, int maxNumeroElementos)
        {
            int i = 0;
            foreach (T elemento in coleccion)
            {
                stream.Write(elemento);
                i = i + 1;
                if (i == maxNumeroElementos)
                {
                    stream.Write("...");
                    break;
                }
                if (i < coleccion.Count())
                    stream.Write(", ");
            }
        }

        /// <summary>
        /// Método que cuenta el número de veces que aparece cada palabra
        /// </summary>
        /// <param name="palabras"></param>
        /// <returns></returns>
        public static string[] ContarPalabras(string[] palabras)
        {
            var res = palabras.AsParallel().GroupBy(p => p.ToLower())
                .Select(grupo => new
                {
                    Palabra = grupo.Key,
                    Repeticiones = grupo.Count()
                })
                .Select(a => $"{a.Palabra} {a.Repeticiones}").ToArray();
            return res;
        }
    }
}
