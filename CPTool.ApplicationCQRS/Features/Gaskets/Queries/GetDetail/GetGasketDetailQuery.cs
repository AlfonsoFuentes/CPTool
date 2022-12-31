using CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Gaskets.Queries.GetDetail
{
    public class GetGasketDetailQuery : IRequest<CommandGasket>
    {
        public int Id { get; set; }
    }
}
