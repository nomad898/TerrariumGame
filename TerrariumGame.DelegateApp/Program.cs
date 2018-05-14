using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.DelegateInterfaces;
using TerrariumGame.DelegateLibrary;

namespace TerrariumGame.DelegateApp
{
    class Program
    {      
        static void Main(string[] args)
        {
            IMessageKeeper msgKeeper = new MessageKeeper();
            msgKeeper.Message = "Hello, World!";
            msgKeeper.OnChanged += ShowMessage;
            msgKeeper.OnShowed += ShowMessage;
            msgKeeper.OnAdded += AddValue;
            msgKeeper.UnhandleAllDelegates();
            msgKeeper.Message = "String";
            Console.WriteLine(msgKeeper.Message);
            int x;
            msgKeeper.Add("Good luck!", out x);
            Console.WriteLine(x);

            msgKeeper.Message = "Hello, World!";
            msgKeeper.OnChanged += ShowMessage;
            msgKeeper.OnShowed += ShowMessage;
            msgKeeper.OnAdded += AddValue;
            // msgKeeper.UnhandleAllDelegates();
            msgKeeper.Message = "String";
            Console.WriteLine(msgKeeper.Message);
          
            msgKeeper.Add("Good luck!", out x);
            Console.WriteLine(x);

            Console.ReadKey(true);

        }

        private static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static int AddValue(int value)
        {
            return value;
        }
    }
}
