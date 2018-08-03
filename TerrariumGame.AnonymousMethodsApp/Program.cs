using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.AnonymousMethodsApp
{

    class Program
    {
        public delegate int S();
        static void Main(string[] args)
        {                    
            Func<int, int> del = ValueIncr;
            Func<int, int> anonymousDel = delegate(int i)
            {
                return ++i;
            };
            Func<int, int> lambdaDel = (i) => ++i;
            Console.WriteLine("Fibonacci number is" + Fibonacci(
                ValueIncr(del(anonymousDel(lambdaDel(0))))));
        
            Console.ReadKey(true);
        }

        public static int Fibonacci(int i)
        {
            return i > 1 ?
                Fibonacci(i - 1) + Fibonacci(i - 2) : i;
        }

        public static int ValueIncr(int i)
        {
            return ++i;
        }
    }
}
