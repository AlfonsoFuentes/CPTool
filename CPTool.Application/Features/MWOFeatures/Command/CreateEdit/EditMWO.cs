

using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;
using CPTool.Domain.Enums;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;

namespace CPTool.Application.Features.MWOFeatures.CreateEdit
{
    public class EditMWO : EditCommand, IRequest<Result<int>>
    {

        public int Number { get; set; }
        [Report(Order = 3)]
        public string ProjectLeader { get; set; } = "";
        [Report(Order = 4)]
        public DateTime ApprovalDate { get; set; }
        [Report(Order = 5)]
        public string CEBName => $"CEB0000{Number}";
        [Report(Order = 6)]
        public string CECName => $"CEC0000{Number}";
        [Report(Order = 7)]
        public double Budget => MWOItems!.Where(x => x.ChapterId != 1).ToList().Count==0?0: MWOItems!.Where(x=>x.ChapterId!=1)!.Sum(x => x.BudgetPrize);
        [Report(Order = 8)]
        public double Expenses => MWOItems!.Where(x => x.ChapterId == 1).ToList().Count == 0 ? 0 : MWOItems!.Where(x => x.ChapterId == 1)!.Sum(x => x.BudgetPrize);
        [Report(Order = 9)]
        public double Assigned => PurchaseOrders!.Where(x => !x.PurchaseOrderItems.Any(y => y.MWOItem!.ChapterId == 1)).Sum(z => z.PrizeUSD);
        [Report(Order = 10)]
        public double Actual => PurchaseOrders.Count==0?0: PurchaseOrders!.Sum(x=>x.ActualValue);
        [Report(Order = 11)]
        public double Commitment => PurchaseOrders.Count == 0 ? 0 : PurchaseOrders!.Sum(x => x.CommitmentValue);
        [Report(Order = 12)]
        public double Pending => Budget - Actual - Commitment;

        public int? MWOTypeId => MWOType?.Id == 0 ? null : MWOType?.Id;
        public EditMWOType? MWOType { get; set; } = new();
        [Report(Order = 13)]
        public string MWOTypeName => MWOType == null ? "" : MWOType!.Name;
        public List<EditMWOItem>? MWOItems { get; set; } = new();
        public List<EditPurchaseOrder> PurchaseOrders { get; set; } = new();
        public List<EditUserRequirement> UserRequirements { get; set; } = new();


       
    }
}
