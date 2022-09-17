namespace CPTool.Pages.Dialogs
{
    public partial class DownpaymentDialog
    {
       
        [Parameter]
        public DownPaymentDTO Model { get; set; }

       
        async Task ProperSave()
        {
            if (Model.Id == 0)
            {
                await TablesService.ManDownPayment.AddUpdate(Model, _cts.Token);
                await TablesService.ManDownPayment.UpdateList();
            }
        }
       
    }
}
