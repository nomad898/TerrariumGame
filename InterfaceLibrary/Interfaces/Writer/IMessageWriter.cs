using InterfaceLibrary.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary.Interfaces.Writer
{
    public interface IMessageWriter
    {
        void PrintMessage(string message);
        void PrintMessage(string message, MessageType msgType);
    }
}
