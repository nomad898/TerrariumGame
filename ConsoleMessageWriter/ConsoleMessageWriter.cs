using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLibrary.Interfaces.Writer;
using InterfaceLibrary.UtilityModels;
using InterfaceLibrary.Interfaces;
using System.Threading;

namespace MessageWriter
{
    public class ConsoleMessageWriter : IMessageWriter
    {
        #region Fields
        public IMap Map
        {
            get
            {
                return map;
            }
        }

        private IMap map;
        #endregion
        #region Ctor
        public ConsoleMessageWriter(IMap map)
        {
            this.map = map;
        }
        #endregion
        #region IMessageWriter
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintMessage(string message, MessageType msgType)
        {
            if (msgType == MessageType.ConversationMsg)
            {
                Console.SetCursorPosition(Map.Width + 10, 2);
                if (message != string.Empty)
                {
                    PrintMessage(message);
                    Thread.Sleep(2000);
                    Console.SetCursorPosition(Map.Width + 10, 2);
                    Console.WriteLine(new string(' ', 100));
                }
                else
                {
                    PrintMessage(message);
                }
            }
            else if (msgType == MessageType.MapInfoMsg)
            {
                throw new NotImplementedException();
            }
        }
        #endregion
    }
}
