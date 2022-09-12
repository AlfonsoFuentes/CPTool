



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
                if (Model.BrandId == 0 || Model.SupplierId == 0)
                {
                    Model = _mapper.Map<CreateBrandSupplierDTO>(Model);
                }
                else if (!TablesService.ManBrandSupplier.List.Any(x => x.BrandId == Model.BrandId && x.SupplierId == Model.SupplierId))
                {
                    Model = _mapper.Map<CreateBrandSupplierDTO>(Model);
                }
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