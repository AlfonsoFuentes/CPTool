namespace CPTool.Pages.Dialogs.MWOItemPage
{
    public partial class MWOItemDialog : IDisposable
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public MWOItemDTO Model { get; set; }
        MudForm form;
        EquipmentItemPage EquipmentItemPage;
        protected override void OnInitialized()
        {

            Model.UnitaryBasePrizeDTO = Model.UnitaryBasePrizeId == 0 ? new() : TablesService.ManUnitaryPrize.List.FirstOrDefault(x => x.Id == Model.UnitaryBasePrizeId);
            base.OnInitialized();
        }
        void Update()
        {
            Model.UnitaryBasePrizeDTO = Model.UnitaryBasePrizeId == 0 ? new() : TablesService.ManUnitaryPrize.List.FirstOrDefault(x => x.Id == Model.UnitaryBasePrizeId);

        }

        async Task Submit()
        {

            await form.Validate();
            if (form.IsValid)
            {
                if (Model.Id == 0) Model = _mapper.Map<CreateMWOItemDTO>(Model);
                MudDialog.Close(DialogResult.Ok(Model));
            }
        }


        void Cancel() => MudDialog.Cancel();

        void IDisposable.Dispose()
        {

        }
    }
}
