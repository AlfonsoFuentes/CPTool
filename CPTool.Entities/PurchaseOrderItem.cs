

namespace CPTool.Entities
{
    public class PurchaseOrderItem : AuditableEntity
    {
      
        public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
    }





}
