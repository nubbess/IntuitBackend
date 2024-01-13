using AutoMapper;
using IntuitChallenge.Models;
using IntuitChallenge.Models.DTO;

namespace IntuitChallenge
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Cliente, Cliente>();
            CreateMap<Cliente, ClienteCreateDto>().ReverseMap();
        }
    }
}