





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.StructuralItemFeatures.Command.CreateEdit
{
    public class AddEditStructuralItemCommand : AddEditCommand, IRequest<Result<AddEditStructuralItemCommand>>
    {


         public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }
    internal class AddEditStructuralItemCommandHandler : IRequestHandler<AddEditStructuralItemCommand, Result<AddEditStructuralItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditStructuralItemCommand> _logger;

        public AddEditStructuralItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditStructuralItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditStructuralItemCommand>> Handle(AddEditStructuralItemCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<StructuralItem>(command);

                _unitOfWork.Repository<StructuralItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditStructuralItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(StructuralItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<StructuralItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditStructuralItemCommand), typeof(StructuralItem));

                    _unitOfWork.Repository<StructuralItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditStructuralItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(StructuralItem)}");
                }
                else
                {
                    return await Result<AddEditStructuralItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditStructuralItemCommandValidator : AbstractValidator<AddEditStructuralItemCommand>
    {
        public AddEditStructuralItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
