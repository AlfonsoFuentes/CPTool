





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.AlterationItemFeatures.Command.CreateEdit
{
    public class AddEditAlterationItemCommand : AddEditCommand, IRequest<Result<AddEditAlterationItemCommand>>
    {

        public string CostCenter { get; set; } = null!;
        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } =new();
    }
    internal class AddEditAlterationItemCommandHandler : IRequestHandler<AddEditAlterationItemCommand, Result<AddEditAlterationItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditAlterationItemCommand> _logger;

        public AddEditAlterationItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditAlterationItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditAlterationItemCommand>> Handle(AddEditAlterationItemCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<AlterationItem>(command);

                _unitOfWork.Repository<AlterationItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditAlterationItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(AlterationItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<AlterationItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditAlterationItemCommand), typeof(AlterationItem));

                    _unitOfWork.Repository<AlterationItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditAlterationItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(AlterationItem)}");
                }
                else
                {
                    return await Result<AddEditAlterationItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditAlterationItemCommandValidator : AbstractValidator<AddEditAlterationItemCommand>
    {
        public AddEditAlterationItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
