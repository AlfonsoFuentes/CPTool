using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.Material.Dialog
{
    public partial class MaterialDialog : DialogTemplate<EditMaterial>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.Materials : RadzenTables.Materials.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
