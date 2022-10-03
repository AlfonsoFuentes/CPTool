





namespace CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit
{
    public class AddEditMWOItemCommand : AddEditCommand, IRequest<Result<AddEditMWOItemCommand>>
    {


      
    }
    internal class AddEditMWOItemCommandHandler : IRequestHandler<AddEditMWOItemCommand, Result<AddEditMWOItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditMWOItemCommand> _logger;

        public AddEditMWOItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditMWOItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditMWOItemCommand>> Handle(AddEditMWOItemCommand command, CancellationToken cancellationToken)
        {
            command.Name = command.Name.ToUpper();

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<MWOItem>(command);

                _unitOfWork.Repository<MWOItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditMWOItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(MWOItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<MWOItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditMWOItemCommand), typeof(MWOItem));

                    _unitOfWork.Repository<MWOItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditMWOItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(MWOItem)}");
                }
                else
                {
                    return await Result<AddEditMWOItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditMWOItemCommandValidator : AbstractValidator<AddEditMWOItemCommand>
    {
        public AddEditMWOItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
