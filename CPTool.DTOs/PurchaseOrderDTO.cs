

namespace CPTool.DTOS
{
    public class PurchaseOrderDTO : AuditableEntityDTO
    {
      
        public MWODTO? MWODTO { get; set; }
        public List<PurchaseOrderItemDTO> PurchaseOrderItemDTOs { get; set; } = new();
    }





}
