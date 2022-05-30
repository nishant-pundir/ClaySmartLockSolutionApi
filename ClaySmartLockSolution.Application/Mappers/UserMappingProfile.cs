using AutoMapper;
using ClaySmartLockSolution.Application.Commands;
using ClaySmartLockSolution.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLockSolution.Application.Mappers
{
   
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Core.Entities.User, UserResponse>().ReverseMap();
            CreateMap<Core.Entities.User, CreateUserCommand>().ReverseMap();
            CreateMap<Core.Entities.UserDoorAccess, CreateDoorAccessCommand>().ReverseMap();
            CreateMap<Core.Entities.UserDoorAccess, UserDoorAccessResponse>().ReverseMap();
        }
    }
}
