

using CPTool.Application.Features.BrandSupplierFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.BrandFeatures.Command.CreateEdit
{
    public class AddEditBrandCommand : AddEditCommand, IRequest<Result<AddEditBrandCommand>>
    {
        public List<AddEditBrandSupplierCommand> BrandSuppliers { get; set; } = new();
        public BrandType BrandType { get; set; }

    }
    internal class AddEditBrandCommandHandler : IRequestHandler<AddEditBrandCommand, Result<AddEditBrandCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditBrandCommand> _logger;

        public AddEditBrandCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditBrandCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditBrandCommand>> Handle(AddEditBrandCommand command, CancellationToken cancellationToken)
        {


            if (command.Id == 0)
            {
                var table = _mapper.Map<Brand>(command);

                _unitOfWork.Repository<Brand>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
              
                return await Result<AddEditBrandCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(Brand)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<Brand>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditBrandCommand), typeof(Brand));

                    _unitOfWork.Repository<Brand>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditBrandCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(Brand)}");
                }
                else
                {
                    return await Result<AddEditBrandCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditBrandCommandValidator : AbstractValidator<AddEditBrandCommand>
    {
        public AddEditBrandCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 10 characters");

           
        }
    }
}
