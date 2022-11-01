

using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOFeatures.CreateEdit
{
    public class EditMWO : EditCommand, IRequest<Result<int>>
    {

        public int Number { get; set; }
        public string ProjectLeader { get; set; } = "";
        public DateTime ApprovalDate { get; set; }
        public string CEBName => $"CEB0000{Number}";
        public string CECName => $"CEC0000{Number}";
        public decimal Budget { get; set; }
        public decimal Expenses { get; set; }
        public int? MWOTypeId => MWOType == null ? null : MWOType?.Id;
        public EditMWOType? MWOType { get; set; }
        public List<EditMWOItem>? MWOItems { get; set; } = new();
        public List<EditPurchaseOrder>? PurchaseOrders { get; set; }

        public override T AddDetailtoMaster<T>() 
        {
            EditMWOItem detail = new();
            detail.MWO = this;

            return (detail as T)!;
        }

    }
}
