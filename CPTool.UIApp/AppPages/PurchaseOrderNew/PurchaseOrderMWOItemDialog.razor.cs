using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.Domain.Enums;
using CPTool.InfrastructureCQRS.Services;
using CPTool.UIApp.AppPages.PurchaseOrders;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace CPTool.UIApp.AppPages.PurchaseOrderNew
{
    public partial class PurchaseOrderMWOItemDialog
    {

        
        public bool SaveDialog { get; set; } = true;
        [Inject]
        IMWOItemService MWOItemService { get; set; }
        [Inject]
        public IPurchaseOrderService Service { get; set; }
       
        public CommandPurchaseOrder Model { get; set; } = new();


        public PurchaseOrderDialogData DialogData = new();
        string ButtonSaveName => Service.GetButtonName(Model);
        bool DisableButtonSave => Service.DisableButtonSave(Model);
        bool loaded = false;
        [Parameter]
        public int MWOItemId { get; set; }
        [Parameter]
        public int PurchaseOrderId { get; set; }
        CommandMWOItem MWOItem = new();
        protected override async Task OnInitializedAsync()
        {
           
            if (MWOItemId!=0)
            {
                MWOItem=await MWOItemService.GetById(MWOItemId);
            }
            if (PurchaseOrderId != 0)
            {
                Model = await Service.GetById(PurchaseOrderId);
                purchaseOrderItem = Model.PurchaseOrderItems.FirstOrDefault();


            }
            else
            {
                Model.MWO = MWOItem.MWO;
            }
            
            DialogData = await Service.GetPurchaseOrderDataNewDialog(Model);


            loaded = true;
        }
        async Task Save()
        {
            var result = await Service.AddUpdate(Model);
            if (result.Success)
            {
                Model = result.ResponseObject;
                GoBack();
            }
            else
            {
                errors = result.ValidationErrors;

                errorVisible = true;
            }
           
           
        }
        async Task GetSuppliersByBrands(int brandid)
        {
            DialogData.Suppliers = await Service.GetSupplierByBrand(brandid);

        }
        CommandPurchaseOrderItem purchaseOrderItem = new();
        void ChangeSupplier()
        {
            purchaseOrderItem = Service.GetDataForAddItem(MWOItem, Model);
            Service.AddMWOItemBudgetToPurchaseOrder(Model, purchaseOrderItem, DialogData);


           
           

        }


        public bool DisableAddRemoveMWOItem => !(Model.pSupplier.Id != 0 && MWOItem.Id != 0
                                                    && Model.Currency != Currency.None);

        protected async Task SavePurchaseOrder()
        {
            if (SaveDialog)
            {


                var result = await Service.AddUpdate(Model);

                DialogService.Close(result.Success);
            }
            else
            {
                DialogService.Close(true);
            }

        }
      
      
       

       
        public void ChangeCurrency(CommandPurchaseOrderItem order, double d)
        {
            order.PrizeCurrency = d;
           

        }
        void GoBack()
        {
            NavigationManager.NavigateTo($"/mwo-items/{MWOItem.MWO.Id}");
        }
        async Task ReportDialog()
        {
            await Task.CompletedTask;
        }
        List<string> errors = new();
        protected bool errorVisible;
    }
}
