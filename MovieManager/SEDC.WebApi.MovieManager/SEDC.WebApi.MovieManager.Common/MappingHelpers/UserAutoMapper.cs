using AutoMapper;
using SEDC.WebApi.MovieManager.DataModels.Models;
using SEDC.WebApi.MovieManager.ServiceModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.MovieManager.Common.MappingHelpers
{
    public class UserAutoMapper : Profile
    {
        public UserAutoMapper()
        {
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<User, CreateUserDto>().ReverseMap();

            CreateMap<User, UpdateUserDto>().ReverseMap();
        }
    }
}
