



using CPTool.Application.Features.UserFeatures.CreateEdit;

namespace CPTool.Application.Features.UserFeatures.Mapping
{
    internal class RequestedByMapping : Profile
    {
        public RequestedByMapping()
        {
            CreateMap<User,EditUser>();
            CreateMap<EditUser, AddUser>();
            CreateMap<EditUser, User>();
            CreateMap<AddUser, User>();
        }
    }
}
