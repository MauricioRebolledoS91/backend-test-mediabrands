using AutoMapper;
using mbww.test.Application.User.Commands.CreateUser;
using mbww.test.Application.User.Commands.UpdateUser;
using mbww.test.Application.User.Queries.GetUserList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbww.test.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.User, CreateUserDto>();
            CreateMap<Domain.Entities.User, UserListVm>();
            CreateMap<Domain.Entities.User, UpdateUserCommand>().ReverseMap();
        }       
    }
}
