using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.PipeDiameter.Dialog
{
    public partial class PipeDiameterDialog : DialogTemplate<EditPipeDiameter>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.PipeDiameters : RadzenTables.PipeDiameters.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
