using CPTool.ApplicationCQRS.Features.TaxesItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.TaxesItems.Queries.GetList
{
    public class GetTaxesItemsListQuery : IRequest<List<CommandTaxesItem>>
    {

    }
}
