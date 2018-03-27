using Autofac;
using AutoMapper;
using BusinessInterfaces.Services;
using BusinessLibrary.Services;
using DataBaseInterfaces.Repositories;
using DataBaseLibrary.EFContext;
using DataBaseLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;

namespace TerrariumGame.WcfServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ConversationWcfService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ConversationWcfService.svc or ConversationWcfService.svc.cs at the Solution Explorer and start debugging.
    public class ConversationWcfService : IWcfConversationService
    {
        private IConversationService conversationService;
        private IContainer container;

        public ConversationWcfService()
        {
          
        }        

        public IEnumerable<ConversationDto> Get()
        {            
            return conversationService.GetAllAsync().Result;
        }

        public int TestMethod()
        {
            return 10;
        }
    }
}
