using CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.ConnectionTypes.Dialog
{
    public partial class ConnectionTypesDialog : DialogTemplate<EditConnectionType>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.ConnectionTypes : RadzenTables.ConnectionTypes.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
