using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;
using TerrariumGame.WcfApp;
using TerrariumGame.WcfInterfaces.Services;

namespace BusinessLibrary.Clients
{
    public class WcfClient 
    {
        private readonly WcfServiceConversation client;

        public WcfClient()
        {
            client = new WcfServiceConversation();
        }

        public IEnumerable<ConversationDto> Get()
        {
            var res = client.Get().Result;
            return res;
        }
    }
}
