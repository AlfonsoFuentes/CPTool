global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.UserRequirementTypes.Profiles
{
    internal class UserRequirementTypeMapping : Profile
    {
        public UserRequirementTypeMapping()
        {
            CreateMap<UserRequirementType, CommandUserRequirementType>();
            CreateMap<CommandUserRequirementType, UserRequirementType>();
            CreateMap<AddUserRequirementType, UserRequirementType>();
            CreateMap<CommandUserRequirementType, AddUserRequirementType>();
        }
    }
}
