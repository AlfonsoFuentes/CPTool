using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Pages.MWOItems.Dialog
{
    public partial class MWOItemNozzlesDialog
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected EditMWOItem Model => DialogParent.Model;
        List<EditNozzle> Nozzles => GetNozzles(Model.Chapter.Id);
        public List<EditNozzle> GetNozzles(int chapterid) =>
    chapterid switch
    {
        4 => Model.EquipmentItem.Nozzles,
        6 => Model.PipingItem.Nozzles,
        7 => Model.InstrumentItem.Nozzles,

        _ => new(),
    };
        string TableName => GetTableName(Model.Chapter.Id);
        public string GetTableName(int chapterid) =>
   chapterid switch
   {
       4 => "Equipment Nozzles",
       6 => "Piping Nozzles",
       7 => "Instrument Nozzles",

       _ => "",
   };

    }
}
