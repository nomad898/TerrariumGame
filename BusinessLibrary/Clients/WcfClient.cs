using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.WcfInterfaces.Services;

namespace BusinessLibrary.Clients
{
    public class WcfClient 
    {
        public void Start()
        {
            ChannelFactory<IWcfConversationService> channelFactory =
                new ChannelFactory<IWcfConversationService>(new BasicHttpBinding(),
                new EndpointAddress(""));
        }
    }
}
