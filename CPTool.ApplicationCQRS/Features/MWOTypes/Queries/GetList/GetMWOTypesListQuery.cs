using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MWOTypes.Queries.GetList
{
    public class GetMWOTypesListQuery : IRequest<List<CommandMWOType>>
    {

    }
}
