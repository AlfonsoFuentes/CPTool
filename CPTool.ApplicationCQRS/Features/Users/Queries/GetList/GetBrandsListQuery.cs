using CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Users.Queries.GetList
{
    public class GetUsersListQuery : IRequest<List<CommandUser>>
    {

    }
}
