namespace CPTool.DTOS
{
    public class PurchaseOrderMWOItemDTO : AuditableEntityDTO, IMapFrom<PurchaseOrderMWOItem>
    {
      
        public PurchaseOrderDTO? PurchaseOrderDTO { get; set; } = new();

        
        public MWOItemDTO? MWOItemDTO { get; set; } = new();
        public bool PurchaseOrderCreated { get; set; } = false;

    }

}
