



using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;

namespace CPTool.Application.Features.UserRequirementFeatures.Mapping
{
    internal class UserRequirementMapping : Profile
    {
        public UserRequirementMapping()
        {
            CreateMap<UserRequirement,EditUserRequirement>();
            CreateMap<EditUserRequirement, AddUserRequirement>();
            CreateMap<EditUserRequirement, UserRequirement>();
            CreateMap<AddUserRequirement, UserRequirement>();
        }
    }
}
