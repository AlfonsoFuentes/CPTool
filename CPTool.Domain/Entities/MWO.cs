namespace CPTool.Domain.Entities
{
    public class MWO  : AuditableEntity
    {
        public int Number { get; set; }
        public int? ProjectLeaderId { get; set; }
        public User? ProjectLeader { get; set; } 
   
        public DateTime ApprovalDate { get; set; }
        public string? CEBName { get; set; }
        public string? CECName { get; set; }
        public double Budget { get; set; }
        public double Expenses { get; set; }
        public bool Approved { get; set; }
        public int? MWOTypeId { get; set; }
        public MWOType? MWOType { get; set; } = null!;
        public ICollection<MWOItem> MWOItems { get; set; } = null!;

        public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = null!;
        [ForeignKey("MWOId")]
        public ICollection<Taks> Taks { get; set; } = null!;
        public ICollection<UserRequirement> UserRequirements { get; set; } = null!;
        [ForeignKey("MWOId")]
        public ICollection<Signal> Signals { get; set; } = null!;
        public ICollection<ControlLoop> ControlLoops { get; set; } = null!;
        
    }


}
