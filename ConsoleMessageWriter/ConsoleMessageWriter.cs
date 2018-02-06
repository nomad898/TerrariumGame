using System;
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
        /// <summary>
        ///     This method prints message to Console
        /// </summary>
        /// <param name="message">Message from employee</param>
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        ///     This method sets cursor to certain position and prints message.
        /// </summary>
        /// <param name="message">Message from employee</param>
        /// <param name="msgType">Message type</param>
        public void PrintMessage(string message, MessageType msgType)
        {
            if (msgType == MessageType.ConversationMsg)
            {
                Console.SetCursorPosition(Map.Width + 10, 2);
                if (message != string.Empty)
                {
                    PrintMessage(message);
                    Thread.Sleep(500);
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
