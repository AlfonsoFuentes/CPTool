using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.Domain.Enums;
using CPTool.Services;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.PurchaseOrders
{
    public partial class PurchaseOrderDialog
    {
        [Parameter]
        public bool SaveDialog { get; set; } = true;

        [Inject]
        public IPurchaseOrderService Service { get; set; }
        [Parameter]
        public CommandPurchaseOrder Model { get; set; } = new();
        

        public PurchaseOrderDialogData DialogData = new();
        bool DisableButtonSave => Service.DisableButtonSave(Model);
        protected override async Task OnInitializedAsync()
        {
            if(Model.Id!=0)
            Model = await Service.GetById(Model.Id);
            DialogData = await Service.GetPurchaseOrderDataDialog(Model);


        }
        async Task<BaseResponse> Save()
        {
            var result= await Service.AddUpdate(Model);
           
           
            return result;
        }
        async Task GetSuppliersByBrands(int brandid)
        {
            DialogData.Suppliers = await Service.GetSupplierByBrand(brandid);

        }



        public bool DisableAddRemoveMWOItem =>!( Model.pSupplier.Id != 0 && SelectedItemToAdd.Id != 0
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
        public CommandMWOItem SelectedItemToAdd = new();
        public CommandPurchaseOrderItem SelectedItemAdded = new();
        public async Task AddItem()
        {



            CommandPurchaseOrderItem purchaseOrderItem = Service.GetDataForAddItem(SelectedItemToAdd, Model);



            if (await DialogService.Confirm($"Are you sure you want to add {SelectedItemToAdd.Name} to Purchase order item list?") == true)
            {

                Service.AddPurchaseOrderItemToMWOItem(Model, purchaseOrderItem, DialogData);


                SelectedItemToAdd = new();
                SelectedItemAdded = new();
            }



        }

        public void RemoveItem()
        {
            Service.RemovePurchaseOrderItemFromMWOItem(Model, DialogData, SelectedItemAdded.MWOItem.Id);

            StateHasChanged();


            SelectedItemToAdd = new();
            SelectedItemAdded = new();
        }
    }
}
