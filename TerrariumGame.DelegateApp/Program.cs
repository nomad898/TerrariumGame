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
            msgKeeper.Changed += ShowMessage;
            msgKeeper.Showed += ShowMessage;


        }

        private static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
