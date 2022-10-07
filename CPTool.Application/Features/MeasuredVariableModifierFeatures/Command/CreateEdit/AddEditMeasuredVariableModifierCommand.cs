





using CPTool.Application.Features.InstrumentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MeasuredVariableModifierFeatures.Command.CreateEdit
{
    public class AddEditMeasuredVariableModifierCommand : AddEditCommand, IRequest<Result<AddEditMeasuredVariableModifierCommand>>
    {


        public List<AddEditInstrumentItemCommand> InstrumentItemsCommand { get; set; } = new();
    }
    internal class AddEditMeasuredVariableModifierCommandHandler : IRequestHandler<AddEditMeasuredVariableModifierCommand, Result<AddEditMeasuredVariableModifierCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditMeasuredVariableModifierCommand> _logger;

        public AddEditMeasuredVariableModifierCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditMeasuredVariableModifierCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditMeasuredVariableModifierCommand>> Handle(AddEditMeasuredVariableModifierCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<MeasuredVariableModifier>(command);

                _unitOfWork.Repository<MeasuredVariableModifier>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditMeasuredVariableModifierCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(MeasuredVariableModifier)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<MeasuredVariableModifier>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditMeasuredVariableModifierCommand), typeof(MeasuredVariableModifier));

                    _unitOfWork.Repository<MeasuredVariableModifier>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditMeasuredVariableModifierCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(MeasuredVariableModifier)}");
                }
                else
                {
                    return await Result<AddEditMeasuredVariableModifierCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditMeasuredVariableModifierCommandValidator : AbstractValidator<AddEditMeasuredVariableModifierCommand>
    {
        public AddEditMeasuredVariableModifierCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
