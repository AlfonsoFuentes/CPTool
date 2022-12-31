using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Signals.Queries.GetDetail
{
    public class GetSignalDetailQuery : IRequest<CommandSignal>
    {
        public int Id { get; set; }
    }
}
