

namespace CPTool.Entities
{
    public class PurchaseOrder : AuditableEntity
    {
        
        public virtual MWO? MWO { get; set; }
        public virtual ICollection<PurchaseOrderItem>? PurchaseOrderItems { get; set; }
    }





}
