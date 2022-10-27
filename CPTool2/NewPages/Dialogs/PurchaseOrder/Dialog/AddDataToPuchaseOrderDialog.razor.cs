

using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool2.NewPages.Dialogs.PurchaseOrder.Dialog
{
    public partial class AddDataToPuchaseOrderDialog
    {
       
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditPurchaseOrder Model { get; set; } = null!;

       
        [Parameter]
        public MudForm form { get; set; } = null!;

        async Task ValidateForm()
        {
            await form.Validate();
        }

        public async virtual Task Submit()
        {
            await ValidateForm();
            if (form.IsValid)
            {
               

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }
        protected override void OnInitialized()
        {
            Model.MWOItem.MWOItemCurrencyValue.USDCOP = 4900;// Math.Round(_CurrencyService.RateList["COP"], 2);
            Model.MWOItem.MWOItemCurrencyValue.USDEUR = 1;// Math.Round(_CurrencyService.RateList["EUR"], 2);
        }
        void Cancel() => MudDialog.Cancel();

        private string ValidateCurrency(Currency arg)
        {
            if (arg == Currency.None)
                return "Must submit Currency";


            return null;
        }
        private string ValidatePOAmount(double arg)
        {
            if (arg <= 0)
                return "Item Value must be greater than zero";
            return null;
        }
    }
}