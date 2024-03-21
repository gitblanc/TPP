using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloClases
{
    // Programación por contrato
    public class MyStack<T>
    {
        private uint _maxNumberOfElems;
        private LinkedList<T> _list;

        public bool IsEmpty => _ = _list.NumberOfElements == 0;

        public bool IsFull => _ = _maxNumberOfElems == _list.NumberOfElements;

        public MyStack(uint elems)
        {
            if (elems < 1)
                throw new ArgumentException("Has de tener capacidad de al menos un elemento");
            _maxNumberOfElems = elems;
            _list = new LinkedList<T>();
#if DEBUG            
            // Invariantes
            Invariant();
#endif
        }

        public bool Push(T data)
        {
            // Precondiciones
            if (_maxNumberOfElems == _list.NumberOfElements)
                throw new ArgumentOutOfRangeException("La pila está llena");

            int previous = _list.NumberOfElements;
            _list.Add(data);
#if DEBUG
            // PostCondiciones
            Debug.Assert(_list.NumberOfElements > previous); // Asegurarnos de que se incrementó el número de elementos

            // Invariante
            Invariant();
#endif
            return true;
        }

        public T Pop()
        {
            // Precondiciones
            if (_list.NumberOfElements == 0)
                throw new ArgumentOutOfRangeException("La pila está vacía");

            T toPop = _list.GetElement(_list.NumberOfElements - 1);
            int previous = _list.NumberOfElements;
            bool result = _list.RemoveByPos(_list.NumberOfElements - 1);
#if DEBUG
            // Postcondiciones
            Debug.Assert(result);
            Debug.Assert(previous > _list.NumberOfElements);

            //Invariante
            Invariant();
#endif
            return toPop;
        }

#if DEBUG
        private void Invariant()
        {
            Debug.Assert(_maxNumberOfElems >= 0);
            Debug.Assert(_maxNumberOfElems >= _list.NumberOfElements);
            Debug.Assert(_list != null);
        }
#endif
        public override string ToString()
        {
            return $"|Stack| {_list}";
        }

    }
}
