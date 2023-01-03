using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Signals.Queries.GetList
{
    public class GetSignalsListQuery : IRequest<List<CommandSignal>>
    {
        public int MWOId { get; set; }
    }
}
