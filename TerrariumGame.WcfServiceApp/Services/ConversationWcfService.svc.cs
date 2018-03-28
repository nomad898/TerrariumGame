﻿using AutoMapper;
using BusinessInterfaces.Services;
using System.Collections.Generic;
using TerrariumGame.WcfServiceApp.DataMembers;

namespace TerrariumGame.WcfServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ConversationWcfService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ConversationWcfService.svc or ConversationWcfService.svc.cs at the Solution Explorer and start debugging.
    public class ConversationWcfService : IConversationWcfService
    {
        private IConversationService conversationService;
        private readonly IMapper mapper;

        public ConversationWcfService(IConversationService conversationService,
            IMapper mapper)
        {
            this.conversationService = conversationService;
            this.mapper = mapper;
        }

        public IEnumerable<ConversationDataContract> Get()
        {
            return new List<ConversationDataContract>()
            {
                new ConversationDataContract()
                {
                    Id = 1
                },
                new ConversationDataContract()
                {
                    Id = 2
                },
                new ConversationDataContract()
                {
                    Id = 3
                },
                new ConversationDataContract()
                {
                    Id = 4
                },
            };
        }

        public int TestMethod()
        {
            return 10;
        }
    }
}
