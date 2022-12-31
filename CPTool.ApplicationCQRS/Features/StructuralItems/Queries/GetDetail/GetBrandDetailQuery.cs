using CPTool.ApplicationCQRS.Features.StructuralItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.StructuralItems.Queries.GetDetail
{
    public class GetStructuralItemDetailQuery : IRequest<CommandStructuralItem>
    {
        public int Id { get; set; }
    }
}
