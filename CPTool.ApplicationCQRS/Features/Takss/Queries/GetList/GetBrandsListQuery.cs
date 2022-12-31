using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Takss.Queries.GetList
{
    public class GetTakssListQuery : IRequest<List<CommandTaks>>
    {

    }
}
