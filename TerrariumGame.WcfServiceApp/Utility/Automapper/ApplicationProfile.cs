using AutoMapper;
using TerrariumGame.Dto.DTO;
using TerrariumGame.WcfServiceApp.DataContracts;

namespace TerrariumGame.WcfServiceApp
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<ConversationDto, ConversationDataContract>()
            .ReverseMap();
        }
    }
}