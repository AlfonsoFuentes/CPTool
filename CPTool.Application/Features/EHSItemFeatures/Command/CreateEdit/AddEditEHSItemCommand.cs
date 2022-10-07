





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.EHSItemFeatures.Command.CreateEdit
{
    public class AddEditEHSItemCommand : AddEditCommand, IRequest<Result<AddEditEHSItemCommand>>
    {


        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }
    internal class AddEditEHSItemCommandHandler : IRequestHandler<AddEditEHSItemCommand, Result<AddEditEHSItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditEHSItemCommand> _logger;

        public AddEditEHSItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditEHSItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditEHSItemCommand>> Handle(AddEditEHSItemCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<EHSItem>(command);

                _unitOfWork.Repository<EHSItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditEHSItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(EHSItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<EHSItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditEHSItemCommand), typeof(EHSItem));

                    _unitOfWork.Repository<EHSItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditEHSItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(EHSItem)}");
                }
                else
                {
                    return await Result<AddEditEHSItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditEHSItemCommandValidator : AbstractValidator<AddEditEHSItemCommand>
    {
        public AddEditEHSItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
