using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;

namespace CPTool.NewPages.Dialogs.ProcessFluid.List
{
    public partial class DownpaymentList
    {
        [Parameter]
        public List<EditDownPayment> DownPayments { get; set; } = new();

        [Parameter]
       
        public EventCallback<List<EditDownPayment>> DownPaymentsChanged { get; set; }


        EditDownPayment SelectedDownPayment { get; set; } = new();

        

    }
}
