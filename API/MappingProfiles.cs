using System.Linq;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Sweet, SweetToReturnDto>();
        }
    }
}