using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using TerrariumGame.WcfServiceApp.DataContracts;

namespace TerrariumGame.WcfServiceApp
{
    [ServiceContract]
    public interface IConversationWcfService
    {
        [OperationContract]
        IEnumerable<ConversationDataContract> Get();

        [OperationContract]
        Task Create(ConversationDataContract conversation);
        
        [OperationContract]
        void CreateConversation(string message);
    }    
}
