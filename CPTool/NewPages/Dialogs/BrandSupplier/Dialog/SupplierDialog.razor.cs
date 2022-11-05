



namespace CPTool.NewPages.Dialogs.BrandSupplier.Dialog
{
    public partial class SupplierDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditBrandSupplier Model { get; set; } = null!;
       
        [Parameter]
        public MudForm form { get; set; } = null!;


        GetBrandSupplierListQuery brandsuplierlist = new();


        public async virtual Task Submit()
        {
            await Validateform();
            if (form.IsValid)
            {
               
                var resultsupplier = await Mediator.Send(Model.Supplier);
                if (resultsupplier.Succeeded)
                {

                    var result = await Mediator.Send(Model);
                    
                }
              

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
           
            if (Model.Supplier.Id == 0)
            {
                if (GlobalTables.Suppliers.Any(x => x.VendorCode == arg))
                {
                    var vendor = (GlobalTables.Suppliers.First(x => x.VendorCode == arg));
                    return $"Vendor Code: {arg} is assigned to Vendor: {vendor.Name}";
                }
            }
            else
            {
                if (GlobalTables.Suppliers.Where(x => x.Id != Model.Supplier.Id).Any(x => x.VendorCode == arg))
                {
                    var vendor = (GlobalTables.Suppliers.First(x => x.VendorCode == arg));
                    return $"Vendor Code: {arg} is assigned to Vendor: {vendor.Name}";
                }
            }


            return null;
        }
       
    }
}
