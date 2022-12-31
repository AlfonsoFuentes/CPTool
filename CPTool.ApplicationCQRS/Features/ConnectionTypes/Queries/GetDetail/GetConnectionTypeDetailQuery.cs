using CPTool.ApplicationCQRS.Features.ConnectionTypes.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ConnectionTypes.Queries.GetDetail
{
    public class GetConnectionTypeDetailQuery : IRequest<CommandConnectionType>
    {
        public int Id { get; set; }
    }
}
