

namespace CPTool.DTOS
{
    public class PurchaseOrderItemDTO : AuditableEntityDTO
    {

        public int PurchaseOrderId { get; set; }
        public PurchaseOrderDTO? PurchaseOrderDTO { get; set; }
    }
    public class CreatePurchaseOrderItemDTO  :  PurchaseOrderItemDTO
    {

    }




}
