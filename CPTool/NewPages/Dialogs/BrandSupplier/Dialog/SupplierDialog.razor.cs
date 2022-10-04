
using CPTool.Application.Features.BrandFeatures.Command.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetList;
using CPTool.Application.Features.BrandSupplierFeatures.Command.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Command.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Query.GetList;
using CPTool.Application.Features.TaxCodeLDFeatures.Command.CreateEdit;
using CPTool.Application.Features.TaxCodeLDFeatures.Query.GetList;
using CPTool.Application.Features.TaxCodeLPFeatures.Command.CreateEdit;
using CPTool.Application.Features.TaxCodeLPFeatures.Query.GetList;
using CPTool.Application.Features.VendorCodeFeatures.Command.CreateEdit;
using CPTool.Application.Features.VendorCodeFeatures.Query.GetList;

namespace CPTool.NewPages.Dialogs.BrandSupplier.Dialog
{
    public partial class SupplierDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public AddEditBrandSupplierCommand Model { get; set; } = null!;
        [Inject]
        public IMediator mediator { get; set; }

        [Parameter]
        public MudForm form { get; set; } = null!;

        List<AddEditSupplierCommand> Suppliers = new();
        List<AddEditBrandCommand> Brands = new();
        GetBrandListQuery BrandList = new();
        GetSupplierListQuery SupplierList = new();
        GetVendorCodeListQuery VendorCodeListQuery = new();
        List<AddEditVendorCodeCommand> VendorCodes = new();
        GetTaxCodeLDListQuery GetTaxCodeLDListQuery = new();
        List<AddEditTaxCodeLDCommand> TaxCodeLDs = new();
        GetTaxCodeLPListQuery GetTaxCodeLPListQuery = new();
        List<AddEditTaxCodeLPCommand> TaxCodeLPs = new();

        protected override async Task OnInitializedAsync()
        {
            Suppliers = await mediator.Send(SupplierList);
            Brands = await mediator.Send(BrandList);
            VendorCodes = await mediator.Send(VendorCodeListQuery);
            TaxCodeLDs = await mediator.Send(GetTaxCodeLDListQuery);
            TaxCodeLPs = await mediator.Send(GetTaxCodeLPListQuery);
        }
        public async virtual Task Submit()
        {
            await Validateform();
            if (form.IsValid)
            {
                Model.InletBy = InletBy.Supplier;
                var result = await mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model.SupplierCommand));
            }
        }
        async Task Validateform()
        {
            await form.Validate();
        }
        void Cancel() => MudDialog.Cancel();
        void SelectionBrand(AddEditBrandCommand id)
        {
            Model.BrandCommand = Brands.FirstOrDefault(x => x == id);
        }
        private string ValidateSupplieName(string arg)
        {
            if (arg == null)
                return "Must submit Supplier";
            if (arg == "")
                return "Must submit Supplier";
            if(Model.SupplierCommand.Id==0)
            {
                if (Suppliers.Any(x => x.Name == arg))
                    return "Name already exist";
            }
            else
            {
                if (Suppliers.Where(x => x.Id != Model.SupplierCommand.Id).Any(x => x.Name == arg))
                    return "Name already exist";
            }
            


            return null;
        }
        private string ReviewVendorCode(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Vendor Code";
            if (!VendorCodes.Any(x => x.Name == arg))
            {
                return $"Vendor Code: {arg} is not in the list";
            }
            if (Model.SupplierCommand.Id == 0)
            {
                if (Suppliers.Any(x => x.VendorCodeCommand.Name == arg))
                {
                    var vendor = (Suppliers.First(x => x.VendorCodeCommand.Name == arg));
                    return $"Vendor Code: {arg} is assigned to Vendor: {vendor.Name}";
                }
            }
            else
            {
                if (Suppliers.Where(x => x.Id != Model.SupplierCommand.Id).Any(x => x.VendorCodeCommand.Name == arg))
                {
                    var vendor = (Suppliers.First(x => x.VendorCodeCommand.Name == arg));
                    return $"Vendor Code: {arg} is assigned to Vendor: {vendor.Name}";
                }
            }


            return null;
        }
        private string ReviewTaxCodeLD(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Tax Code LD";
            if (!TaxCodeLDs.Any(x => x.Name == arg))
                return $"Tax Code LD: {arg} is not in the list";
            return null;
        }
        private string ReviewTaxCodeLP(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Tax Code LP";
            if (!TaxCodeLPs.Any(x => x.Name == arg))
                return $"Tax Code LP: {arg} is not in the list";
            return null;
        }
    }
}
