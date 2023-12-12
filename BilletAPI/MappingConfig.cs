using AutoMapper;
using BilletAPI.Models;
using BilletAPI.Models.Dto;
using System.Runtime;

namespace BilletAPI
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        { 
            CreateMap<Billet, BilletDTO>();
            CreateMap<BilletDTO, Billet>();

            CreateMap<BilletUser, BilletUserDTO>();
            CreateMap<BilletUserDTO, BilletUser>();

        }

    }
}
