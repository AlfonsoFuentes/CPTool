





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.TaxesItemFeatures.Command.CreateEdit
{
    public class AddEditTaxesItemCommand : AddEditCommand, IRequest<Result<AddEditTaxesItemCommand>>
    {


         public List<AddEditMWOItemCommand> MWOItemsCommand { get; set; } = new();
    }
    internal class AddEditTaxesItemCommandHandler : IRequestHandler<AddEditTaxesItemCommand, Result<AddEditTaxesItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditTaxesItemCommand> _logger;

        public AddEditTaxesItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditTaxesItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditTaxesItemCommand>> Handle(AddEditTaxesItemCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<TaxesItem>(command);

                _unitOfWork.Repository<TaxesItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditTaxesItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(TaxesItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<TaxesItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditTaxesItemCommand), typeof(TaxesItem));

                    _unitOfWork.Repository<TaxesItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditTaxesItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(TaxesItem)}");
                }
                else
                {
                    return await Result<AddEditTaxesItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditTaxesItemCommandValidator : AbstractValidator<AddEditTaxesItemCommand>
    {
        public AddEditTaxesItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
