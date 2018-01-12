using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            //XmlDocument xmlDoc = new XmlDocument();
            //XmlElement conversations = xmlDoc.CreateElement("Conversations");
            //XmlElement conversation = xmlDoc.CreateElement("Conversation");
            //XmlElement message = xmlDoc.CreateElement("Message");
            //message.SetAttribute("From", "Person");
            //message.SetAttribute("To", "Man");
            //message.InnerText = "Simple text";
            //XmlElement date = xmlDoc.CreateElement("Date");
            //date.InnerText = DateTime.Now.ToString();
            //conversation.AppendChild(message);
            //conversation.AppendChild(date);
            //conversations.AppendChild(conversation);
            //conversation = xmlDoc.CreateElement("Conversation");
            //conversations.AppendChild(conversation);
            //xmlDoc.AppendChild(conversations);

            //xmlDoc.Save("conversation.xml");

            XDocument xdoc = new XDocument(
                new XDeclaration("1.0", "utf - 16", "true"));
            XElement root = new XElement("Root");
            xdoc.Add(root);
            xdoc.Save("XConversation.xml");
            Console.WriteLine("DONE!!!");
            Console.ReadKey(true);
        }
    }
}
