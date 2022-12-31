using CPTool.ApplicationCQRS.Features.SignalModifiers.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.SignalModifiers.Queries.GetList
{
    public class GetSignalModifiersListQuery : IRequest<List<CommandSignalModifier>>
    {

    }
}
