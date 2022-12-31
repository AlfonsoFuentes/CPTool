using CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.SignalTypes.Queries.GetList
{
    public class GetSignalTypesListQuery : IRequest<List<CommandSignalType>>
    {

    }
}
