using DTOs;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Helpers;

namespace Profiles
{
    public class PersonasProfile : Profile
    {

        public PersonasProfile()

        {

            CreateMap<Personas, PersonasDTO>().ReverseMap();

            CreateMap<Personas, PersonasDTO>().ForMember(dest => dest.Edad, opt => opt.MapFrom(src => src.FechaNacimiento.GetCurrentAge()));

            CreateMap<PersonasCrearDTO, Personas>().ReverseMap();

        }
    }
}
