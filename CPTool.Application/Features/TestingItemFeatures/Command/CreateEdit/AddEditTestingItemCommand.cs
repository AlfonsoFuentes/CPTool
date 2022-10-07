





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.TestingItemFeatures.Command.CreateEdit
{
    public class AddEditTestingItemCommand : AddEditCommand, IRequest<Result<AddEditTestingItemCommand>>
    {


         public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }
    internal class AddEditTestingItemCommandHandler : IRequestHandler<AddEditTestingItemCommand, Result<AddEditTestingItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditTestingItemCommand> _logger;

        public AddEditTestingItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditTestingItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditTestingItemCommand>> Handle(AddEditTestingItemCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<TestingItem>(command);

                _unitOfWork.Repository<TestingItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditTestingItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(TestingItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<TestingItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditTestingItemCommand), typeof(TestingItem));

                    _unitOfWork.Repository<TestingItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditTestingItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(TestingItem)}");
                }
                else
                {
                    return await Result<AddEditTestingItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditTestingItemCommandValidator : AbstractValidator<AddEditTestingItemCommand>
    {
        public AddEditTestingItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
