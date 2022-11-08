using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Query.GetById;
using CPTool.Application.Features.SignalFeatures.Query.GetList;
using CPTool.Application.Features.SignalsFeatures;
using CPTool.Application.Features.SignalsFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementFeatures.Query.GetList;
using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;

namespace CPTool.NewPages.Dialogs.Signal.List
{
    public partial class SignaList
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;

        [Parameter]
        public int MWOId { get; set; }
        EditMWO MWO = new();

        List<EditSignal> MWOSignals => GlobalTables.Signals.Where(x => x.MWOId == MWOId).ToList();

        EditSignal SignalSelected = new();
        void RowClicked(TableRowClickEventArgs<EditSignal> eq)
        {
            if (eq.Item.Id == SignalSelected.Id) return;

            SignalSelected = eq.Item;
           

        }
        protected override async Task OnInitializedAsync()
        {
            GetByIdMWOQuery getByIdMWOQuery = new() { Id = MWOId };
            MWO = await Mediator.Send(getByIdMWOQuery);
           

        }
        GetSignalListQuery getSignallist = new();
        async Task AddSignal()
        {
            EditSignal model = new();
            model.MWO = MWO;
           
            var result = await ToolDialogService.ShowSignalDialog(model);
            if (!result.Cancelled)
            {
               
                GlobalTables.Signals = await Mediator.Send(getSignallist);
            }
        }
        async Task EditSignal()
        {
            var result = await ToolDialogService.ShowSignalDialog(SignalSelected);
            if (!result.Cancelled)
            {
            
                GlobalTables.Signals = await Mediator.Send(getSignallist);
            }
        }
        async Task DeleteSignalFunction()
        {
            DeleteSignal ModelDelete = new() { Id = SignalSelected.Id, Name = SignalSelected.Name };

            var result = await ToolDialogService.DeleteRow(ModelDelete);
            if (!result.Cancelled)
            {
                GetSignalListQuery getlist = new();
                GlobalTables.Signals = await Mediator.Send(getlist);
            }
        }
    }
}
