
using CPTool.Application.Features.NozzleFeatures.CreateEdit;


namespace CPToolRadzen.Pages.Nozzle.Dialog
{
    public partial class NozzleDialog : DialogTemplate<EditNozzle>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.Nozzles : RadzenTables.Nozzles.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
