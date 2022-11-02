




using CPTool.Application.Features.Base.DeleteCommand;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.Query.GetList;
using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.Query.GetList;
using CPTool.NewPages.Dialogs.BrandSupplier.Dialog;
using CPTool.NewPages.Dialogs.Downpayment.Dialogs;
using CPTool.NewPages.Dialogs.Material;
using CPTool.NewPages.Dialogs.Material.Dialog;
using CPTool.NewPages.Dialogs.MWO.Dialog;
using CPTool.NewPages.Dialogs.MWOItem.Dialog;
using CPTool.NewPages.Dialogs.Nozzle;
using CPTool.NewPages.Dialogs.Nozzle.Dialog;
using CPTool.NewPages.Dialogs.PipeDiameter.Dialog;
using CPTool.NewPages.Dialogs.ProcessFluid.Dialog;
using CPTool.NewPages.Dialogs.PurchaseOrder.Dialog;
using CPTool.NewPages.Dialogs.Taks.Dialog;
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

        public async Task<DialogResult> ShowTaksDialog(EditTaks model)
        {
            if(model.TaksType== Domain.Entities.TaksType.Manual)
            {
                ParameterDialogModel modeldialog = new();
                modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true };
                modeldialog.parameters = new DialogParameters();

                modeldialog.DialogTitle = model.Id == 0 ? $"Add new Task" : $"Edit {model.Name} ";
                modeldialog.parameters.Add("Model", model);

                var dialog = DialogService.Show<TaksDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
                var result = await dialog.Result;

                return result;
            }
            return await ShowMessageDialogYesNo($"Automatic Task!!! ");

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

        public async Task<DialogResult> DeleteRow(DeleteCommand model)
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

            modeldialog.DialogTitle = Model.Brand.Id == 0 ? $"Add new Brand or Service" : $"Edit {Model.Brand.Name}";


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
        public async Task<DialogResult> ShowPurchaseOrderMWOItem(EditPurchaseOrderMWOItem model)
        {



            return await ShowMWOItem(model.MWOItem);


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
       


        public async Task<DialogResult> ShowPurchaseOrderDialog(CreateEditPurchaseOrder Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.Id == 0 ? $"Add new Purchase Order " : $"Edit {Model.Name}";


            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<CreatePurchaseOrderDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            
            return result;
        }
        public async Task<DialogResult> ShowEditPurchaseOrderDialog(EditPurchaseOrder Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.Id == 0 ? $"Add new Purchase Order " : $"Edit {Model.Name}";


            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<EditPurchaseOrderDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            return result;
        }
        public async Task<DialogResult> ShowAddDataToPurchaseOrderDialog(EditPurchaseOrder Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.Id == 0 ? $"Add Data to MWO Item " : $"Edit {Model.Name}";


            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<AddDataToPuchaseOrderDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            return result;
        }

        public async Task<DialogResult> ShowDownpaymentDialog(EditDownPayment Model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = Model.Id == 0 ? $"Add downpayment to PO#: {Model.PurchaseOrder.PONumber}" : $"Edit Downpayment {Model.Name}";


            modeldialog.parameters.Add("Model", Model);
            var dialog = DialogService.Show<CreateDownpaymentDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
           
            
            return result;
        }
        public async Task<DialogResult> ShowNozzleDialog(EditNozzle model)
        {
            ParameterDialogModel modeldialog = new();
            modeldialog.options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Small, FullWidth = true };
            modeldialog.parameters = new DialogParameters();

            modeldialog.DialogTitle = model.Id == 0 ? $"Add Nozzle " : $"Edit Nozzle {model.Name}";


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

            modeldialog.DialogTitle = model.Id == 0 ? $"Add Pipe Diameter " : $"Edit Pipe Diameter {model.Name}";


            modeldialog.parameters.Add("Model", model);
            var dialog = DialogService.Show<PipeDiameterDialog>(modeldialog.DialogTitle, modeldialog.parameters, modeldialog.options);
            var result = await dialog.Result;
            return result;
        }
    }
}
