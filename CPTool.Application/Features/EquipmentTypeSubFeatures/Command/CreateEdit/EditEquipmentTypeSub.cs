

namespace CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit
{
    public class EditEquipmentTypeSub : EditCommand, IRequest<Result<int>>
    {
        [Report(Order = 3)]
        public string TagLetter { get; set; } = string.Empty;

        public int? EquipmentTypeId => EquipmentType == null ? null : EquipmentType?.Id;
        public EditEquipmentType? EquipmentType { get; set; }
        [Report(Order = 4)]
        public string EquipmentTypeName => EquipmentType!.Name;
    }

}
