

using CPTool.Application.Features.SupplierFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.TaxCodeLDFeatures.Command.CreateEdit
{
    public class AddEditTaxCodeLDCommand : AddEditCommand, IRequest<Result<AddEditTaxCodeLDCommand>>
    {

        public List<AddEditSupplierCommand> SuppliersCommand { get; set; }= new();

    }
    internal class AddEditTaxCodeLDCommandHandler : IRequestHandler<AddEditTaxCodeLDCommand, Result<AddEditTaxCodeLDCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditTaxCodeLDCommand> _logger;

        public AddEditTaxCodeLDCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditTaxCodeLDCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditTaxCodeLDCommand>> Handle(AddEditTaxCodeLDCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<TaxCodeLD>(command);

                _unitOfWork.Repository<TaxCodeLD>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditTaxCodeLDCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(TaxCodeLD)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<TaxCodeLD>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditTaxCodeLDCommand), typeof(TaxCodeLD));

                    _unitOfWork.Repository<TaxCodeLD>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditTaxCodeLDCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(TaxCodeLD)}");
                }
                else
                {
                    return await Result<AddEditTaxCodeLDCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditTaxCodeLDCommandValidator : AbstractValidator<AddEditTaxCodeLDCommand>
    {
        public AddEditTaxCodeLDCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(6).WithMessage("Max 6 characters");

          

        }
    }
}
