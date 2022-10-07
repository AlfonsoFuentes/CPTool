





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures.Command.CreateEdit
{
    public class AddEditPurchaseOrderMWOItemCommand : AddEditCommand, IRequest<Result<AddEditPurchaseOrderMWOItemCommand>>
    {
        public int PurchaseOrderId { get; set; }

        public AddEditPurchaseOrderCommand? PurchaseOrderCommand { get; set; }

        public int MWOItemId { get; set; }
        public AddEditMWOItemCommand? MWOItemCommand { get; set; }

    }
    internal class AddEditPurchaseOrderMWOItemCommandHandler : IRequestHandler<AddEditPurchaseOrderMWOItemCommand, Result<AddEditPurchaseOrderMWOItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditPurchaseOrderMWOItemCommand> _logger;

        public AddEditPurchaseOrderMWOItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditPurchaseOrderMWOItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditPurchaseOrderMWOItemCommand>> Handle(AddEditPurchaseOrderMWOItemCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<PurchaseOrderMWOItem>(command);

                _unitOfWork.Repository<PurchaseOrderMWOItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditPurchaseOrderMWOItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(PurchaseOrderMWOItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<PurchaseOrderMWOItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditPurchaseOrderMWOItemCommand), typeof(PurchaseOrderMWOItem));

                    _unitOfWork.Repository<PurchaseOrderMWOItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditPurchaseOrderMWOItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(PurchaseOrderMWOItem)}");
                }
                else
                {
                    return await Result<AddEditPurchaseOrderMWOItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditPurchaseOrderMWOItemCommandValidator : AbstractValidator<AddEditPurchaseOrderMWOItemCommand>
    {
        public AddEditPurchaseOrderMWOItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
