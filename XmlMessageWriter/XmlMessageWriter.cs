using InterfaceLibrary.Interfaces.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLibrary.UtilityModels;
using System.IO;
using System.Xml;

namespace MessageWriter
{
    public class XmlMessageWriter : IMessageWriter
    {
        private const string XML_FILE_NAME = "Conversation.xml";
        private XmlDocument xmlDoc;
        private XmlElement root;

        public XmlMessageWriter()
        {
            xmlDoc = new XmlDocument();
            root = xmlDoc.CreateElement("Conversations");
            xmlDoc.AppendChild(root);
            xmlDoc.Save(XML_FILE_NAME);
        }

        #region IMessageWriter
        public void PrintMessage(string message)
        {
            XmlElement convElem = xmlDoc.CreateElement("Conversation");
            XmlElement msgElem = xmlDoc.CreateElement("Message");
            msgElem.InnerText = message;
            XmlElement dateElem = xmlDoc.CreateElement("Date");
            dateElem.InnerText = DateTime.Now.ToString();
            convElem.AppendChild(msgElem);
            convElem.AppendChild(dateElem);
            root.AppendChild(convElem);
        }

        public void PrintMessage(string message, MessageType msgType)
        {
            if (msgType == MessageType.ConversationMsg
                && message != string.Empty)
            {
                PrintMessage(message);
            }
            xmlDoc.Save(XML_FILE_NAME);
        }
        #endregion
    }
}
