using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;


namespace CPTool.NewPages.Dialogs.MWO.Dialog
{
    public partial class MWOItemEquipmentComponent
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected AddEditEquipmentItemCommand Model => DialogParent.Model.EquipmentItemCommand;


        private string ValidateEquipmentType(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Equipment Type";
            if (!Global.EquipmentTypes.Any(x => x.Name == arg))
                return $"Equipment Type: {arg} is not in the list";
            return null;
        }
        private string ValidateEquipmentSubType(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (!Model.EquipmentTypeCommand.EquipmentTypesSubCommand.Any(x => x.Name == arg))
                return $"Equipment Sub Type: {arg} is not in the list";
            return null;
        }
    }
}
