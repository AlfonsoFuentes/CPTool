

namespace CPTool.Application.Features.VendorCodeFeatures.Command.CreateEdit
{
    public class AddEditVendorCodeCommand : AddEditCommand, IRequest<Result<AddEditVendorCodeCommand>>
    {


       
    }
    internal class AddEditVendorCodeCommandHandler : IRequestHandler<AddEditVendorCodeCommand, Result<AddEditVendorCodeCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditVendorCodeCommand> _logger;

        public AddEditVendorCodeCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditVendorCodeCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditVendorCodeCommand>> Handle(AddEditVendorCodeCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<VendorCode>(command);

                _unitOfWork.Repository<VendorCode>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditVendorCodeCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(VendorCode)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<VendorCode>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditVendorCodeCommand), typeof(VendorCode));

                    _unitOfWork.Repository<VendorCode>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditVendorCodeCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(VendorCode)}");
                }
                else
                {
                    return await Result<AddEditVendorCodeCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditVendorCodeCommandValidator : AbstractValidator<AddEditVendorCodeCommand>
    {
        public AddEditVendorCodeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(6).WithMessage("Max 6 characters");

          

        }
    }
}
