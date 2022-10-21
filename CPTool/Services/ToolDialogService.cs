




using CPTool.Application.Features.Base.DeleteCommand;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.NewPages.Dialogs.BrandSupplier.Dialog;
using CPTool.NewPages.Dialogs.Material;
using CPTool.NewPages.Dialogs.Material.Dialog;
using CPTool.NewPages.Dialogs.MWO.Dialog;
using CPTool.NewPages.Dialogs.MWOItem.Dialog;
using CPTool.NewPages.Dialogs.Nozzle;
using CPTool.NewPages.Dialogs.Nozzle.Dialog;
using CPTool.NewPages.Dialogs.PipeDiameter.Dialog;
using CPTool.NewPages.Dialogs.ProcessFluid.Dialog;
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
        public async Task<DialogResult> ShowEquipmentType(EditEquipmentType model)
        {

            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = model.Id == 0 ? $"Add new EquipmentType" : $"Edit {model.Name} ";
            modeldialog.parameters.Add("Model", model);

            var dialog = DialogService.Show<EquipmenTypeDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);

            return await dialog.Result;


        }
        public async Task<DialogResult> ShowEquipmentTypeSub(EditEquipmentTypeSub model)
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
        public async Task<DialogResult> ShowNameDialog(EditCommand model)
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
        public async Task<DialogResult> ShowProcessFluidDialog(EditProcessFluid model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = model.Id == 0 ? $"Add new Process fluid" : $"Edit {model.Name} ";
            modeldialog.parameters.Add("Model", model);

            var dialog = DialogService.Show<ProcessFluidDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;

            return result;
        }

        public async Task<DialogResult> DeleteRow(Delete model)
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
        public async Task<DialogResult> ShowBrandDialog(EditBrandSupplier Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.Brand.Id==0 ? $"Add new Brand or Service" : $"Edit {Model.Brand.Name}";


            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<BrandDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            return result;
        }
        public async Task<DialogResult> ShowSupplierDialog(EditBrandSupplier Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.Supplier.Id == 0 ? $"Add new Brand or Service" : $"Edit {Model.Brand.Name}";


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
        public async Task<DialogResult> ShowMaterial(EditMaterial model)
        {

            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = model.Id == 0 ? $"Add new Material" : $"Edit {model.Name} ";
            modeldialog.parameters.Add("Model", model);

            var dialog = DialogService.Show<MaterialDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);

            return await dialog.Result;


        }
        public async Task<DialogResult> ShowMWO(EditMWO model)
        {

            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = model.Id == 0 ? $"Add new Material" : $"Edit {model.Name} ";
            modeldialog.parameters.Add("Model", model);

            var dialog = DialogService.Show<MWODialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);

            return await dialog.Result;


        }
        public async Task<DialogResult> ShowMWOItem(EditMWOItem model)
        {

            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = model.Id == 0 ? $"Add new Material" : $"Edit {model.Name} ";
            modeldialog.parameters.Add("Model", model);

            var dialog = DialogService.Show<MWOItemDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);

            return await dialog.Result;


        }
        //public async Task<DialogResult> ShowDialogName<T>(T Model) where T : AddCommand, new()
        //{
        //    ParameterDialogModel modeldialog = new();
        //    modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
        //    modeldialog.parameters = new DialogParameters();

        //    modeldialog.DialogTitle =model.Id == 0 ? $"Add new row " : $"Edit Item: {Model.Name}";
        //    modeldialog.parameters.Add("Model", Model);
        //    var dialog = DialogService.Show<TableNameDialog<T>>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
        //    return await dialog.Result;
        //}


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

        //        modeldialog.DialogTitle =model.Id==0?$"Add downpayment to PO#: {Model.PurchaseOrderDTO.PONumber}":$"Edit Downpayment {Model.Name}";


        //        modeldialog.parameters.Add("Model", Model);
        //        var dialog = DialogService.Show<DownpaymentDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
        //        var result = await dialog.Result;
        //        return result;
        //    }
        public async Task<DialogResult> ShowNozzleDialog(EditNozzle model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Small, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle =model.Id == 0 ? $"Add Nozzle " : $"Edit Nozzle {model.Name}";


            modeldialog.parameters.Add("Model", model);
            var dialog = DialogService.Show<NozzleDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            return result;
        }


        public async Task<DialogResult> ShowPipeDiameterDialog(EditPipeDiameter model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Small, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle =model.Id == 0 ? $"Add Pipe Diameter " : $"Edit Pipe Diameter {model.Name}";


            modeldialog.parameters.Add("Model", model);
            var dialog = DialogService.Show<PipeDiameterDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            return result;
        }
    }
}
