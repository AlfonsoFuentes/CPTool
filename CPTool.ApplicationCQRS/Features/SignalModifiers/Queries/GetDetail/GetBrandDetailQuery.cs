using CPTool.ApplicationCQRS.Features.SignalModifiers.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.SignalModifiers.Queries.GetDetail
{
    public class GetSignalModifierDetailQuery : IRequest<CommandSignalModifier>
    {
        public int Id { get; set; }
    }
}
