




using CPTool.Application.Features.BrandSupplierFeatures.Command.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.NewPages.Dialogs.BrandSupplier.Dialog;
using CPTool.NewPages.Dialogs.Material;
using CPTool.NewPages.Dialogs.MWO.Dialog;
using CPTool.Pages.Dialogs;

namespace CPTool.Services
{
    public class ToolDialogService
    {
        readonly IDialogService DialogService;

        public ToolDialogService(IDialogService dialogService)
        {
            DialogService = dialogService;

        }
        public async Task<DialogResult> ShowEquipmentType(AddEditEquipmentTypeCommand model)
        {

            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = model.Id == 0 ? $"Add new EquipmentType" : $"Edit {model.Name} ";
            modeldialog.parameters.Add("Model", model);

            var dialog = DialogService.Show<EquipmenTypeDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);

            return await dialog.Result;


        }
        public async Task<DialogResult> ShowEquipmentTypeSub(AddEditEquipmentTypeSubCommand model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = model.Id == 0 ? $"Add new EquipmentType Sub" : $"Edit {model.Name} ";
            modeldialog.parameters.Add("Model", model);

            var dialog = DialogService.Show<EquipmenTypeSubDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;

            return result;
        }
        public async Task<DialogResult> ShowNameDialog(AddEditCommand model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = model.Id == 0 ? $"Add new row" : $"Edit {model.Name} ";
            modeldialog.parameters.Add("Model", model);

            var dialog = DialogService.Show<NameDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;

            return result;
        }
        
        public async Task<DialogResult>  DeleteRow(DeleteCommand model)
        {

            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = $"{model.Name} ?";
            modeldialog.parameters.Add("Model", model);
            modeldialog.parameters.Add("Message", $"Are you sure delete {model.Name}");
            var dialog = DialogService.Show<DeleteDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;

            
            return result;
        }
        public async Task<DialogResult> ShowBrandDialog(AddEditBrandSupplierCommand Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.BrandCommand.Id == 0 ? $"Add new Brand or Service" : $"Edit {Model.BrandCommand.Name}";


            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<BrandDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            return result;
        }
        public async Task<DialogResult> ShowSupplierDialog(AddEditBrandSupplierCommand Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.SupplierCommand.Id == 0 ? $"Add new Brand or Service" : $"Edit {Model.BrandCommand.Name}";


            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<SupplierDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
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
        public async Task<DialogResult> ShowMaterial(AddEditMaterialCommand model)
        {

            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = model.Id == 0 ? $"Add new Material" : $"Edit {model.Name} ";
            modeldialog.parameters.Add("Model", model);

            var dialog = DialogService.Show<MaterialDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);

            return await dialog.Result;


        }
        public async Task<DialogResult> ShowMWO(AddEditMWOCommand model)
        {

            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = model.Id == 0 ? $"Add new Material" : $"Edit {model.Name} ";
            modeldialog.parameters.Add("Model", model);

            var dialog = DialogService.Show<MWODialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);

