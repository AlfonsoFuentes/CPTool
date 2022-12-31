using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ProcessFluids.Queries.GetDetail
{
    public class GetProcessFluidDetailQuery : IRequest<CommandProcessFluid>
    {
        public int Id { get; set; }
    }
}
