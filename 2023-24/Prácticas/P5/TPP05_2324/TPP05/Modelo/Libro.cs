using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Libro
    {
        public string Titulo{ get; }
        public string Autor { get;}

        public int NumPaginas { get;}

        public int YearPublicacion { get;}

        public string Genero { get;}

        public Libro(string titulo, string autor, int numPaginas, int yearPublicacion, string genero)
        {
            Titulo = titulo;
            Autor = autor;
            NumPaginas = numPaginas;
            YearPublicacion = yearPublicacion;
            Genero = genero;
        }
    }
}
