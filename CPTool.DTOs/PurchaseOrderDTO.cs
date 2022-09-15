

namespace CPTool.DTOS
{
    public class PurchaseOrderDTO : AuditableEntityDTO
    {
        public int? MWOId => MWODTO?.Id;
        public MWODTO? MWODTO { get; set; } = null!;
        public List<PurchaseOrderItemDTO>? PurchaseOrderItemDTOs { get; set; } = new();
    }
    




}
