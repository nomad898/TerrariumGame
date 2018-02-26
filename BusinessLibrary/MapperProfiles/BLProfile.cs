using AutoMapper;
using TerrariumGame.Dto.DTO;
using TerrariumGame.Model.Entities;

namespace BusinessLibrary.MapperProfiles
{
    public class BLProfile : Profile
    {
        public BLProfile()
        {
            CreateMap<Conversation, ConversationDto>();
            CreateMap<ConversationDto, Conversation>();
        }
    }
}
