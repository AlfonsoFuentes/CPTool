using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.ContingencyItemFeatures.ContingencyItemFeatures.CreateEdit
{
    public class AddEditContingencyItemCommand : AddEditCommand, IRequest<Result<AddEditContingencyItemCommand>>
    {
      
        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }

    public class AddEditContingencyItemCommandValidator : AbstractValidator<AddEditContingencyItemCommand>
    {
        public AddEditContingencyItemCommandValidator()
        {
          


        }
    }
}
