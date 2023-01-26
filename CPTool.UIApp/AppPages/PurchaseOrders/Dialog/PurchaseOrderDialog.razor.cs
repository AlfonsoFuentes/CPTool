using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.Domain.Enums;
using CPTool.Services;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using CPTool.Domain.Entities;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CPTool.UIApp.AppPages.PurchaseOrders.Dialog
{
    public partial class PurchaseOrderDialog
    {
        [Parameter]
        public bool SaveDialog { get; set; } = true;
        [Inject]
        IMWOService MWOService { get; set; }
        [Inject]
        public IPurchaseOrderService Service { get; set; }
        [Parameter]
        public CommandPurchaseOrder Model { get; set; } = new();
        [Parameter]
        public int MWOId { get; set; } = 0;
        [Parameter]
        public int PurchaseOrderId { get; set; } = 0;

        public PurchaseOrderDialogData DialogData = new();
        string ButtonSaveName => Service.GetButtonName(Model);
        bool DisableButtonSave => Service.DisableButtonSave(Model);
        CommandMWO MWO;
        protected override async Task OnInitializedAsync()
        {
            if (MWOId != 0)
            {
                MWO = await MWOService.GetById(MWOId);
            }

            if (PurchaseOrderId != 0)
            {
                Model = await Service.GetById(PurchaseOrderId);
            }

            else
            {
                Model.MWO = MWO;
            }

            DialogData = await Service.GetPurchaseOrderDataDialog(Model);


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



        public bool DisableAddRemoveBudgetMWOItem => GetDisableAddRemoveBudgetMWOItem();
        bool GetDisableAddRemoveBudgetMWOItem()
        {
            //if (Model.Id != 0) return true;
            return !(Model.pSupplier.Id != 0 && BudgetItemToAdd.Id != 0
                                                    && Model.Currency != Currency.None);
        }
        public bool DisableAddRemoveDesignMWOItem => GetDisableAddRemoveDesignMWOItem();
        bool GetDisableAddRemoveDesignMWOItem()
        {
            //if (Model.Id != 0) return true;
            return !(Model.pSupplier.Id != 0 && DesignItemToAdd.Id != 0
                                                    && Model.Currency != Currency.None);
        }
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
        public CommandMWOItem BudgetItemToAdd = new();
        public CommandPurchaseOrderItem BudgetItemAdded = new();
        public CommandMWOItem DesignItemToAdd = new();
        public CommandPurchaseOrderItem DesignItemAdded = new();
        public async Task AddItemBudget()
        {


            if (await DialogService.Confirm($"Are you sure you want to add {BudgetItemToAdd.Name} to Purchase order item list?") == true)
            {
                await Service.AddMWOItemBudget(BudgetItemToAdd, Model, DialogData);

                StateHasChanged();

                BudgetItemToAdd = new();
                BudgetItemAdded = new();
               
            }



        }

        public void RemoveItemBudget()
        {
            Service.RemoveMWOItemBudgetFromPurchaseOrder(Model, DialogData, BudgetItemAdded.MWOItem.Id);

            StateHasChanged();


            BudgetItemToAdd = new();
            BudgetItemAdded = new();
        }
        public async Task AddItemDesign()
        {


            if (await DialogService.Confirm($"Are you sure you want to add {BudgetItemToAdd.Name} to Purchase order item list?") == true)
            {
                await Service.AddMWOItemDesign(DesignItemToAdd, Model, DialogData);

                StateHasChanged();

                DesignItemToAdd = new();
                DesignItemAdded = new();

            }



        }

        public void RemoveItemDesign()
        {
            Service.RemoveMWOItemBudgetFromPurchaseOrder(Model, DialogData, DesignItemAdded.MWOItem.Id);

            StateHasChanged();


            DesignItemToAdd = new();
            DesignItemAdded = new();
        }
        void GoBack()
        {
            NavigationManager.NavigateTo($"/mwo-items/{MWOId}");
        }
        async Task ReportDialog()
        {
            await Task.CompletedTask;
        }
        List<string> errors = new();
        protected bool errorVisible;
    }
}
