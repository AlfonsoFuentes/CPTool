global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.UserRequirements.Profiles
{
    internal class UserRequirementMapping : Profile
    {
        public UserRequirementMapping()
        {
            CreateMap<UserRequirement, CommandUserRequirement>();
            CreateMap<CommandUserRequirement, UserRequirement>();
            CreateMap<AddUserRequirement, UserRequirement>();
            CreateMap<CommandUserRequirement, AddUserRequirement>();
        }
    }
}
