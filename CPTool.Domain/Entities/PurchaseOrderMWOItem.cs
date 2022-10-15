namespace CPTool.Domain.Entities
{
    public class PurchaseOrderMWOItem  : BaseDomainModel
    {
        public int? PurchaseOrderId { get; set; }

        public PurchaseOrder? PurchaseOrder { get; set; }

      

    }
}
