

namespace CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit
{
    public class EditUserRequirementType : EditCommand, IRequest<Result<int>>
    {

        public string Key { get; set; } = "";
    }
}
