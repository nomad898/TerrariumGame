using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;
using TerrariumGame.WcfDataContracts;

namespace TerrariumGame.WcfInterfaces.Services
{
    [ServiceContract]
    public interface IWcfConversationService
    {
        [OperationContract]
        IEnumerable<ConversationDataContract> Get();

        [OperationContract]
        Task Create(ConversationDataContract conversation);

        [OperationContract]
        void CreateConversation(string message);
    }   
}
