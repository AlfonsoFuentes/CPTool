using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit
{
   
    internal class PurchaseOrderItemHandler : AddEditBaseHandler<AddPurchaseOrderItem, EditPurchaseOrderItem, PurchaseOrderItem>, 
        IRequestHandler<EditPurchaseOrderItem, Result<int>>
    {


        public PurchaseOrderItemHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditPurchaseOrderItem> logger)
            : base(unitofwork, mapper, logger) { }
    }
}
