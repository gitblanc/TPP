using System;
using System.Text;
using System.Threading;

namespace ModeloClases
{
    public class LinkedNode
    {
        public object Data { get; set; }

        public LinkedNode Next { get; set; }

        public LinkedNode(object data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedList
    {
        private int _numelems;
        public int NumberOfElements
        {
            get { return _numelems; }
        }

        private LinkedNode _head;

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
        public void Add(object data)
        {
            // Considero que se pueden añadir elementos repetidos
            LinkedNode newNode = new(data);
            if (_numelems == 0)
            {
                newNode.Next = null;
                _head = newNode;
            }
            else
            {
                LinkedNode current = _head;
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
        public int IndexOf(object data)
        {
            LinkedNode current = _head;
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
        public object GetElement(int pos)
        {
            LinkedNode current = _head;
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
                    return null;

                return current.Data;
            }
        }

        /// <summary>
        /// Método que elimina un dato de la LinkedList
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True si lo elimina, False si no lo elimina</returns>
        public bool Remove(object data)
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
            if (_head.Data == null && toDelete == null || toDelete.Equals(_head.Data))
                _head = _head.Next;
            else
            {
                LinkedNode current = _head;
                LinkedNode previous = null;

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
        /// Método que devuelve si la LinkedList contiene el elemento indicado
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True/False</returns>
        public bool ContainsElement(object data)
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
            LinkedNode current = _head;

            while (current != null)
            {
                cad.Append($"[{current.Data}]->");
                current = current.Next;
            }
            cad.AppendLine($"null, elems: {NumberOfElements}");
            return cad.ToString();
        }
    }
}
