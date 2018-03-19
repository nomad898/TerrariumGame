using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;
using TerrariumGame.WcfInterfaces.Services;

namespace TerrariumGame.WcfApp
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ConversationService : IWcfConversationService
    {
        public Task<IEnumerable<ConversationDto>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public int TestMethod()
        {
            return 0;
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
