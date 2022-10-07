





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PipeClassFeatures.Command.CreateEdit
{
    public class AddEditPipeClassCommand : AddEditCommand, IRequest<Result<AddEditPipeClassCommand>>
    {

        public List<AddEditPipingItemCommand>? PipingItemsCommand { get; set; } = new();
        public List<AddEditNozzleCommand>? NozzlesCommand { get; set; } = new();
       
    }
    internal class AddEditPipeClassCommandHandler : IRequestHandler<AddEditPipeClassCommand, Result<AddEditPipeClassCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditPipeClassCommand> _logger;

        public AddEditPipeClassCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditPipeClassCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditPipeClassCommand>> Handle(AddEditPipeClassCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<PipeClass>(command);

                _unitOfWork.Repository<PipeClass>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditPipeClassCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(PipeClass)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<PipeClass>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditPipeClassCommand), typeof(PipeClass));

                    _unitOfWork.Repository<PipeClass>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditPipeClassCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(PipeClass)}");
                }
                else
                {
                    return await Result<AddEditPipeClassCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditPipeClassCommandValidator : AbstractValidator<AddEditPipeClassCommand>
    {
        public AddEditPipeClassCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
