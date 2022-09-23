

using CPTool.Pages.Components;
using CPTool.Pages.Dialogs;
using CPTool.Pages.Dialogs.MWOItemPage;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.Services
{
    public class ToolDialogService
    {
        readonly IDialogService DialogService;
        public ToolDialogService(IDialogService dialogService)
        {
            DialogService = dialogService;
        }
        public async Task<DialogResult> ShowEquipmentType(AuditableEntityDTO Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.Id == 0 ? $"Add new Equipment Type " : $"Edit row {Model.Name}";
            modeldialog.parameters.Add("Model", Model);

            var dialog = DialogService.Show<EquipmentTypeDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            return await dialog.Result;

        }
        public async Task<DialogResult> ShowEquipmentTypeSub(AuditableEntityDTO Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.Id == 0 ? $"Add new Equipment Type " : $"Edit row {Model.Name}";
            modeldialog.parameters.Add("Model", Model);

            var dialog = DialogService.Show<EquipmentTypeSubDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;

            return result;
        }

        public async Task<DialogResult> ShowMessageDialogYesNo(string message)
        {
            var parameters = new DialogParameters
            {
                { "ContentText", message },
                { "ButtonText", "Yes" },
                { "Color", Color.Error }
            };
            var dialog = DialogService.Show<MessageDialog>("", parameters);

            return await dialog.Result;
        }
        public async Task<DialogResult> ShowDialogMWO(AuditableEntityDTO Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.Id == 0 ? $"Add new MWO " : $"Edit {Model.Name}";


            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<MWOPageDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            return result;
        }
        public async Task<DialogResult> ShowDialogMWOItem(AuditableEntityDTO Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.Id == 0 ? $"Add new MWO Item" : $"Edit {Model.Name}";
            modeldialog.parameters.Add("Model", Model);

            var dialog = DialogService.Show<MWOItemDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            return result;
        }
        public async Task<DialogResult> ShowDialogName<TDTO>(TDTO Model) where TDTO : AuditableEntityDTO, new()
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();
           
            modeldialog.DialogTitle = Model.Id == 0 ? $"Add new row " : $"Edit Item: {Model.Name}";
            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<TableNameDialog<TDTO>>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            return await dialog.Result;
        }
        public async Task<DialogResult> ShowMaterialDialog(MaterialDTO Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.Id == 0 ? $"Add new Material " : $"Edit {Model.Name}";


            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<MaterialDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            return result;
        }
        public async Task<DialogResult> ShowSupplierDialog(BrandSupplierDTO Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.SupplierDTO.Id == 0 ? $"Add new Supplier " : $"Edit {Model.SupplierDTO.Name}";


            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<SupplierDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            return result;
        }
        public async Task<DialogResult> ShowBrandDialog(BrandSupplierDTO Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.BrandDTO.Id == 0 ? $"Add new Brand or Service" : $"Edit {Model.BrandDTO.Name}";


            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<BrandDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            return result;
        }

        public async Task<DialogResult> ShowPurchaseOrderDialog(PurchaseOrderMWOItemDTO Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.PurchaseOrderCreated == false ? $"Add new Purchase Order " : $"Edit {Model.PurchaseOrderDTO.Name}";


            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<PurchaseOrderDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            return result;
        }
        public async Task<DialogResult> ShowPurchaseOrderItemDialog(PurchaseOrderMWOItemDTO Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = "Relate PurchaseOrder to Items";


            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<PurchaseOrderItemDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            return result;
        }
        public async Task<DialogResult> ShowDownpaymentDialog(DownPaymentDTO Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.Id==0?$"Add downpayment to PO#: {Model.PurchaseOrderDTO.PONumber}":$"Edit Downpayment {Model.Name}";


            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<DownpaymentDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            return result;
        }
        public async Task<DialogResult> ShowNozzleDialog(NozzleDTO Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.Id == 0 ? $"Add Nozzle " : $"Edit Nozzle {Model.Name}";


            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<NozzleDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            return result;
        }
    }
}
