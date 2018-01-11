using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLibrary.Interfaces.Writer;
using InterfaceLibrary.UtilityModels;

namespace MessageWriter
{
    public class ConsoleMessageWriter : IMessageWriter
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintMessage(string message, MessageType msgType)
        {
            Console.WriteLine(message);
        }
    }
}
