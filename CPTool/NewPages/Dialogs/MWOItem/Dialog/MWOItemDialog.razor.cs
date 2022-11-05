using CPTool.Application.Features.ChapterFeatures.CreateEdit;
using CPTool.Application.Features.ChapterFeatures.Query.GetList;
using CPTool.Application.Features.EquipmentItemFeatures.Query.GetById;
using CPTool.Application.Features.InstrumentItemFeatures.Query.GetById;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Query.GetById;
using CPTool.Application.Features.MWOFeatures.Query.GetList;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Query.GetById;
using CPTool.Application.Features.MWOItemFeatures.Query.GetList;
using CPTool.Application.Features.PipingItemFeatures.Query.GetById;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.Query.GetList;

namespace CPTool.NewPages.Dialogs.MWOItem.Dialog
{
    public partial class MWOItemDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditMWOItem Model { get; set; } = null!;
        

        protected override async Task OnInitializedAsync()
        {
            await GetDetails();
        }
        [Parameter]
        public MudForm form { get; set; } = null!;

        async Task GetDetails()
        {
            switch (Model.ChapterId)
            {
                case 4:
                    {
                        GetByIdEquipmentItemQuery getbyid = new() { Id = Model.EquipmentItemId.Value };
                        Model.EquipmentItem = await Mediator.Send(getbyid);
                    }
                    break;
                case 6:
                    {
                        GetByIdPipingItemQuery getbyid = new() { Id = Model.PipingItemId.Value };
                        Model.PipingItem = await Mediator.Send(getbyid);
                    }
                    break;
                case 7:
                    {
                        GetByIdInstrumentItemQuery getbyid = new() { Id = Model.InstrumentItemId.Value };
                        Model.InstrumentItem = await Mediator.Send(getbyid);
                    }
                    break;
            }
        }
        public async virtual Task Submit()
        {
            await Validateform();
            if (form.IsValid)
            {

                var result = await Mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();
        public async Task Validateform()
        {

            await form.Validate();
            StateHasChanged();
        }
        public string AnyName(string arg)
        {

            if (arg == null || arg == "") return "Must define a name";
            if (Model.Id != 0)
            {
                if (Model.MWO.MWOItems.Where(x => x.Id != Model.Id).Any(x => x.Name == arg)) return "Name already existing";
            }
            else
            {
                if (Model.MWO.MWOItems.Any(x => x.Name == arg)) return "Name already existing";
            }



            return null;
        }
        async Task UpdateFormFromChild()
        {
            GetByIdMWOItemQuery getbyid = new() { Id = Model.Id };

            Model = await Mediator.Send(getbyid);
        }
    }
}
