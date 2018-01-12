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
        private const string TEXT_FILE_NAME = "Conversation.txt";
        // private readonly string textFilePath = AppDomain.CurrentDomain.BaseDirectory + "Conversation.txt";
        #endregion
        #region Ctor
        public TextFileMessageWriter()
        {
            if (!File.Exists(TEXT_FILE_NAME))
            {
                
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(TEXT_FILE_NAME, false))
                {
                }
            }
        }
        #endregion
        #region IMessageWriter
        public void PrintMessage(string message)
        {
            using (StreamWriter sw = File.AppendText(TEXT_FILE_NAME))
            {
                sw.WriteLine(message);
            }
        }

        public void PrintMessage(string message, MessageType msgType)
        {
            if (msgType == MessageType.ConversationMsg 
                && message != string.Empty)
            {           
                PrintMessage(DateTime.Now + " ---> " + message);                
            }
        }
        #endregion
    }
}
