using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MWOTypes.Queries.GetDetail
{
    public class GetMWOTypeDetailQuery : IRequest<CommandMWOType>
    {
        public int Id { get; set; }
    }
}
