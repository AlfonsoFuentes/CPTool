global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.Users.Profiles
{
    internal class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, CommandUser>();
            CreateMap<CommandUser, User>();
            CreateMap<AddUser, User>();
            CreateMap<CommandUser, AddUser>();
        }
    }
}
