using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;
using TerrariumGame.WcfInterfaces.Services;

namespace TerrariumGame.WcfServices.Services
{
    public class WcfConversationService : IWcfConversationService
    {
        public IEnumerable<ConversationDto> Get()
        {
            throw new NotImplementedException();
        }

        public string GetData(int value)
        {
            return value.ToString();
        }

        public string Sum(int value, int b)
        {
            throw new NotImplementedException();
        }
    }
}
