



using CPTool.Application.Features.MMOFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MMOTypeFeatures.Command.CreateEdit
{
    public class AddEditMWOTypeCommand : AddEditCommand, IRequest<Result<AddEditMWOTypeCommand>>
    {


        public List<AddEditMWOCommand> MWOs { get; set; } =new();
    }
    internal class AddEditMWOTypeCommandHandler : IRequestHandler<AddEditMWOTypeCommand, Result<AddEditMWOTypeCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditMWOTypeCommand> _logger;

        public AddEditMWOTypeCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditMWOTypeCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditMWOTypeCommand>> Handle(AddEditMWOTypeCommand command, CancellationToken cancellationToken)
        {
            command.Name = command.Name.ToUpper();

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<MWOType>(command);

                _unitOfWork.Repository<MWOType>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditMWOTypeCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(MWOType)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<MWOType>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditMWOTypeCommand), typeof(MWOType));

                    _unitOfWork.Repository<MWOType>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditMWOTypeCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(MWOType)}");
                }
                else
                {
                    return await Result<AddEditMWOTypeCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditMWOTypeCommandValidator : AbstractValidator<AddEditMWOTypeCommand>
    {
        public AddEditMWOTypeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
