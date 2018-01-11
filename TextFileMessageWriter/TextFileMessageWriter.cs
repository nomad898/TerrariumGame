using InterfaceLibrary.Interfaces.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLibrary.UtilityModels;
using System.IO;
using System.Reflection;

namespace MessageWriter
{
    public class TextFileMessageWriter : IMessageWriter
    {
        #region Files
        private readonly string textFilePath = AppDomain.CurrentDomain.BaseDirectory + "Conversation.txt";
        #endregion
        #region Ctor
        public TextFileMessageWriter()
        {
            if (!File.Exists(textFilePath))
            {
                using (StreamWriter sw = File.CreateText(textFilePath))
                {
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(textFilePath, false))
                {
                }
            }
        }
        #endregion
        #region IMessageWriter
        public void PrintMessage(string message)
        {
            using (StreamWriter sw = File.AppendText(textFilePath))
            {
                sw.WriteLine(message);
            }
        }

        public void PrintMessage(string message, MessageType msgType)
        {
            if (msgType == MessageType.ConversationMsg 
                && message != string.Empty)
            {           
                PrintMessage(message + " ---> " + DateTime.Now);                
            }
        }
        #endregion
    }
}
