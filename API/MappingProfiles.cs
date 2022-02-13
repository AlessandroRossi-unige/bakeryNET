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
            CreateMap<Sweet, SweetToReturnDto>()
                .ForMember(d => d.Ingredients, o=> o.MapFrom(s => s.Ingredients.Select(x => x.Name)));
        }
    }
}