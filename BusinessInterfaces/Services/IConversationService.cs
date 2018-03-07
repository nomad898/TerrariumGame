using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;
using TerrariumGame.Model.Entities;

namespace BusinessInterfaces.Services
{
    public interface IConversationService : IService<ConversationDto, int>
    {
        void WriteMessage(string message);
    }
}
