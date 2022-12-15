





using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.Domain.Enums;
using CPTool.UnitsSystem;

namespace CPTool.Application.Features.TaksFeatures.CreateEdit
{
    public class AddTaks : AddCommand
    {
        public int? MWOId { get; set; }

        public int? MWOItemId { get; set; }


        public int? PurchaseOrderId { get; set; }

        public TaksType TaksType { get; set; }
        public int? DownpaymentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public TaksStatus TaksStatus { get; set; }




    }

}
