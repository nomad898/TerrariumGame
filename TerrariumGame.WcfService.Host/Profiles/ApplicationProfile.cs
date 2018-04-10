using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;
using TerrariumGame.WcfDataContracts;

namespace TerrariumGame.WcfService.Host.Profiles
{
    class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<ConversationDto, ConversationDataContract>()
            .ReverseMap();
        }
    }
}
