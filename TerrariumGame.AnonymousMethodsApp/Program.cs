using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.AnonymousMethodsApp
{

    class Program
    {
        delegate int ValueDel(int i);

        static void Main(string[] args)
        {
            ValueDel del = ValueIncr;
            ValueDel anonymousDel = delegate(int i)
            {
                return ++i;
            };
            ValueDel lambdaDel = (i) => ++i;
            Console.WriteLine(Fibonacci
                (ValueIncr(del(anonymousDel(lambdaDel(1))))));

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
