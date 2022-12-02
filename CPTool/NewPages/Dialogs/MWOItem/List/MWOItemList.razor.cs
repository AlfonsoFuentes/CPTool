
using CPTool.Application.Features.MWOFeatures.Query.GetById;


namespace CPTool.NewPages.Dialogs.MWOItem.List
{
    public partial class MWOItemList
    {
       
       
        [Parameter]
        public int MWOId { get; set; }
        EditMWO MWO =>GlobalTables.MWOs.FirstOrDefault(x=>x.Id== MWOId);
        GetMWOItemListQuery getMWOItemList = new();
        GetMWOListQuery getMWOList = new();
        List<EditMWOItem> MWOItems => MWO.Id == 0 ? new() :
            GlobalTables.MWOItems.Where(x => x.MWOId == MWO.Id).ToList();

        EditMWOItem MWOItemSelected = new();
        
        async Task AddMWOItem()
        {
            EditMWOItem model = new();
            model.MWO = MWO;
          
            var result = await ToolDialogService.ShowMWOItem(model);
            if (!result.Cancelled)
            {
                GlobalTables.MWOs = await Mediator.Send(getMWOList);


                GlobalTables.MWOItems = await Mediator.Send(getMWOItemList);
            }
        }
        async Task EditMWOItem()
        {
            var result = await ToolDialogService.ShowMWOItem(MWOItemSelected);
            if (!result.Cancelled)
            {
                GlobalTables.MWOs = await Mediator.Send(getMWOList);
                GlobalTables.MWOItems = await Mediator.Send(getMWOItemList);
            }
        }
        async Task CreateTaskMWOItem()
        {
            EditTaks editTaks = new EditTaks();
            editTaks.MWO = MWO;
            editTaks.MWOItem = MWOItemSelected;
            editTaks.TaksType = Domain.Entities.TaksType.Manual;

            var result = await ToolDialogService.ShowTaksDialog(editTaks);
            if (!result.Cancelled)
            {
                GetTaksListQuery getTaksListQuery = new GetTaksListQuery();
                GlobalTables.Takss = await Mediator.Send(getTaksListQuery);
            }
        }
    }
}
