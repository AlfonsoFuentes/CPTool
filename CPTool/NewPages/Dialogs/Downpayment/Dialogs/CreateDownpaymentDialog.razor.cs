using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Domain.Entities;
using static MudBlazor.Icons;

namespace CPTool.NewPages.Dialogs.Downpayment.Dialogs
{
    public partial class CreateDownpaymentDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditDownPayment Model { get; set; } = null!;
        

        [Parameter]
        public MudForm form { get; set; } = null!;

        string ButtonName => Model.DownpaymentStatus == DownpaymentStatus.Draft ? "Create Downpayment" :
            Model.DownpaymentStatus == DownpaymentStatus.Created ? "Approve Downpayment" :
            Model.DownpaymentStatus == DownpaymentStatus.Approved ? "Pay Downpayment" : "Close Downpayment";



        public async virtual Task Submit()
        {
            await form.Validate();
            if (form.IsValid)
            {
                if (Model.DownpaymentStatus == DownpaymentStatus.Draft)
                {
                   
                    Model.DownpaymentStatus = DownpaymentStatus.Created;
                }
                else if (Model.DownpaymentStatus == DownpaymentStatus.Created)
                {
                    Model.ApprovedDate = DateTime.Now;
                    Model.DownpaymentStatus = DownpaymentStatus.Approved;
                }

                else if (Model.DownpaymentStatus == DownpaymentStatus.Approved)
                {
                    Model.RealDate = DateTime.Now;
                    Model.DownpaymentStatus = DownpaymentStatus.Paid;
                }
                   
                var result = await Mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();
        public static string ValidateDownpaymentName(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (GlobalTables.DownPayments.Any(x => x.DownpaymentName == arg))
                return $"Downpayment Name: {arg} is in the list";

            return null;
        }
        public static string ValidateCBSRequestNo(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (GlobalTables.DownPayments.Any(x => x.CBSRequesNo == arg))
                return $"CBS Reques No: {arg} is in the list";

            return null;
        }
    }
}
