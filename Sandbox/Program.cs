using DataBaseInterfaces.Entities;
using DataBaseInterfaces.Repositories;
using DataBaseLibrary.Entities;
using DataBaseLibrary.Repositories;
using System;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            IConversationRepository cRepo = new ConversationRepository();
            IConversation c = new Conversation
            {
                Message = DateTime.Now.ToString(),
                Date = DateTime.Now
            };
            cRepo.Create(c);
            cRepo.Save();
            Console.WriteLine("DONE!!!");
            Console.ReadKey(true);
        }
    }
}
