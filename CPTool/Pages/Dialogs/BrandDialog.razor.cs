



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
                //Model.SupplierCreatedUpdate = false;
                //Model.BrandCreatedUpdate = true;
                MudDialog.Close(DialogResult.Ok(Model));
            }
        }


        void Cancel() => MudDialog.Cancel();
     
        protected override void OnInitialized()
        {
            //Model.BrandCreatedUpdate = false;
          
            base.OnInitialized();
        }
        
      
    }
}