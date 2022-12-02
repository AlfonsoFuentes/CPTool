

using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOFeatures.CreateEdit
{
    public class EditMWO : EditCommand, IRequest<Result<int>>
    {

        public int Number { get; set; }
        public string ProjectLeader { get; set; } = "";
        public DateTime ApprovalDate { get; set; }
        public string CEBName => $"CEB0000{Number}";
        public string CECName => $"CEC0000{Number}";
        public double Budget => MWOItems!.Where(x => x.ChapterId != 1).ToList().Count==0?0: MWOItems!.Where(x=>x.ChapterId!=1)!.Sum(x => x.BudgetPrize);
        public double Expenses => MWOItems!.Where(x => x.ChapterId == 1).ToList().Count == 0 ? 0 : MWOItems!.Where(x => x.ChapterId == 1)!.Sum(x => x.BudgetPrize);
        public double Assigned => PurchaseOrders!.Where(x => !x.PurchaseOrderItems.Any(y => y.MWOItem!.ChapterId == 1)).Sum(z => z.PrizeUSD);
        public double Actual => PurchaseOrders!.Where(x =>x.PurchaseOrderStatus==PurchaseOrderStatus.Closed&& !x.PurchaseOrderItems.Any(y => y.MWOItem!.ChapterId == 1)).Sum(z => z.PrizeUSD);
        public double Commitment => PurchaseOrders!.Where(x => x.PurchaseOrderStatus != PurchaseOrderStatus.Closed && !x.PurchaseOrderItems.Any(y => y.MWOItem!.ChapterId == 1)).Sum(z => z.PrizeUSD);
        public double Pending => Budget - Actual - Commitment;

        public int? MWOTypeId => MWOType?.Id == 0 ? null : MWOType?.Id;
        public EditMWOType? MWOType { get; set; } = new();
        public List<EditMWOItem>? MWOItems { get; set; } = new();
        public List<EditPurchaseOrder> PurchaseOrders { get; set; } = new();
        public List<EditUserRequirement> UserRequirements { get; set; } = new();

        public override T AddDetailtoMaster<T>() 
        {
            EditMWOItem detail = new();
            detail.MWO = this;

            return (detail as T)!;
        }

    }
}
