using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.XPath;

namespace Modelo
{
    // Genérica
    public class LinkedNode<T>
    {
        public T Data { get; set; }

        public LinkedNode<T> Next { get; set; }

        public LinkedNode(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        private int _numelems;
        public int NumberOfElements
        {
            get { return _numelems; }
        }

        private LinkedNode<T> _head;

        //Constructor
        public LinkedList()
        {
            _head = null;
            _numelems = 0;
        }

        /// <summary>
        /// Método que permite añadir un elemento a la LinkedList
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            // Se pueden añadir elementos repetidos
            LinkedNode<T> newNode = new(data);
            if (_numelems == 0)
            {
                newNode.Next = null;
                _head = newNode;
            }
            else
            {
                LinkedNode<T> current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            _numelems += 1;
        }

        /// <summary>
        /// Método que permite averiguar la posición de un dato en la LinkedList
        /// </summary>
        /// <param name="data"></param>
        /// <returns>-1 si no existe o la posición del elemento si existe</returns>
        public int IndexOf(T data)
        {
            LinkedNode<T> current = _head;
            int cont = 0;
            while (current != null)
            {
                if (data == null && current.Data == null)
                {
                    return cont;
                }
                else
                {
                    if (current.Data != null && current.Data.Equals(data))
                        return cont;
                }
                current = current.Next;
                cont += 1;
            }

            return -1;
        }

        /// <summary>
        /// Método que devuelve el valor de un elemento en la posición dada de la LinkedList
        /// </summary>
        /// <param name="pos"></param>
        /// <returns>El valor de un objeto (si existe), null si no existe</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public T GetElement(int pos)
        {
            LinkedNode<T> current = _head;
            if (pos >= _numelems)
                throw new IndexOutOfRangeException("EXCEPCION: La posición no es válida");
            else
            {
                int cont = 0;
                while (current != null)
                {
                    if (cont == pos)
                        break;
                    current = current.Next;
                    cont += 1;
                }
                if (current == null)
                    return default;

                return current.Data;
            }
        }

        /// <summary>
        /// Método que elimina un dato de la LinkedList
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True si lo elimina, False si no lo elimina</returns>
        public bool Remove(T data)
        {
            // La cabeza es null (no hay elementos)
            if (_numelems == 0)
                return false;

            int pos = IndexOf(data);
            if (pos == -1)
                return false;

            object toDelete = GetElement(pos);

            // Si el nodo a borrar es el primero
            // Se tiene en cuenta que se pueda borrar un null (el primero que se encuentra)
            if (_head.Data == null && toDelete == null || toDelete != null && toDelete.Equals(_head.Data))
                _head = _head.Next;
            else
            {
                LinkedNode<T> current = _head;
                LinkedNode<T> previous = null;

                while (current != null)
                {
                    // Si queremos borrar un null
                    if (toDelete == null && current.Data == null)
                        break;
                    // Si queremos borrar otra cosa pero el elemento actual tiene un null como dato
                    if (current.Data != null && current.Data.Equals(toDelete))
                        break;
                    previous = current;
                    current = current.Next;
                }

                previous.Next = current.Next;
            }
            _numelems -= 1;
            return true;
        }

        /// <summary>
        /// Borrado que elimina por posición (para la Pila)
        /// </summary>
        /// <param name="pos"></param>
        /// <returns>true/false</returns>
        public bool RemoveByPos(int pos)
        {
            // La cabeza es null (no hay elementos)
            if (_numelems == 0)
                return false;

            if (pos < 0)
                return false;

            object toDelete = GetElement(pos);
            int cont = 0;

            // Si el nodo a borrar es el primero
            // Se tiene en cuenta que se pueda borrar un null (el primero que se encuentra)
            if (pos == cont && (_head.Data == null && toDelete == null || toDelete != null && toDelete.Equals(_head.Data)))
            {
                _head = _head.Next;
            }
            else
            {
                LinkedNode<T> current = _head;
                LinkedNode<T> previous = null;

                while (current != null)
                {
                    // Si queremos borrar un null
                    if (cont == pos && toDelete == null && current.Data == null)
                        break;
                    // Si queremos borrar otra cosa pero el elemento actual tiene un null como dato
                    if (cont == pos && current.Data != null && current.Data.Equals(toDelete))
                        break;

                    previous = current;
                    current = current.Next;
                    cont += 1;
                }

                previous.Next = current.Next;
            }
            _numelems -= 1;
            return true;
        }

        /// <summary>
        /// Método que devuelve si la LinkedList contiene el elemento indicado
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True/False</returns>
        public bool ContainsElement(T data)
        {
            return IndexOf(data) != -1;
        }

        /// <summary>
        /// Método ToString() de la clase LinkedList
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder cad = new();
            LinkedNode<T> current = _head;

            while (current != null)
            {
                cad.Append($"[{current.Data}]->");
                current = current.Next;
            }
            cad.AppendLine($"null, elems: {NumberOfElements}");
            return cad.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListGenerator<T>(_head, _numelems);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ListGenerator<T>(_head, _numelems);
        }
    }

    public class ListGenerator<T> : IEnumerator<T>
    {
        private LinkedNode<T> _head, _headCopie;
        private int _numelems;
        private int _count;

        public T Current
        {
            get { return _head.Data; }
        }

        object IEnumerator.Current
        {
            get { return _head.Data; }
        }

        public ListGenerator(LinkedNode<T> head, int numElems)
        {
            _head = _headCopie = head;
            _numelems = numElems;
            Reset(); // Inicializamos el generador
        }

        public void Dispose()
        {
            //¿Debería poner algo aquí?...
        }

        public bool MoveNext()
        {
            int copie = _count;
            if (copie != -1 && copie++ < _numelems)
                _head = _head.Next; //hacemos que el elemento Current sea el siguiente
            return _count++ != _numelems - 1;
        }

        // Pongo -1 porque la lista empieza en el elemento 0
        public void Reset()
        {
            _head = _headCopie; //Reinicializamos el Current al primer elemento de la lista
            _count = -1;
        }
    }
}
