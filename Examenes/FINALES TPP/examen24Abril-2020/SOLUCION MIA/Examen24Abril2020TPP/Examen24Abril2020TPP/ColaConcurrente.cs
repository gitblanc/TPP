using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen24Abril2020TPP
{
    public class ColaConcurrente<T>
    {
        private static Object bloqueador = new Object();

        ListaObjetos<T> lista;

        /// <summary>
        /// Constructor de la clase ColaConcurrente
        /// </summary>
        public ColaConcurrente()
        {
            lista = new Lista<T>();
        }

        //Devuelve el numero de elementos de la lista
        public int NumeroElementos()
        {
            return lista.NumberOfElements;
        }

        //Nos dice si la lista está vacía
        public bool EstaVacia()
        {
            return lista.NumberOfElements == 0;
        }

        //Metodo que inserta en la cola
        public void Añadir(T valor)
        {
            Object bloqueador = new Object();

            lock(bloqueador)
            {
                lista.AddLast(valor);
            }
        }

        //Metodo que extrae un elemento de la cola
        public T Extraer()
        {
            T valor = default(T);
            Object bloqueador = new Object();

            lock(bloqueador)
            {
                valor = lista.Extraer();
            }

            return valor;
        }

        //Método Peek de la cola concurrente
        public T PrimerElemento()
        {
            T valor = default(T);

            lock(bloqueador)
            {
                valor = lista.GetElement(0);
            }

            return valor;
        }



    }
}
