





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ElectricalItemFeatures.Command.CreateEdit
{
    public class AddEditElectricalItemCommand : AddEditCommand, IRequest<Result<AddEditElectricalItemCommand>>
    {

        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
       
    }
    internal class AddEditElectricalItemCommandHandler : IRequestHandler<AddEditElectricalItemCommand, Result<AddEditElectricalItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditElectricalItemCommand> _logger;

        public AddEditElectricalItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditElectricalItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditElectricalItemCommand>> Handle(AddEditElectricalItemCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<ElectricalItem>(command);

                _unitOfWork.Repository<ElectricalItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditElectricalItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(ElectricalItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<ElectricalItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditElectricalItemCommand), typeof(ElectricalItem));

                    _unitOfWork.Repository<ElectricalItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditElectricalItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(ElectricalItem)}");
                }
                else
                {
                    return await Result<AddEditElectricalItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditElectricalItemCommandValidator : AbstractValidator<AddEditElectricalItemCommand>
    {
        public AddEditElectricalItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
