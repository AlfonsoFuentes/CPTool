using MediatR;

namespace CPTool.ApplicationCQRSFeatures.InstrumentItems.Commands.Delete
{
    public class DeleteInstrumentItemCommand : IRequest<DeleteInstrumentItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
