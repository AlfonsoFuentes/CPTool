namespace CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit
{
    public class EditEquipmentTypeSub : EditCommand, IRequest<Result<int>>
    {
       
        public string TagLetter { get; set; } = string.Empty;

        public int? EquipmentTypeId => EquipmentType == null ? null : EquipmentType?.Id;
        public EditEquipmentType? EquipmentType { get; set; } 
    }

}
