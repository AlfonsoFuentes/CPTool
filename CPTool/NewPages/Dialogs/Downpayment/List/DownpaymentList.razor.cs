using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;

using CPTool.Application.Features.TaksFeatures.Query.GetList;

namespace CPTool.NewPages.Dialogs.Downpayment.List
{
    public partial class DownpaymentList
    {
        [Inject]
        public IMediator mediator { get; set; }

        [Parameter]
        public List<EditDownPayment> DownPayments { get; set; } = new();

        [Parameter]

        public EventCallback<List<EditDownPayment>> DownPaymentsChanged { get; set; }


        EditDownPayment SelectedDownPayment { get; set; } = new();

        async Task<DialogResult> ShowDownpayment(EditDownPayment pomwo)
        {

            var result = await ToolDialogService.ShowDownpaymentDialog(SelectedDownPayment);
            if (!result.Cancelled)
            {

                GetTaksListQuery getTaksListQuery = new();
                GlobalTables.Takss = await mediator.Send(getTaksListQuery);
            }
            return result;
        }

    }
}
