

using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;
using CPTool.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace CPTool.NewPages.Dialogs.PurchaseOrder.Dialog
{
    public partial class AddDataToPuchaseOrderDialog
    {

        [Inject]
        public ICurrencyApi _CurrencyService { get; set; }
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditPurchaseOrderItem Model { get; set; } = null!;


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
        void Cancel() => MudDialog.Cancel();
        protected override void OnInitialized()
        {
            Model.PurchaseOrder.USDCOP = _CurrencyService.RateList == null ? 4900 : Math.Round(_CurrencyService.RateList["COP"], 2);
            Model.PurchaseOrder.USDEUR = _CurrencyService.RateList == null ? 1 : Math.Round(_CurrencyService.RateList["EUR"], 2);
        }
       

      
        private string ValidatePOAmount(double arg)
        {
            if (arg <= 0)
                return "Item Value must be greater than zero";
            return null;
        }
        private string ValidatePOValue(double arg)
        {
            if (arg <= 0)
                return "Item Value must be greater than zero";
            foreach (var row in Model.PurchaseOrder.PurchaseOrderItems)
            {
                if (row.PrizeCurrency <= 0) return $"Item {row.MWOItem.Name} Value must be greater than zero";
            }



            return null;
        }
    }
}