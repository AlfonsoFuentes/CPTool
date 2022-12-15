
using CPTool.Application.Features.NozzleFeatures.CreateEdit;


namespace CPToolRadzen.Pages.Nozzle.Dialog
{
    public partial class NozzleDialog : DialogTemplate<EditNozzle>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
            RadzenTables.PipeClasses=await QueryPipeClass.GetAll();
            RadzenTables.PipeDiameters=await QueryPipeDiameter.GetAll();
            RadzenTables.ConnectionTypes=await QueryConnectionType.GetAll();
            RadzenTables.Materials=await QueryMaterial.GetAll();
            RadzenTables.Gaskets=await QueryGasket.GetAll();
        }
    }
}
