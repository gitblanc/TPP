using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clases
{
    public class FibonacciLazy : IFibonacci
    {
        public IEnumerable<int> Fibonacci(int n)
        {
            return InfiniteFibonacci().Take(n - 1);//sino coge uno más
        }

        private IEnumerable<int> InfiniteFibonacci()
        {
            int first = 1, second = 1;
            while (true)
            {
                yield return first;
                int addition = first + second;
                first = second;
                second = addition;
            }
        }
    }
}
