





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.EngineeringCostItemFeatures.Command.CreateEdit
{
    public class AddEditEngineeringCostItemCommand : AddEditCommand, IRequest<Result<AddEditEngineeringCostItemCommand>>
    {


         public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }
    internal class AddEditEngineeringCostItemCommandHandler : IRequestHandler<AddEditEngineeringCostItemCommand, Result<AddEditEngineeringCostItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditEngineeringCostItemCommand> _logger;

        public AddEditEngineeringCostItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditEngineeringCostItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditEngineeringCostItemCommand>> Handle(AddEditEngineeringCostItemCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<EngineeringCostItem>(command);

                _unitOfWork.Repository<EngineeringCostItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditEngineeringCostItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(EngineeringCostItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<EngineeringCostItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditEngineeringCostItemCommand), typeof(EngineeringCostItem));

                    _unitOfWork.Repository<EngineeringCostItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditEngineeringCostItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(EngineeringCostItem)}");
                }
                else
                {
                    return await Result<AddEditEngineeringCostItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditEngineeringCostItemCommandValidator : AbstractValidator<AddEditEngineeringCostItemCommand>
    {
        public AddEditEngineeringCostItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
