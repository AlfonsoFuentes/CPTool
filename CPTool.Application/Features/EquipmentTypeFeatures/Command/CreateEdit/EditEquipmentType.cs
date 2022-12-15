

namespace CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit
{
    public class EditEquipmentType : EditCommand, IRequest<Result<int>>
    {
        [Report(Order = 3)]
        public string TagLetter { get; set; } = string.Empty;


        public List<EditEquipmentTypeSub>? EquipmentTypeSubs { get; set; } = new();
        
    }
}
