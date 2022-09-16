namespace CPTool.Pages.Dialogs
{
    public partial class PurchaseOrderItemDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }



        [Parameter]
        public PurchaseOrderMWOItemDTO Model { get; set; }

        List<MWOItemDTO> MWOItemDTOs = new();
        protected override void OnInitialized()
        {
            var mwoitems = Model.PurchaseOrderDTO.PurchaseOrderMWOItemDTOs;
            var mwo = mwoitems.FirstOrDefault().MWOItemDTO.MWODTO;

            MWOItemDTOs= mwo.MWOItemDTOs.Where(x=>x.PurchaseOrderMWOItemDTOs.Count==0).ToList(); 
            base.OnInitialized();
        }
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
        
    }
}
