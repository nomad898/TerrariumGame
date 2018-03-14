using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;

namespace TerrariumGame.WcfInterfaces.Services
{
    [ServiceContract]
    public interface IWcfConversationService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        string Sum(int value, int b);

        [OperationContract]
        IEnumerable<ConversationDto> Get();
    }
}
