using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.FoundationItemFeatures.CreateEdit
{
    public class AddEditFoundationItemCommand : AddEditCommand, IRequest<Result<AddEditFoundationItemCommand>>
    {
      
        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }

    public class AddEditFoundationItemCommandValidator : AbstractValidator<AddEditFoundationItemCommand>
    {
        public AddEditFoundationItemCommandValidator()
        {

        }
    }
}
