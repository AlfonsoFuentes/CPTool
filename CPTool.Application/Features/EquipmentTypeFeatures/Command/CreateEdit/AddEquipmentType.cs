

using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;

namespace CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit
{
    public class AddEquipmentType : AddCommand, IRequest<Result<int>>
    {

        public string TagLetter { get; set; } = string.Empty;

    }
}
