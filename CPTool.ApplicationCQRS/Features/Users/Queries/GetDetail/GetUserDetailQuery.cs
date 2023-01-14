using CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Users.Queries.GetDetail
{
    public class GetUserDetailQuery : IRequest<CommandUser>
    {
        public int Id { get; set; }
    }
}
