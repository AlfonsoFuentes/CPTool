



using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;

namespace CPTool.Application.Features.UserRequirementTypeFeatures.Mapping
{
    internal class UserRequirementTypeMapping : Profile
    {
        public UserRequirementTypeMapping()
        {
            CreateMap<UserRequirementType,EditUserRequirementType>();
            CreateMap<EditUserRequirementType, AddUserRequirementType>();
            CreateMap<EditUserRequirementType, UserRequirementType>();
            CreateMap<AddUserRequirementType, UserRequirementType>();
        }
    }
}
