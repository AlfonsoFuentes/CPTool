





using CPTool.Application.Features.InstrumentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MeasuredVariableFeatures.Command.CreateEdit
{
    public class AddEditMeasuredVariableCommand : AddEditCommand, IRequest<Result<AddEditMeasuredVariableCommand>>
    {
        public List<AddEditInstrumentItemCommand> InstrumentItemsCommand { get; set; } = new();

    }
    internal class AddEditMeasuredVariableCommandHandler : IRequestHandler<AddEditMeasuredVariableCommand, Result<AddEditMeasuredVariableCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditMeasuredVariableCommand> _logger;

        public AddEditMeasuredVariableCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditMeasuredVariableCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditMeasuredVariableCommand>> Handle(AddEditMeasuredVariableCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<MeasuredVariable>(command);

                _unitOfWork.Repository<MeasuredVariable>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditMeasuredVariableCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(MeasuredVariable)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<MeasuredVariable>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditMeasuredVariableCommand), typeof(MeasuredVariable));

                    _unitOfWork.Repository<MeasuredVariable>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditMeasuredVariableCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(MeasuredVariable)}");
                }
                else
                {
                    return await Result<AddEditMeasuredVariableCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditMeasuredVariableCommandValidator : AbstractValidator<AddEditMeasuredVariableCommand>
    {
        public AddEditMeasuredVariableCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
