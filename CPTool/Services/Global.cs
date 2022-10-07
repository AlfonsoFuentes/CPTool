using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.Command.CreateEdit;

namespace CPTool.Services
{
    public static class Global
    {
        public static List<AddEditMWOCommand> MWOs { get; set; } = new();
        public static List<AddEditChapterCommand> Chapters { get; set; } = new();
        public static List<AddEditUnitaryBasePrizeCommand> UnitaryBasePrizes { get; set; } = new();
        public static List<AddEditEquipmentTypeCommand> EquipmentTypes { get; set; } = new();

    }
}
