using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.EHSItemFeatures.CreateEdit
{
    public class AddEditEHSItemCommand : AddEditCommand, IRequest<Result<AddEditEHSItemCommand>>
    {
      
        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }

    public class AddEditEHSItemCommandValidator : AbstractValidator<AddEditEHSItemCommand>
    {
        public AddEditEHSItemCommandValidator()
        {
          



        }
    }
}
