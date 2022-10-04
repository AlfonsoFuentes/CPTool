using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.TestingItemFeatures.CreateEdit
{
    public class AddEditTestingItemCommand : AddEditCommand, IRequest<Result<AddEditTestingItemCommand>>
    {
        public string CostCenter { get; set; } = null!;
        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }

    public class AddEditTestingItemCommandValidator : AbstractValidator<AddEditTestingItemCommand>
    {
        public AddEditTestingItemCommandValidator()
        {
            RuleFor(x => x.CostCenter)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(6).WithMessage("Max 6 characters");



        }
    }
}
