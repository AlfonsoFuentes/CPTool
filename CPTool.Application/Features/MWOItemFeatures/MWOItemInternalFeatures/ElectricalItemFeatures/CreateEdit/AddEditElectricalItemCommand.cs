

using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.ElectricalItemFeatures.CreateEdit
{
    public class AddEditElectricalItemCommand : AddEditCommand, IRequest<Result<AddEditElectricalItemCommand>>
    {
       
        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }

    public class AddEditElectricalItemCommandValidator : AbstractValidator<AddEditElectricalItemCommand>
    {
        public AddEditElectricalItemCommandValidator()
        {
           


        }
    }
}
