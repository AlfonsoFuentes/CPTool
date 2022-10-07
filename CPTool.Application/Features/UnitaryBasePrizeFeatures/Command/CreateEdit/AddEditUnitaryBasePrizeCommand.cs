





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.UnitaryBasePrizeFeatures.Command.CreateEdit
{
    public class AddEditUnitaryBasePrizeCommand : AddEditCommand, IRequest<Result<AddEditUnitaryBasePrizeCommand>>
    {


        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } =new();
    }
    internal class AddEditUnitaryBasePrizeCommandHandler : IRequestHandler<AddEditUnitaryBasePrizeCommand, Result<AddEditUnitaryBasePrizeCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditUnitaryBasePrizeCommand> _logger;

        public AddEditUnitaryBasePrizeCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditUnitaryBasePrizeCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditUnitaryBasePrizeCommand>> Handle(AddEditUnitaryBasePrizeCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<UnitaryBasePrize>(command);

                _unitOfWork.Repository<UnitaryBasePrize>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditUnitaryBasePrizeCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(UnitaryBasePrize)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<UnitaryBasePrize>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditUnitaryBasePrizeCommand), typeof(UnitaryBasePrize));

                    _unitOfWork.Repository<UnitaryBasePrize>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditUnitaryBasePrizeCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(UnitaryBasePrize)}");
                }
                else
                {
                    return await Result<AddEditUnitaryBasePrizeCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditUnitaryBasePrizeCommandValidator : AbstractValidator<AddEditUnitaryBasePrizeCommand>
    {
        public AddEditUnitaryBasePrizeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
