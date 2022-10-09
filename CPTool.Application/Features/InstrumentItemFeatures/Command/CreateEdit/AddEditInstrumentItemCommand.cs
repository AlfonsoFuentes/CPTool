





using CPTool.Application.Features.BrandFeatures.Command.CreateEdit;
using CPTool.Application.Features.DeviceFunctionFeatures.Command.CreateEdit;
using CPTool.Application.Features.DeviceFunctionModifierFeatures.Command.CreateEdit;
using CPTool.Application.Features.GasketsFeatures.Command.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.Command.CreateEdit;
using CPTool.Application.Features.MeasuredVariableFeatures.Command.CreateEdit;
using CPTool.Application.Features.MeasuredVariableModifierFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.Command.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.Command.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.Command.CreateEdit;
using CPTool.Application.Features.ReadoutFeatures.Command.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.InstrumentItemFeatures.Command.CreateEdit
{
    public class AddEditInstrumentItemCommand : AddEditCommand, IRequest<Result<AddEditInstrumentItemCommand>>
    {
        public int? ProcessConditionId => ProcessConditionCommand.Id == 0 ? null : ProcessConditionCommand.Id;
        public AddEditProcessConditionCommand ProcessConditionCommand { get; set; } = new();
        public int? ProcessFluidId => ProcessFluidCommand == null ? null : ProcessFluidCommand.Id;
        public AddEditProcessFluidCommand? ProcessFluidCommand { get; set; }
        public List<AddEditNozzleCommand>? NozzlesCommand { get; set; } =new();
      
        public int? GasketId => GasketCommand == null ? null : GasketCommand.Id;
        public AddEditGasketCommand? GasketCommand { get; set; } = null!;
        public int? iInnerMaterialId => iInnerMaterialCommand == null ? null : iInnerMaterialCommand.Id;
        public AddEditMaterialCommand? iInnerMaterialCommand { get; set; } = null!;
        public int? iOuterMaterialId => iOuterMaterialCommand == null ? null : iOuterMaterialCommand.Id;
        public AddEditMaterialCommand? iOuterMaterialCommand { get; set; } = null!;
        public int? MeasuredVariableId => MeasuredVariableCommand == null ? null : MeasuredVariableCommand.Id;
        public AddEditMeasuredVariableCommand? MeasuredVariableCommand { get; set; }
        public int? MeasuredVariableModifierId => MeasuredVariableModifierCommand == null ? null : MeasuredVariableModifierCommand.Id;
        public AddEditMeasuredVariableModifierCommand? MeasuredVariableModifierCommand { get; set; }
        public int? DeviceFunctionId => DeviceFunctionCommand == null ? null : DeviceFunctionCommand.Id;
        public AddEditDeviceFunctionCommand? DeviceFunctionCommand { get; set; }
        public int? DeviceFunctionModifierId => DeviceFunctionModifierCommand == null ? null : DeviceFunctionModifierCommand.Id;
        public AddEditDeviceFunctionModifierCommand? DeviceFunctionModifierCommand { get; set; }
        public int? ReadoutId => ReadoutCommand == null ? null : ReadoutCommand.Id;
        public AddEditReadoutCommand? ReadoutCommand { get; set; }

        public int? BrandId => BrandCommand == null ? null : BrandCommand.Id;
        public AddEditBrandCommand? BrandCommand { get; set; }
        public int? SupplierId => SupplierCommand == null ? null : SupplierCommand.Id;
        public AddEditSupplierCommand? SupplierCommand { get; set; }
        public string TagId { get; set; }=String.Empty;
        public string? TagLetter { get; set; }
        public string? TagNumber { get; set; }
        public string? Model { get; set; }
        public string? Reference { get; set; }
        public string? SerialNumber { get; set; }

        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }
    internal class AddEditInstrumentItemCommandHandler : IRequestHandler<AddEditInstrumentItemCommand, Result<AddEditInstrumentItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditInstrumentItemCommand> _logger;

        public AddEditInstrumentItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditInstrumentItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditInstrumentItemCommand>> Handle(AddEditInstrumentItemCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<InstrumentItem>(command);

                _unitOfWork.Repository<InstrumentItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditInstrumentItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(InstrumentItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<InstrumentItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditInstrumentItemCommand), typeof(InstrumentItem));

                    _unitOfWork.Repository<InstrumentItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditInstrumentItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(InstrumentItem)}");
                }
                else
                {
                    return await Result<AddEditInstrumentItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditInstrumentItemCommandValidator : AbstractValidator<AddEditInstrumentItemCommand>
    {
        public AddEditInstrumentItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
