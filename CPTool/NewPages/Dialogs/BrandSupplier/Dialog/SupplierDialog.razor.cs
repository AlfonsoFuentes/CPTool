
using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetList;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Query.GetList;
using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLDFeatures.Query.GetList;
using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLPFeatures.Query.GetList;
using CPTool.Application.Features.VendorCodeFeatures.CreateEdit;
using CPTool.Application.Features.VendorCodeFeatures.Query.GetList;
using static MudBlazor.Icons.Custom;

namespace CPTool.NewPages.Dialogs.BrandSupplier.Dialog
{
    public partial class SupplierDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditBrandSupplier Model { get; set; } = null!;
        [Inject]
        public IMediator mediator { get; set; }

        [Parameter]
        public MudForm form { get; set; } = null!;

    
       


        public async virtual Task Submit()
        {
            await Validateform();
            if (form.IsValid)
            {
                Model.InletBy = InletBy.Supplier;
                var result = await mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model.Supplier));
            }
        }
        async Task Validateform()
        {
            await form.Validate();
        }
        void Cancel() => MudDialog.Cancel();
        void SelectionBrand(EditBrand id)
        {
            Model.Brand = GlobalTables.Brands.FirstOrDefault(x => x == id);
        }
        private string ValidateSupplieName(string arg)
        {
            if (arg == null)
                return "Must submit Supplier";
            if (arg == "")
                return "Must submit Supplier";
            if(Model.Supplier.Id==0)
            {
                if (GlobalTables.Suppliers.Any(x => x.Name == arg))
                    return "Name already exist";
            }
            else
            {
                if (GlobalTables.Suppliers.Where(x => x.Id != Model.Supplier.Id).Any(x => x.Name == arg))
                    return "Name already exist";
            }
            


            return null;
        }
        private string ReviewVendorCode(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Vendor Code";
            if (!GlobalTables.VendorCodes.Any(x => x.Name == arg))
            {
                return $"Vendor Code: {arg} is not in the list";
            }
            if (Model.Supplier.Id == 0)
            {
                if (GlobalTables.Suppliers.Any(x => x.VendorCode.Name == arg))
                {
                    var vendor = (GlobalTables.Suppliers.First(x => x.VendorCode.Name == arg));
                    return $"Vendor Code: {arg} is assigned to Vendor: {vendor.Name}";
                }
            }
            else
            {
                if (GlobalTables.Suppliers.Where(x => x.Id != Model.Supplier.Id).Any(x => x.VendorCode.Name == arg))
                {
                    var vendor = (GlobalTables.Suppliers.First(x => x.VendorCode.Name == arg));
                    return $"Vendor Code: {arg} is assigned to Vendor: {vendor.Name}";
                }
            }


            return null;
        }
       
    }
}
