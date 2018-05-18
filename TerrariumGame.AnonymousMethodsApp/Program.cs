using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.AnonymousMethodsApp
{

    class Program
    {
        delegate int FibonacciDel(int i);

        static void Main(string[] args)
        {
            FibonacciDel anonymousDel = delegate (int i)
            {
                return i > 1 ?
                    Fibonacci(i - 1) + Fibonacci(i - 2) : i;
            };

            Console.WriteLine(anonymousDel(7));

            FibonacciDel lambdaDel = (int i) =>
            {
                return i > 1 ?
                    Fibonacci(i - 1) + Fibonacci(i - 2) : i;
            };

            Console.WriteLine(lambdaDel(7));

            Console.WriteLine(Fibonacci(7));

            Console.ReadKey(true);
        }

        public static int Fibonacci(int i)
        {
            return i > 1 ?
                Fibonacci(i - 1) + Fibonacci(i - 2) : i;
        }
    }
}
