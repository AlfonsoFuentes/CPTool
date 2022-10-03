

using CPTool.Application.Features.BrandSupplierFeatures.Command.CreateEdit;
using CPTool.Application.Features.TaxCodeLDFeatures.Command.CreateEdit;
using CPTool.Application.Features.TaxCodeLPFeatures.Command.CreateEdit;
using CPTool.Application.Features.VendorCodeFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.SupplierFeatures.Command.CreateEdit
{
    public class AddEditSupplierCommand : AddEditCommand, IRequest<Result<AddEditSupplierCommand>>
    {

        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";


        public string Email { get; set; } = "";
        public string ContactPerson { get; set; } = "";

        public List<AddEditBrandSupplierCommand> BrandSuppliers { get; set; } = new();
        public int TaxCodeLPId => TaxCodeLPCommand.Id;
        public AddEditTaxCodeLPCommand TaxCodeLPCommand { get; set; } = new();
        public int VendorCodeId => VendorCodeCommand.Id;
        public AddEditVendorCodeCommand VendorCodeCommand { get; set; } = new();
        public int TaxCodeLDId => TaxCodeLPCommand.Id;
        public AddEditTaxCodeLDCommand TaxCodeLDCommand { get; set; } = new();
    
    }
    internal class AddEditSupplierCommandHandler : IRequestHandler<AddEditSupplierCommand, Result<AddEditSupplierCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditSupplierCommand> _logger;

        public AddEditSupplierCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditSupplierCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditSupplierCommand>> Handle(AddEditSupplierCommand command, CancellationToken cancellationToken)
        {


            if (command.Id == 0)
            {
                var table = _mapper.Map<Supplier>(command);

                _unitOfWork.Repository<Supplier>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
              
                return await Result<AddEditSupplierCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(Supplier)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<Supplier>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditSupplierCommand), typeof(Supplier));

                    _unitOfWork.Repository<Supplier>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditSupplierCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(Supplier)}");
                }
                else
                {
                    return await Result<AddEditSupplierCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditSupplierCommandValidator : AbstractValidator<AddEditSupplierCommand>
    {
        public AddEditSupplierCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 10 characters");

           

        }
    }
}
