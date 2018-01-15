using DataBaseInterfaces.Entities;
using DataBaseLibrary.Entities;
using DataBaseLibrary.Repositories;
using System;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {

            UnitOfWork uow = new UnitOfWork();
            IConversation c = new Conversation
            {
                Message = DateTime.Now.ToString(),
                Date = DateTime.Now
            };

            uow.ConversationRepository.Create(c);
            uow.Save();
            Console.WriteLine("DONE!!!");
            Console.ReadKey(true);
        }
    }
}
