namespace CPTool.DTOS
{
    public class PurchaseOrderMWOItemDTO : AuditableEntityDTO
    {
        public int? PurchaseOrderId => PurchaseOrderDTO?.Id;
        public int? MWOItemId => MWOItemDTO?.Id;
        public PurchaseOrderDTO? PurchaseOrderDTO { get; set; } = new();

        
        public MWOItemDTO? MWOItemDTO { get; set; } = new();
        public bool PurchaseOrderCreated { get; set; } = false;

    }

}
