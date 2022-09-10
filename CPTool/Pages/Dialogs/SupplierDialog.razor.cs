



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
                //Model.SupplierCreatedUpdate = true;
                //Model.BrandCreatedUpdate = false;
                MudDialog.Close(DialogResult.Ok(Model));
            }
        }


        void Cancel() => MudDialog.Cancel();
     
        protected override void OnInitialized()
        {
     
            base.OnInitialized();
        }
        
      
    }
}