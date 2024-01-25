using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen24Abril2020TPP
{
    public class ListaObjetos<T> : IEnumerable<T>
    {
        private Nodo<T> cabecera = null;
        private Nodo<T> final = null;
        public int NumberOfElements { get; set; }

        //Añade elementos en una posicion por parametro
        public void Add(int posicion, T elemento)
        {
            if(posicion > NumberOfElements || posicion < 0)
            {
                throw new IndexOutOfRangeException();
            }

            Nodo<T> nodoNuevo = new Nodo<T>();
            nodoNuevo.siguiente = null;
            nodoNuevo.Info = elemento;

            if(NumberOfElements == 0)
            {
                cabecera = nodoNuevo;
            }

            if(posicion == 0)
            {
                nodoNuevo.Siguiente = cabecera;
                cabecera = nodoNuevo;
            }
            else
            {
                Nodo<T> nodoAux = cabecera;

                for(int i = 0; i < posicion - 1; i++)
                {
                    nodoAux = nodoAux.Siguiente;
                }

                nodoNuevo.Siguiente = nodoAux.Siguiente;
                nodoAux.Siguiente = nodoNuevo;
            }
            NumberOfElements++;
        }

        //Añade elementos al final de la lista
        public void Add(T info)
        {
            Nodo<T> nodoNuevo = new Nodo<T>();
            nodoNuevo.siguiente = null;
            nodoNuevo.Info = info;

            if(NumberOfElements == 0)
            {
                cabecera = nodoNuevo;
            }
            Nodo<T> nodoAux = cabecera;

            for(int i = 0; i < NumberOfElements - 1; i++)
            {
                nodoAux = nodoAux.Siguiente;
            }
            nodoAux.Siguiente = nodoNuevo;
            nodoNuevo.Siguiente = null;
            NumberOfElements++;
        }

        //Metodo usado en la cola concurrente que inserta al final
        public void AddLast(T valor)
        {
            Nodo<T> nodoNuevo = new Nodo<T>();
            nodoNuevo.Info = valor;

            if(NumberOfElements == 0)
            {
                cabecera = nodoNuevo;
                final = nodoNuevo;
            }
            else
            {
                final.Siguiente = nodoNuevo;
                final = nodoNuevo;
            }

            NumberOfElements++;
        }

        //Metodo usado para extraer un elemento en la cola concurrente
        public T Extraer()
        {
            T valor = default(T);

            if(NumberOfElements != 0)
            {
                valor = cabecera.Info;
                cabecera = cabecera.Siguiente;
                NumberOfElements--;
            }

            return valor;
        }

        //Borra el elemento dada una posicion
        public void Remove(int posicion)
        {
            if(posicion > NumberOfElements - 1 || posicion < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if(posicion == 0)
            {
                cabecera = cabecera.Siguiente;
            }
            else
            {
                Nodo<T> nodoAux = cabecera;

                for(int i = 0; i < posicion - 1; i++)
                {
                    nodoAux = nodoAux.Siguiente;
                }

                nodoAux.Siguiente = nodoAux.Siguiente.Siguiente;
            }

            NumberOfElements--;
        }
        public bool Remove(T elem)
        {
            bool borrado = false;
            int posicion = GetPosicion(elem);
            if (posicion > NumberOfElements - 1)
            {
                throw new IndexOutOfRangeException();
            }

            if (posicion == 0)
            {
                cabecera = cabecera.Siguiente;
                borrado = true;
                NumberOfElements--;
            }
            else if(posicion > 0)
            {
                Nodo<T> nodoAux = cabecera;

                for (int i = 0; i < posicion - 1; i++)
                {
                    nodoAux = nodoAux.Siguiente;
                }

                nodoAux.Siguiente = nodoAux.Siguiente.Siguiente;

                borrado = true;
                NumberOfElements--;
            }
            

            return borrado;
        }

        //Devuelve el elemento de una posicion dada
        public T GetElement(int posicion)
        {
            if(posicion > NumberOfElements || posicion < 0)
            {
                throw new IndexOutOfRangeException();
            }

            Nodo<T> nodoAux = cabecera;

            for(int i = 0; i < posicion; i++)
            {
                nodoAux = nodoAux.Siguiente;
            }

            return nodoAux.Info;
        }

        public int GetPosicion(T elemento)
        {
            bool encontrado = false;
            int pos = -1;
            for(int i = 0; i < NumberOfElements; i++)
            {
                if(GetElement(i).Equals(elemento) && !encontrado)
                {
                    encontrado = true;
                    pos = i;
                }
            }

            return pos;
        }

        public bool Contains(T o)
        {
            for(int i = 0; i < NumberOfElements; i++)
            {
                if(GetElement(i).Equals(o))
                {
                    return true;
                }
            }

            return false;
        }

        //Metodo ToString de la lista 
        override
        public String ToString()
        {
            string cadena = "";

            for(int i = 0; i < NumberOfElements; i++)
            {
                cadena += GetElement(i).ToString() + "\t";
            }
            return cadena;
        }

        internal class EnumeradorLista<S> : IEnumerator<S>
        {
            Nodo<S> actual;
            Nodo<S> cabeza;
            int numeroElementos = 0;

            public EnumeradorLista(Nodo<S> cabeza, int numeroElementos)
            {
                this.numeroElementos = numeroElementos;
                this.cabeza = cabeza;
                Reset();
            }


            S IEnumerator<S>.Current
            {
                get
                {
                    return actual.Info;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return actual.Info;
                }
            }

            public void Dispose()
            {
                actual = null;
            }

            public bool MoveNext()
            {
                if(numeroElementos <= 0)
                {
                    return false;
                }

                if(actual == null)
                {
                    actual = cabeza;
                    return true;
                }
                else if(actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                    return true;
                }
                else { return false; }
            }

            public void Reset()
            {
                actual = null;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeradorLista<T>(cabecera, NumberOfElements);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new EnumeradorLista<T>(cabecera, NumberOfElements);
        }

        //Método Buscar
        public T Find(Predicate<T> f)
        {
            var resultado = this.FirstOrDefault(x=> f(x));
            return resultado;
        }

        //Método Filtrar
        public IEnumerable<T> Filter(Predicate<T> f)
        {
            return this.Where(x => f(x));
        }

        public K Reduce<K>(Func<K,T,K> f, K r = default(K))
        {
            return this.Aggregate(r, f);
        }
        //Método Invertir
        public IEnumerable<T> Invert()
        {
            IEnumerable<T> lista = this.Reverse();
            return lista;
        }

        //Método Map
        public IEnumerable<K> Map<K>(Func<T, K> f)
        {
            return this.Select(f);
        }

        //Método ForEach
        public void ForEach(Action<T> accion)
        {
            foreach(T x in this)
            {
                accion(x);
            }
        }
    }//CLASE

} //NAMESPACE