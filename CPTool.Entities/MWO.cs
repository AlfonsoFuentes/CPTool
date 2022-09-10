

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

        public virtual MWOType MWOType { get; set; } = null!;
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = null!;
    }





}
