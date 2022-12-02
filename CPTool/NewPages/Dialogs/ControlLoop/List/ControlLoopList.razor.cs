
using CPTool.Application.Features.ControlLoopFeatures;
using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Application.Features.ControlLoopFeatures.Query.GetList;
using CPTool.Application.Features.MWOFeatures.Query.GetById;
using CPTool.Application.Features.SignalsFeatures;

namespace CPTool.NewPages.Dialogs.ControlLoop.List
{
    public partial class ControlLoopList
    {

        EditControlLoop SelectedControlLoop { get; set; } = new();

        List<EditControlLoop> ControlLoops => MWO.Id == 0 ? new() :
           GlobalTables.ControlLoops.Where(x => x.MWOId == MWO.Id).ToList();

        [Parameter]
        public int MWOId { get; set; }
        EditMWO MWO => GlobalTables.MWOs.FirstOrDefault(x => x.Id == MWOId);
       
        GetControlLoopListQuery GetControlLoopListQuery = new();
        async Task AddControlLoop()
        {
            EditControlLoop model = new();
            model.MWO = MWO;

            var result = await ToolDialogService.ShowControlLoopDialog(model);
            if (!result.Cancelled)
            {

                GlobalTables.ControlLoops = await Mediator.Send(GetControlLoopListQuery);
            }
        }
        async Task EditControlLoop ()
        {
            var result = await ToolDialogService.ShowControlLoopDialog(SelectedControlLoop);
            if (!result.Cancelled)
            {

                GlobalTables.ControlLoops = await Mediator.Send(GetControlLoopListQuery);
            }
        }
        async Task DeleteSignalFunction()
        {
            DeleteControlLoop ModelDelete = new() { Id = SelectedControlLoop.Id, Name = SelectedControlLoop.Name };

            var result = await ToolDialogService.DeleteRow(ModelDelete);
            if (!result.Cancelled)
            {

                GlobalTables.ControlLoops = await Mediator.Send(GetControlLoopListQuery);
            }
        }
    }
}
