using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;

namespace TerrariumGame.WcfInterfaces.Services
{
    public interface IWcfConversationService
    {
        [OperationContract]
        Task<IEnumerable<ConversationDto>> GetAsync();

        [OperationContract]
        int TestMethod();
    }
}
