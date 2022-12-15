
using CPTool.Application.Features.SignalsFeatures.CreateEdit;


namespace CPToolRadzen.Pages.Signal.Dialog
{
    public partial class SignalDialog : DialogTemplate<EditSignal>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
            RadzenTables.MWOItems = await QueryMWOItem.GetAll();
            RadzenTables.SignalModifiers=await QuerySignalModifier.GetAll();
            RadzenTables.SignalTypes=await QuerySignalType.GetAll();
            RadzenTables.Wires=await QueryWire.GetAll();
            RadzenTables.FieldLocations=await QueryFieldLocation.GetAll();
            RadzenTables.ElectricalBoxs=await QueryElectricalBox.GetAll();
            
        }
        List<EditMWOItem> MWOItems => GetMWOItems();
        List<EditMWOItem> GetMWOItems()
        {
            var result = RadzenTables.MWOItems.Where(x => x.MWOId == Model.MWOId && x.TagId != "" && x.ChapterId != 6).ToList();
            return result;

        }
    }
}
