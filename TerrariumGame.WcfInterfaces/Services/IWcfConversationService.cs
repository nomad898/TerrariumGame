using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        Task<IEnumerable<ConversationDto>> GetAsync();

        [OperationContract]
        Task CreateAsync(ConversationDto conversationDto);
    }

    [DataContract]
    public class Conversation
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
