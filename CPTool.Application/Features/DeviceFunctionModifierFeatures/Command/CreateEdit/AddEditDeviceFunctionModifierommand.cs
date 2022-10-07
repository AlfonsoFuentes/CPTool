





using CPTool.Application.Features.InstrumentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.Command.CreateEdit
{
    public class AddEditDeviceFunctionModifierCommand : AddEditCommand, IRequest<Result<AddEditDeviceFunctionModifierCommand>>
    {


        public List<AddEditInstrumentItemCommand>? InstrumentItemsCommand { get; set; } = null!;

    }
    internal class AddEditDeviceFunctionModifierCommandHandler : IRequestHandler<AddEditDeviceFunctionModifierCommand, Result<AddEditDeviceFunctionModifierCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditDeviceFunctionModifierCommand> _logger;

        public AddEditDeviceFunctionModifierCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditDeviceFunctionModifierCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditDeviceFunctionModifierCommand>> Handle(AddEditDeviceFunctionModifierCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<DeviceFunctionModifier>(command);

                _unitOfWork.Repository<DeviceFunctionModifier>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditDeviceFunctionModifierCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(DeviceFunctionModifier)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<DeviceFunctionModifier>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditDeviceFunctionModifierCommand), typeof(DeviceFunctionModifier));

                    _unitOfWork.Repository<DeviceFunctionModifier>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditDeviceFunctionModifierCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(DeviceFunctionModifier)}");
                }
                else
                {
                    return await Result<AddEditDeviceFunctionModifierCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditDeviceFunctionModifierommandValidator : AbstractValidator<AddEditDeviceFunctionModifierCommand>
    {
        public AddEditDeviceFunctionModifierommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
