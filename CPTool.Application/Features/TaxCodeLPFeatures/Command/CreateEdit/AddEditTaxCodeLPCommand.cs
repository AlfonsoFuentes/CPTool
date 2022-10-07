

using CPTool.Application.Features.SupplierFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.TaxCodeLPFeatures.Command.CreateEdit
{
    public class AddEditTaxCodeLPCommand : AddEditCommand, IRequest<Result<AddEditTaxCodeLPCommand>>
    {

        public List<AddEditSupplierCommand> SuppliersCommand { get; set; } = new();

    }
    internal class AddEditTaxCodeLPCommandHandler : IRequestHandler<AddEditTaxCodeLPCommand, Result<AddEditTaxCodeLPCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditTaxCodeLPCommand> _logger;

        public AddEditTaxCodeLPCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditTaxCodeLPCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditTaxCodeLPCommand>> Handle(AddEditTaxCodeLPCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<TaxCodeLP>(command);

                _unitOfWork.Repository<TaxCodeLP>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditTaxCodeLPCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(TaxCodeLP)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<TaxCodeLP>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditTaxCodeLPCommand), typeof(TaxCodeLP));

                    _unitOfWork.Repository<TaxCodeLP>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditTaxCodeLPCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(TaxCodeLP)}");
                }
                else
                {
                    return await Result<AddEditTaxCodeLPCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditTaxCodeLPCommandValidator : AbstractValidator<AddEditTaxCodeLPCommand>
    {
        public AddEditTaxCodeLPCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(6).WithMessage("Max 6 characters");

          

        }
    }
}
