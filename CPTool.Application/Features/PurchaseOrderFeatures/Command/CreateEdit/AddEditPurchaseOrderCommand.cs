

using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderFeatures.Command.CreateEdit
{
    public class AddEditPurchaseOrderCommand : AddEditCommand, IRequest<Result<AddEditPurchaseOrderCommand>>
    {

        public string PurchaseRequisition { get; set; } = "";

        public DateTime POCreatedDate { get; set; }
        public DateTime POReceivedDate { get; set; }
        public DateTime POInstalledDate { get; set; }
        public DateTime POEstimatedDate { get; set; }
        public DateTime POOrderingdDate { get; set; }
        public string PONumber { get; set; } = "";
        public string SPL { get; set; } = "";
        public string TaxCode { get; set; } = "";

        public Currency Currency { get; set; } = Currency.COP;
        public double PrizeCurrency { get; set; }
        public double PrizeUSD { get; set; }
        public double USDCOP { get; set; }
        public double USDEUR { get; set; }

        public double Tax { get; set; }
        public double PrizeCurrencyTax { get; set; }
        public double TotalPrizeCurrency { get; set; }
        public int MWOId => MWOCommand.Id;
        public AddEditMWOCommand MWOCommand { get; set; } = new();
    }
    internal class AddEditPurchaseOrderCommandHandler : IRequestHandler<AddEditPurchaseOrderCommand, Result<AddEditPurchaseOrderCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditPurchaseOrderCommand> _logger;

        public AddEditPurchaseOrderCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditPurchaseOrderCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditPurchaseOrderCommand>> Handle(AddEditPurchaseOrderCommand command, CancellationToken cancellationToken)
        {
            command.Name = command.Name.ToUpper();

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<PurchaseOrder>(command);

                _unitOfWork.Repository<PurchaseOrder>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditPurchaseOrderCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(PurchaseOrder)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<PurchaseOrder>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditPurchaseOrderCommand), typeof(PurchaseOrder));

                    _unitOfWork.Repository<PurchaseOrder>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditPurchaseOrderCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(PurchaseOrder)}");
                }
                else
                {
                    return await Result<AddEditPurchaseOrderCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditPurchaseOrderCommandValidator : AbstractValidator<AddEditPurchaseOrderCommand>
    {
        public AddEditPurchaseOrderCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
