using System;
using System.Collections.Generic;
using System.Text;

namespace clases
{
    public class FibonacciEager : IFibonacci
    {
        public IEnumerable<int> Fibonacci(int n)
        {
            var l = new List<int>();
            for (int i = 1; i < n; i++)
            {
                l.Add(LimitedFibonacci(i));
            }
            return l;
        }

        private int LimitedFibonacci(int n)
        {
            return n <= 2 ? 1 : LimitedFibonacci(n - 2) + LimitedFibonacci(n - 1);
        }
    }
}
