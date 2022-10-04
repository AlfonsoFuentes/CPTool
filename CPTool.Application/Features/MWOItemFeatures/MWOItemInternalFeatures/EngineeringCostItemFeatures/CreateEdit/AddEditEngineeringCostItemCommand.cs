using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.EngineeringCostItemFeatures.CreateEdit
{
    public class AddEditEngineeringCostItemCommand : AddEditCommand, IRequest<Result<AddEditEngineeringCostItemCommand>>
    {
    
        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }

    public class AddEditEngineeringCostItemCommandValidator : AbstractValidator<AddEditEngineeringCostItemCommand>
    {
        public AddEditEngineeringCostItemCommandValidator()
        {
           



        }
    }
}
