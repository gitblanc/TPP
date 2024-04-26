using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloClases
{
    /*
     * Enlace a cómo depurar con hilos -> https://learn.microsoft.com/en-us/visualstudio/debugger/how-to-use-the-threads-window?view=vs-2022&tabs=csharp
     */

    //Implementación de una cola Thread Safe
    public class ColaConcurrente<T>
    {
        private LinkedList<T> _list;
        // Es más eficiente bloquear la lista directamente
        //private readonly object _obj = new object();// no hace falta poner static porque sólo hay un objeto ColaConcurrente
        public int NumeroElementos
        {
            get
            {
                lock (this._list)
                    return this._list.NumberOfElements;
            }
        }

        public ColaConcurrente()
        {
            _list = new LinkedList<T>();
        }

        /// <summary>
        /// Nos indicará si la cola no posee ningún elemento.
        /// </summary>
        /// <returns></returns>
        public bool EstaVacia()
        {
            return NumeroElementos == 0;
        }

        /// <summary>
        /// Para insertar un elemento en la cola.
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public void Add(T elem)
        {
            lock (this._list)
            {
                _list.Add(elem);
            }
        }

        /// <summary>
        /// Para extraer un elemento de la cola.
        /// </summary>
        /// <returns></returns>
        public T Extract()
        {
            lock (this._list)
            {
                //Pongo la condición dentro para evitar una condición de carrera
                if (NumeroElementos == 0)
                {
                    throw new InvalidOperationException("La cola está vacía");
                }
                var elem = PrimerElemento();
                _list.Remove(elem);
                return elem;
            }
        }

        /// <summary>
        /// Nos devuelve el siguiente elemento que se extraería de la cola si llamásemos a Extraer.
        /// </summary>
        /// <returns></returns>
        public T PrimerElemento()
        {
            lock (this._list)
                return _list.GetElement(0);
        }
    }
}