            return await dialog.Result;


        }
        public async Task<DialogResult> ShowMWOItem(AddEditMWOItemCommand model)
        {

            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Small, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = model.Id == 0 ? $"Add new Material" : $"Edit {model.Name} ";
            modeldialog.parameters.Add("Model", model);

            var dialog = DialogService.Show<MWOItemDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);

            return await dialog.Result;


        }
        public async Task<DialogResult> ShowDialogName<T>(T Model) where T : AddEditCommand, new()
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.Id == 0 ? $"Add new row " : $"Edit Item: {Model.Name}";
            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<TableNameDialog<T>>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            return await dialog.Result;
        }
        //    public async Task<DialogResult> ShowDialogMWO(AuditableEntityDTO Model)
        //    {
        //        ParameterDialogModel modeldialog = new();
        //        modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
        //        modeldialog.parameters = new DialogParameters();

        //        modeldialog.DialogTitle = Model.Id == 0 ? $"Add new MWO " : $"Edit {Model.Name}";


        //        modeldialog.parameters.Add("Model", Model);
        //        var dialog = DialogService.Show<MWOPageDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
        //        var result = await dialog.Result;
        //        return result;
        //    }
        //    public async Task<DialogResult> ShowDialogMWOItem(AuditableEntityDTO Model)
        //    {
        //        ParameterDialogModel modeldialog = new();
        //        modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
        //        modeldialog.parameters = new DialogParameters();

        //        modeldialog.DialogTitle = Model.Id == 0 ? $"Add new MWO Item" : $"Edit {Model.Name}";
        //        modeldialog.parameters.Add("Model", Model);

        //        var dialog = DialogService.Show<MWOItemDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
        //        var result = await dialog.Result;
        //        return result;
        //    }

        //    public async Task<DialogResult> ShowMaterialDialog(MaterialDTO Model)
        //    {
        //        ParameterDialogModel modeldialog = new();
        //        modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
        //        modeldialog.parameters = new DialogParameters();

        //        modeldialog.DialogTitle = Model.Id == 0 ? $"Add new Material " : $"Edit {Model.Name}";


        //        modeldialog.parameters.Add("Model", Model);
        //        var dialog = DialogService.Show<MaterialDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
        //        var result = await dialog.Result;
        //        return result;
        //    }
        //    public async Task<DialogResult> ShowSupplierDialog(BrandSupplierDTO Model)
        //    {
        //        ParameterDialogModel modeldialog = new();
        //        modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
        //        modeldialog.parameters = new DialogParameters();

        //        modeldialog.DialogTitle = Model.SupplierDTO.Id == 0 ? $"Add new Supplier " : $"Edit {Model.SupplierDTO.Name}";


        //        modeldialog.parameters.Add("Model", Model);
        //        var dialog = DialogService.Show<SupplierDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
        //        var result = await dialog.Result;
        //        return result;
        //    }
        //    public async Task<DialogResult> ShowBrandDialog(BrandSupplierDTO Model)
        //    {
        //        ParameterDialogModel modeldialog = new();
        //        modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
        //        modeldialog.parameters = new DialogParameters();

        //        modeldialog.DialogTitle = Model.BrandDTO.Id == 0 ? $"Add new Brand or Service" : $"Edit {Model.BrandDTO.Name}";


        //        modeldialog.parameters.Add("Model", Model);
        //        var dialog = DialogService.Show<BrandDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
        //        var result = await dialog.Result;
        //        return result;
        //    }

        //    public async Task<DialogResult> ShowPurchaseOrderDialog(PurchaseOrderMWOItemDTO Model)
        //    {
        //        ParameterDialogModel modeldialog = new();
        //        modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
        //        modeldialog.parameters = new DialogParameters();

        //        modeldialog.DialogTitle = Model.PurchaseOrderCreated == false ? $"Add new Purchase Order " : $"Edit {Model.PurchaseOrderDTO.Name}";


        //        modeldialog.parameters.Add("Model", Model);
        //        var dialog = DialogService.Show<PurchaseOrderDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
        //        var result = await dialog.Result;
        //        return result;
        //    }
        //    public async Task<DialogResult> ShowPurchaseOrderItemDialog(PurchaseOrderMWOItemDTO Model)
        //    {
        //        ParameterDialogModel modeldialog = new();
        //        modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
        //        modeldialog.parameters = new DialogParameters();

        //        modeldialog.DialogTitle = "Relate PurchaseOrder to Items";


        //        modeldialog.parameters.Add("Model", Model);
        //        var dialog = DialogService.Show<PurchaseOrderItemDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
        //        var result = await dialog.Result;
        //        return result;
        //    }
        //    public async Task<DialogResult> ShowDownpaymentDialog(DownPaymentDTO Model)
        //    {
        //        ParameterDialogModel modeldialog = new();
        //        modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
        //        modeldialog.parameters = new DialogParameters();

        //        modeldialog.DialogTitle = Model.Id==0?$"Add downpayment to PO#: {Model.PurchaseOrderDTO.PONumber}":$"Edit Downpayment {Model.Name}";


        //        modeldialog.parameters.Add("Model", Model);
        //        var dialog = DialogService.Show<DownpaymentDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
        //        var result = await dialog.Result;
        //        return result;
        //    }
        //    public async Task<DialogResult> ShowNozzleDialog(NozzleDTO Model)
        //    {
        //        ParameterDialogModel modeldialog = new();
        //        modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
        //        modeldialog.parameters = new DialogParameters();

        //        modeldialog.DialogTitle = Model.Id == 0 ? $"Add Nozzle " : $"Edit Nozzle {Model.Name}";


        //        modeldialog.parameters.Add("Model", Model);
        //        var dialog = DialogService.Show<NozzleDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
        //        var result = await dialog.Result;
        //        return result;
        //    }
    }
}
