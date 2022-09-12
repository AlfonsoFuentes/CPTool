

namespace CPTool.Entities
{
    public class PurchaseOrder : AuditableEntity
    {
        public int MWOId { get; set; }
        public  MWO? MWO { get; set; }

        public int? MWOItemId { get; set; }
        public MWOItem? MWOItem { get; set; }
        public  ICollection<PurchaseOrderItem>? PurchaseOrderItems { get; set; }
    }





}
