

namespace CPTool.DTOS
{
    public class PurchaseOrderDTO : AuditableEntityDTO
    {
        public int MWOId { get; set; }
        public MWODTO? MWODTO { get; set; }
        public List<PurchaseOrderItemDTO> PurchaseOrderItemDTOs { get; set; } = new();
    }
    public class CreatePurchaseOrderDTO : PurchaseOrderDTO
    {

    }




}
