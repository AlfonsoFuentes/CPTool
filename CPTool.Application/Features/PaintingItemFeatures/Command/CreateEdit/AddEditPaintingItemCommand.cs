





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PaintingItemFeatures.Command.CreateEdit
{
    public class AddEditPaintingItemCommand : AddEditCommand, IRequest<Result<AddEditPaintingItemCommand>>
    {


         public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }
}
