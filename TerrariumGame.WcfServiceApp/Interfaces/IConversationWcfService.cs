using BusinessInterfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;
using TerrariumGame.WcfServiceApp.DataMembers;

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
