

using CPTool.Application.Contracts.Persistence;
using CPTool.Application.Features.BrandFeatures.Command.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.BrandSupplierFeatures.Command.CreateEdit
{
    public enum InletBy
    {
        None,
        Brand,
        Supplier
    }
    public class AddEditBrandSupplierCommand : AddEditCommand, IRequest<Result<AddEditBrandSupplierCommand>>
    {

        public InletBy InletBy { get; set; } = InletBy.None;
        public int BrandId => BrandCommand.Id;
        public AddEditBrandCommand BrandCommand{ get; set; } = new();

        public int SupplierId => SupplierCommand.Id;
        public AddEditSupplierCommand SupplierCommand { get; set; } = new();
        public override void CreateMasterRelations(AddEditCommand Master1, AddEditCommand Master2)
        {
            BrandCommand = (Master1 as AddEditBrandCommand)!;
            SupplierCommand = (Master2 as AddEditSupplierCommand)!;
        }

    }
    internal class AddEditBrandSupplierCommandHandler : IRequestHandler<AddEditBrandSupplierCommand, Result<AddEditBrandSupplierCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditBrandSupplierCommand> _logger;

        public AddEditBrandSupplierCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditBrandSupplierCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditBrandSupplierCommand>> Handle(AddEditBrandSupplierCommand command, CancellationToken cancellationToken)
        {
            if (command.InletBy == InletBy.Brand)
            {
                var result = await SolveBrand(command.BrandCommand);
               

            }
            else if (command.InletBy == InletBy.Supplier)
            {
                var result = await SolveSupplier(command.SupplierCommand);
               
            }
            if(command.BrandId!=0&&command.SupplierId!=0)
            {
                var exist = await _unitOfWork.Repository<BrandSupplier>().GetAsync(x => x.BrandId == command.BrandCommand.Id && x.SupplierId == command.SupplierCommand.Id);

                if (!(exist.Count > 0))
                {
                    var table = _mapper.Map<BrandSupplier>(command);

                    _unitOfWork.Repository<BrandSupplier>().Add(table);
                    await _unitOfWork.Complete();
                    command.Id = table.Id;

                    return await Result<AddEditBrandSupplierCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(BrandSupplier)}");
                }
            }
            
            
            return await Result<AddEditBrandSupplierCommand>.SuccessAsync(command, $"Updated in {nameof(BrandSupplier)}");
        }

        async Task<Result<AddEditBrandCommand>> SolveBrand(AddEditBrandCommand command)
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
        async Task<Result<AddEditSupplierCommand>> SolveSupplier(AddEditSupplierCommand command)
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
    public class AddEditBrandSupplierCommandValidator : AbstractValidator<AddEditBrandSupplierCommand>
    {
        public AddEditBrandSupplierCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 10 characters");

           

        }
    }
}
