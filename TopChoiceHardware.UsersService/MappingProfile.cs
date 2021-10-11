using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopChoiceHardware.UsersService.Domain.DTOs;
using TopChoiceHardware.UsersService.Domain.Entities;

namespace TopChoiceHardware.UsersService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuarioDtoForCreation, Usuario>();
            CreateMap<Usuario, UsuarioDtoForCreation>();
            CreateMap<Usuario, UsuarioDtoForDisplay>();
        }
    }
}
