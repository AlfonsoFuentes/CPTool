namespace CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate
{
    public class AddMWO
    {

       
        public string Name { get; set; } = string.Empty;
        public int Number { get; set; }
        public int? ProjectLeaderId { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string? CEBName { get; set; }
        public string? CECName { get; set; }
        public double Budget { get; set; }
        public double Expenses { get; set; }

        public bool Approved { get; set; }
        public int? MWOTypeId { get; set; }
    }

}
