using CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.ElectricalBox.Dialog
{
    public partial class ElectricalBoxDialog : DialogTemplate<EditElectricalBox>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.ElectricalBoxs : RadzenTables.ElectricalBoxs.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
