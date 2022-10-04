using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.PaintingItemFeatures.CreateEdit
{
    public class AddEditPaintingItemCommand : AddEditCommand, IRequest<Result<AddEditPaintingItemCommand>>
    {
        public string CostCenter { get; set; } = null!;
        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }

    public class AddEditPaintingItemCommandValidator : AbstractValidator<AddEditPaintingItemCommand>
    {
        public AddEditPaintingItemCommandValidator()
        {
            RuleFor(x => x.CostCenter)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(6).WithMessage("Max 6 characters");



        }
    }
}
