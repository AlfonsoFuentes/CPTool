using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ProcessFluids.Commands.Delete
{
    public class DeleteProcessFluidCommand : IRequest<DeleteProcessFluidCommandResponse>
    {
        public int Id { get; set; }
    }
}
