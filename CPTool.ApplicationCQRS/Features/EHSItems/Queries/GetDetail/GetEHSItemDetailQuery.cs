using CPTool.ApplicationCQRS.Features.EHSItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EHSItems.Queries.GetDetail
{
    public class GetEHSItemDetailQuery : IRequest<CommandEHSItem>
    {
        public int Id { get; set; }
    }
}
