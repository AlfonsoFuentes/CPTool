using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PurchaseOrders.Queries.GetList
{
    public class GetPurchaseOrdersListQuery : IRequest<List<CommandPurchaseOrder>>
    {
        public int MWOId { get; set; }

    }
}
