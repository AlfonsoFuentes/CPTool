



namespace CPTool.Pages.Dialogs
{
    public partial class BrandDialog : CancellableComponent
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
        private string ValidateBrandType(BrandType arg)
        {
            if (arg == BrandType.None)
                return "Must submit Brand or Service Type";
            

            return null;
        }
        protected override void OnInitialized()
        {
          

            base.OnInitialized();
        }


    }
}