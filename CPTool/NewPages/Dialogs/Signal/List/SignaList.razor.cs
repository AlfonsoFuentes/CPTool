using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Query.GetById;
using CPTool.Application.Features.SignalFeatures.Query.GetList;
using CPTool.Application.Features.SignalsFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementFeatures.Query.GetList;
using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;

namespace CPTool.NewPages.Dialogs.Signal.List
{
    public partial class SignaList
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Inject]
        public IMediator mediator { get; set; }
        [Parameter]
        public int MWOId { get; set; }
        EditMWO MWO = new();

        List<EditSignal> MWOSignals => GlobalTables.Signals.Where(x => x.MWOId == MWOId).ToList();

        EditSignal SignalSelected = new();
        protected override async Task OnInitializedAsync()
        {
            GetByIdMWOQuery getByIdMWOQuery = new() { Id = MWOId };
            MWO = await mediator.Send(getByIdMWOQuery);
           

        }
        GetSignalListQuery getSignallist = new();
        async Task AddSignal()
        {
            EditSignal model = new();
            model.MWO = MWO;
           
            var result = await ToolDialogService.ShowSignalDialog(model);
            if (!result.Cancelled)
            {
               
                GlobalTables.Signals = await mediator.Send(getSignallist);
            }
        }
        async Task EditSignal()
        {
            var result = await ToolDialogService.ShowSignalDialog(SignalSelected);
            if (!result.Cancelled)
            {
            
                GlobalTables.Signals = await mediator.Send(getSignallist);
            }
        }
        async Task DeleteSignal()
        {
            var result = await ToolDialogService.ShowSignalDialog(SignalSelected);
            if (!result.Cancelled)
            {
                GetSignalListQuery getlist = new();
                GlobalTables.Signals = await mediator.Send(getlist);
            }
        }
    }
}
