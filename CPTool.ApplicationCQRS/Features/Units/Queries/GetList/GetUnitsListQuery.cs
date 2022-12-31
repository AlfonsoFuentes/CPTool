using CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Units.Queries.GetList
{
    public class GetUnitsListQuery : IRequest<List<CommandUnit>>
    {

    }
}
