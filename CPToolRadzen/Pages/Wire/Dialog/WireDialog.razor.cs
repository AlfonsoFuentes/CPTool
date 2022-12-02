
using CPTool.Application.Features.WireFeatures.CreateEdit;


namespace CPToolRadzen.Pages.Wire.Dialog
{
    public partial class WireDialog : DialogTemplate<EditWire>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.Wires : RadzenTables.Wires.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
