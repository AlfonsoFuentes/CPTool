





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.DownPaymentFeatures.Command.CreateEdit
{
    public class AddEditDownPaymentCommand : AddEditCommand, IRequest<Result<AddEditDownPaymentCommand>>
    {
        public int PurchaseOrderId => PurchaseOrderCommand.Id;
        public AddEditPurchaseOrderCommand PurchaseOrderCommand { get => (Parent as AddEditPurchaseOrderCommand)!; set => Parent = value; }
        public DateTime? RequestDate { get; set; }
        public string? ManagerEmail { get; set; }
        public string? CBSRequesText { get; set; }
        public string? CBSRequesNo { get; set; }
        public string? ProformaInvoice { get; set; }
        public DownpaymentStatus DownpaymentStatus { get; set; }
        public string? Payterms { get; set; }
        public DateTime? DownPaymentDueDate { get; set; }
        public DateTime? DeliveryDueDate { get; set; }
        public DateTime? RealDate { get; set; }
        public double Percentage { get; set; }
        public double DownPaymentAmount { get; set; }
        public string? DownpaymentDescrption { get; set; }
        public string? Incotherm { get; set; }
        public DateTime? ApprovedDate { get; set; }

      
    }
    internal class AddEditDownPaymentCommandHandler : IRequestHandler<AddEditDownPaymentCommand, Result<AddEditDownPaymentCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditDownPaymentCommand> _logger;

        public AddEditDownPaymentCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditDownPaymentCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditDownPaymentCommand>> Handle(AddEditDownPaymentCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<DownPayment>(command);

                _unitOfWork.Repository<DownPayment>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditDownPaymentCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(DownPayment)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<DownPayment>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditDownPaymentCommand), typeof(DownPayment));

                    _unitOfWork.Repository<DownPayment>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditDownPaymentCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(DownPayment)}");
                }
                else
                {
                    return await Result<AddEditDownPaymentCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditDownPaymentCommandValidator : AbstractValidator<AddEditDownPaymentCommand>
    {
        public AddEditDownPaymentCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
