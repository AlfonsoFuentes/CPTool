
using EquipmentCalculation;

namespace CPTool.Application.Features.PropertyPackageFeatures.CreateEdit
{
    public class EditPropertyPackage : EditCommand, IRequest<Result<int>>
    {
    

        public string TagLetter { get; set; } = "";
        public PropertyPackageCalculator? PropertyPackageCalculator { get; set; }
    }

}
