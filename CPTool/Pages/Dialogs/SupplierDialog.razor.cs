



namespace CPTool.Pages.Dialogs
{
    public partial class SupplierDialog : CancellableComponent
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public BrandSupplierDTO Model { get; set; }



        MudForm form;
        async Task Submit()
        {

            await form.Validate();
            if (form.IsValid)
            {
               
                MudDialog.Close(DialogResult.Ok(Model));
            }
        }


        void Cancel() => MudDialog.Cancel();
        private string ReviewVendorCode(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Vendor Code";
            if (!TablesService.ManVendorCode.List.Any(x => x.Name == arg))
            {
                return $"Vendor Code: {arg} is not in the list";
            }
            if(Model.SupplierDTO.Id==0)
            {
                if (TablesService.ManSupplier.List.Any(x => x.VendorCodeDTO.Name == arg))
                {
                    var vendor = (TablesService.ManSupplier.List.First(x => x.VendorCodeDTO.Name == arg));
                    return $"Vendor Code: {arg} is assigned to Vendor: {vendor.Name}";
                }
            }
            else
            {
                if (TablesService.ManSupplier.List.Where(x=>x.Id!=Model.SupplierDTO.Id).Any(x => x.VendorCodeDTO.Name == arg))
                {
                    var vendor = (TablesService.ManSupplier.List.First(x => x.VendorCodeDTO.Name == arg));
                    return $"Vendor Code: {arg} is assigned to Vendor: {vendor.Name}";
                }
            }
            
                
            return null;
        }
        private string ReviewTaxCodeLD(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Tax Code LD";
            if (!TablesService.ManTaxCodeLD.List.Any(x => x.Name == arg))
                return $"Tax Code LD: {arg} is not in the list";
            return null;
        }
        private string ReviewTaxCodeLP(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Tax Code LP";
            if (!TablesService.ManTaxCodeLP.List.Any(x => x.Name == arg))
                return $"Tax Code LP: {arg} is not in the list";
            return null;
        }
        async Task UpdateVendorCode()
        {
            await TablesService.ManVendorCode.UpdateList();
            StateHasChanged();
            await form.Validate();
        }
        async Task UpdateTaxCodeLD()
        {
            await TablesService.ManTaxCodeLD.UpdateList();
            StateHasChanged();
            await form.Validate();
        }
        async Task UpdateTaxCodeLP()
        {
            await TablesService.ManTaxCodeLP.UpdateList();
            StateHasChanged();
            await form.Validate();
        }
        protected override void OnInitialized()
        {

            base.OnInitialized();
        }


    }
}