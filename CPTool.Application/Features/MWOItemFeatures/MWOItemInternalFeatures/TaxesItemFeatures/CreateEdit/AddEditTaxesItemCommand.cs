using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.TaxesItemFeatures.CreateEdit
{
    public class AddEditTaxesItemCommand : AddEditCommand, IRequest<Result<AddEditTaxesItemCommand>>
    {
        public string CostCenter { get; set; } = null!;
        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }

    public class AddEditTaxesItemCommandValidator : AbstractValidator<AddEditTaxesItemCommand>
    {
        public AddEditTaxesItemCommandValidator()
        {
            RuleFor(x => x.CostCenter)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(6).WithMessage("Max 6 characters");



        }
    }
}
