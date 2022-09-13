

namespace CPTool.Entities
{
    public class MWO : AuditableEntity
    {
        public int Number { get; set; }
        public string? ProjectLeader { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string? CEBName { get; set; }
        public string? CECName { get; set; }
        public decimal Budget { get; set; }
        public decimal Expenses { get; set; }

        public int MWOTypeId { get; set; }
        public MWOType? MWOType { get; set; }
        public ICollection<MWOItem>? MWOItems { get; set; } 
        public ICollection<PurchaseOrder>? PurchaseOrders { get; set; }
    }





}
