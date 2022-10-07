





using CPTool.Application.Features.InstrumentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionFeatures.Command.CreateEdit
{
    public class AddEditDeviceFunctionCommand : AddEditCommand, IRequest<Result<AddEditDeviceFunctionCommand>>
    {

        public List<AddEditInstrumentItemCommand>? InstrumentItemsCommand { get; set; } = null!;
        public string? TagLetter { get; set; }
    
    }
    internal class AddEditDeviceFunctionCommandHandler : IRequestHandler<AddEditDeviceFunctionCommand, Result<AddEditDeviceFunctionCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditDeviceFunctionCommand> _logger;

        public AddEditDeviceFunctionCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditDeviceFunctionCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditDeviceFunctionCommand>> Handle(AddEditDeviceFunctionCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<DeviceFunction>(command);

                _unitOfWork.Repository<DeviceFunction>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditDeviceFunctionCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(DeviceFunction)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<DeviceFunction>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditDeviceFunctionCommand), typeof(DeviceFunction));

                    _unitOfWork.Repository<DeviceFunction>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditDeviceFunctionCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(DeviceFunction)}");
                }
                else
                {
                    return await Result<AddEditDeviceFunctionCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditDeviceFunctionCommandValidator : AbstractValidator<AddEditDeviceFunctionCommand>
    {
        public AddEditDeviceFunctionCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
