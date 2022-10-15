namespace CPTool.Application.Features.MWOFeatures.CreateEdit
{
    public class AddMWO : AddCommand, IRequest<Result<int>>
    {

        public int Number { get; set; }
        public string? ProjectLeader { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string? CEBName => $"CEB0000{Number}";
        public string? CECName => $"CEC0000{Number}";
        public decimal Budget { get; set; }
        public decimal Expenses { get; set; }


        public int? MWOTypeId => MWOTypeCommand == null ? null : MWOTypeCommand.Id;

        public EditMWOType? MWOTypeCommand { get; set; }

    }
}
