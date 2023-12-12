using AutoMapper;
using Billet_Web.Models.Dto;
using System.Runtime;

namespace Billet_Web
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        { 
           CreateMap<BilletDTO, BilletDTO>().ReverseMap();
           CreateMap<BilletUserDTO, BilletUserDTO>().ReverseMap();

        }

    }
}
