using CPTool.Application.Contracts.Persistence;
using static System.Net.Mime.MediaTypeNames;

namespace CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit
{
    internal class PurchaseOrderHandler : AddEditBaseHandler<AddPurchaseOrder,EditPurchaseOrder, PurchaseOrder>, IRequestHandler<EditPurchaseOrder, Result<int>>
    {

        public PurchaseOrderHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditPurchaseOrder> logger)
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}
