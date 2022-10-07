





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ContingencyItemFeatures.Command.CreateEdit
{
    public class AddEditContingencyItemCommand : AddEditCommand, IRequest<Result<AddEditContingencyItemCommand>>
    {


        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } =new();
    }
    internal class AddEditContingencyItemCommandHandler : IRequestHandler<AddEditContingencyItemCommand, Result<AddEditContingencyItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditContingencyItemCommand> _logger;

        public AddEditContingencyItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditContingencyItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditContingencyItemCommand>> Handle(AddEditContingencyItemCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<ContingencyItem>(command);

                _unitOfWork.Repository<ContingencyItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditContingencyItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(ContingencyItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<ContingencyItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditContingencyItemCommand), typeof(ContingencyItem));

                    _unitOfWork.Repository<ContingencyItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditContingencyItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(ContingencyItem)}");
                }
                else
                {
                    return await Result<AddEditContingencyItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditContingencyItemCommandValidator : AbstractValidator<AddEditContingencyItemCommand>
    {
        public AddEditContingencyItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
