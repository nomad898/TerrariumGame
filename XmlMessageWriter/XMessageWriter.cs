﻿using InterfaceLibrary.Interfaces.Writer;
using System;
using System.Xml.Linq;

namespace MessageWriter
{
    public class XMessageWriter : IMessageWriter
    {
        private XDocument xDoc;
        private XElement root;
        private const string XML_FILE_NAME = "XConversation.xml";

        public XMessageWriter()
        {
            xDoc = new XDocument(
                new XDeclaration("1.0", "utf - 16", "true"));
            root = new XElement("Conversations");
            xDoc.Add(root);
            xDoc.Save(XML_FILE_NAME);
        }

        #region IMessageWriter
        public void PrintMessage(string message)
        {
            if (message != string.Empty)
            {
                XElement convElem = new XElement("Conversation",
                    new XElement("Message", message),
                    new XElement("Date", DateTime.Now));
                root.Add(convElem);              
            }
            xDoc.Save(XML_FILE_NAME);
        }
        #endregion
    }
}
