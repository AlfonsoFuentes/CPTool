





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.FoundationItemFeatures.Command.CreateEdit
{
    public class AddEditFoundationItemCommand : AddEditCommand, IRequest<Result<AddEditFoundationItemCommand>>
    {


         public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }
    internal class AddEditFoundationItemCommandHandler : IRequestHandler<AddEditFoundationItemCommand, Result<AddEditFoundationItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditFoundationItemCommand> _logger;

        public AddEditFoundationItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditFoundationItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditFoundationItemCommand>> Handle(AddEditFoundationItemCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<FoundationItem>(command);

                _unitOfWork.Repository<FoundationItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditFoundationItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(FoundationItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<FoundationItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditFoundationItemCommand), typeof(FoundationItem));

                    _unitOfWork.Repository<FoundationItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditFoundationItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(FoundationItem)}");
                }
                else
                {
                    return await Result<AddEditFoundationItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditFoundationItemCommandValidator : AbstractValidator<AddEditFoundationItemCommand>
    {
        public AddEditFoundationItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
