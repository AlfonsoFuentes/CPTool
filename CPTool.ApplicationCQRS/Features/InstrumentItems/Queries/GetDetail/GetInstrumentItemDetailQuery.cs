using CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.InstrumentItems.Queries.GetDetail
{
    public class GetInstrumentItemDetailQuery : IRequest<CommandInstrumentItem>
    {
        public int Id { get; set; }
    }
}
