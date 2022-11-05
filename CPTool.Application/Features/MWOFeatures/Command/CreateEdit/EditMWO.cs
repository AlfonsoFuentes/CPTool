

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
        public double Assigned => MWOItems!.Where(x => x.ChapterId != 1).ToList().Count == 0 ? 0 : MWOItems!.Where(x => x.ChapterId != 1)!.Sum(x => x.Assigned);

        public int? MWOTypeId => MWOType == null ? null : MWOType?.Id;
        public EditMWOType? MWOType { get; set; }
        public List<EditMWOItem>? MWOItems { get; set; } = new();
        public List<EditPurchaseOrder>? PurchaseOrders { get; set; }
        public List<EditUserRequirement>? UserRequirements { get; set; }

        public override T AddDetailtoMaster<T>() 
        {
            EditMWOItem detail = new();
            detail.MWO = this;

            return (detail as T)!;
        }

    }
}
