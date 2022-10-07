





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.InsulationItemFeatures.Command.CreateEdit
{
    public class AddEditInsulationItemCommand : AddEditCommand, IRequest<Result<AddEditInsulationItemCommand>>
    {


         public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }
    internal class AddEditInsulationItemCommandHandler : IRequestHandler<AddEditInsulationItemCommand, Result<AddEditInsulationItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditInsulationItemCommand> _logger;

        public AddEditInsulationItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditInsulationItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditInsulationItemCommand>> Handle(AddEditInsulationItemCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<InsulationItem>(command);

                _unitOfWork.Repository<InsulationItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditInsulationItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(InsulationItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<InsulationItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditInsulationItemCommand), typeof(InsulationItem));

                    _unitOfWork.Repository<InsulationItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditInsulationItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(InsulationItem)}");
                }
                else
                {
                    return await Result<AddEditInsulationItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditInsulationItemCommandValidator : AbstractValidator<AddEditInsulationItemCommand>
    {
        public AddEditInsulationItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
