namespace CPTool.Application.Features.MWOFeatures.CreateEdit
{
    public class AddMWO : AddCommand
    {

        public int Number { get; set; }
        public string? ProjectLeader { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string? CEBName => $"CEB0000{Number}";
        public string? CECName => $"CEC0000{Number}";
        public double Budget { get; set; }
        public double Expenses { get; set; }


        public int? MWOTypeId { get; set; }



    }
}
