

using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MWOFeatures.Command.CreateEdit
{
    public class AddEditMWOCommand : AddEditCommand, IRequest<Result<AddEditMWOCommand>>
    {

        public int Number { get; set; }
        public string? ProjectLeader { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string? CEBName => $"CEB0000{Number}";
        public string? CECName => $"CEC0000{Number}";
        public decimal Budget { get; set; }
        public decimal Expenses { get; set; }

        public int MWOTypeId => MWOTypeCommand.Id;
        public AddEditMWOTypeCommand MWOTypeCommand { get; set; } = null!;

        public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
        public List<AddEditPurchaseOrderCommand> PurchaseOrdersCommand { get; set; } = new();

      

    }
    internal class AddEditMWOCommandHandler : IRequestHandler<AddEditMWOCommand, Result<AddEditMWOCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditMWOCommand> _logger;

        public AddEditMWOCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditMWOCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditMWOCommand>> Handle(AddEditMWOCommand command, CancellationToken cancellationToken)
        {


            if (command.Id == 0)
            {

                var table = _mapper.Map<MWO>(command);

                _unitOfWork.Repository<MWO>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditMWOCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(MWO)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<MWO>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditMWOCommand), typeof(MWO));

                    _unitOfWork.Repository<MWO>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditMWOCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(MWO)}");
                }
                else
                {
                    return await Result<AddEditMWOCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditMWOCommandValidator : AbstractValidator<AddEditMWOCommand>
    {
        public AddEditMWOCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(6).WithMessage("Max 6 characters");



        }
    }
}
