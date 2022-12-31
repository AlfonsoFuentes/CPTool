using CPTool.ApplicationCQRS.Features.StructuralItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.StructuralItems.Queries.GetList
{
    public class GetStructuralItemsListQuery : IRequest<List<CommandStructuralItem>>
    {

    }
}
