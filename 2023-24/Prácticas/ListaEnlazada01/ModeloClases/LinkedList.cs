using System;
using System.Text;

namespace ModeloClases
{
    public class LinkedNode
    {
        public int Data { get; set; }

        public LinkedNode Next { get; set; }

        public LinkedNode(int data)
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
        public LinkedNode Head
        {
            get { return _head; }
            set { _head = value; }
        }

        //Constructor
        public LinkedList()
        {
            Head = null;
            _numelems = 0;
        }

        public void Add(int node)
        {
            // Considero que se pueden añadir elementos repetidos
            LinkedNode newNode = new(node);
            if (Head == null)
            {
                newNode.Next = null;
                Head = newNode;
            }
            else
            {
                LinkedNode current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            _numelems += 1;
        }

        public void Remove(int node)
        {
            LinkedNode toDelete = GetElement(node);
            if (toDelete != null)
            { // El nodo a eliminar existe
                if (toDelete == Head)//si el nodo a borrar es el primero
                {
                    Head = Head.Next;
                }
                else
                {
                    LinkedNode current = Head;
                    LinkedNode previous = null;

                    while (current != null && current.Data != node)
                    {
                        previous = current;
                        current = current.Next;
                    }

                    if (previous == null)//Si borramos la cabeza
                        Head = current.Next;
                    else
                        previous.Next = current.Next;
                }
                _numelems -= 1;
            }
        }

        public LinkedNode GetElement(int node)
        {
            LinkedNode current = Head;
            //mientras aún haya elementos y no se encuentre el que se desea
            while (current != null && current.Data != node)
            {
                current = current.Next;
            }

            return current;
        }

        public override string ToString()
        {
            StringBuilder cad = new();
            LinkedNode current = Head;

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
