using CPTool.Domain.Enums;

namespace CPTool.Domain.Entities
{
    public class Taks : AuditableEntity
    {
        public int? MWOId { get; set; }
        public MWO? MWO { get; set; }
        public MWOItem? MWOItem { get; set; }
        public int? MWOItemId { get; set; }

        public PurchaseOrder? PurchaseOrder { get; set; }
        public int? PurchaseOrderId { get; set; }

        public DownPayment? DownPayment { get; set; }
        public int? DownpaymentId { get; set; }
       
        public DateTime ExpectedDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public TaksStatus TaksStatus { get; set; }
        public TaksType TaksType { get; set; }
    }




}
