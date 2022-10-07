





using CPTool.Application.Features.InstrumentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ReadoutFeatures.Command.CreateEdit
{
    public class AddEditReadoutCommand : AddEditCommand, IRequest<Result<AddEditReadoutCommand>>
    {


        public List<AddEditInstrumentItemCommand> InstrumentItemsCommand { get; set; } = new();
    }
    internal class AddEditReadoutCommandHandler : IRequestHandler<AddEditReadoutCommand, Result<AddEditReadoutCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditReadoutCommand> _logger;

        public AddEditReadoutCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditReadoutCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditReadoutCommand>> Handle(AddEditReadoutCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<Readout>(command);

                _unitOfWork.Repository<Readout>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditReadoutCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(Readout)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<Readout>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditReadoutCommand), typeof(Readout));

                    _unitOfWork.Repository<Readout>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditReadoutCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(Readout)}");
                }
                else
                {
                    return await Result<AddEditReadoutCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditReadoutCommandValidator : AbstractValidator<AddEditReadoutCommand>
    {
        public AddEditReadoutCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
