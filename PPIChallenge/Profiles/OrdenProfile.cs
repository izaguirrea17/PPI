using AutoMapper;
using PPIChallenge.Dtos;
using PPIChallenge.DTOs;
using PPIChallenge.Models;

namespace PPIChallenge.Profiles
{
    public class OrdenProfile : Profile
    {
        public OrdenProfile() 
        {
            CreateMap<Orden, OrdenDto>();
            CreateMap<OrdenCrearDto, Orden>();
            CreateMap<OrdenActualizarDto, Orden>();
        }
    }
}
