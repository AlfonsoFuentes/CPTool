

using CPTool.Application.Features.EquipmentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.GasketsFeatures.Command.CreateEdit
{
    public class AddEditGasketCommand : AddEditCommand, IRequest<Result<AddEditGasketCommand>>
    {

        public List<AddEditNozzleCommand>? NozzlesCommand { get; set; } = new();

        public List<AddEditEquipmentItemCommand>? EquipmentItemsCommand { get; set; } = new();
        public List<AddEditInstrumentItemCommand>? InstrumentItemsCommand { get; set; } = new();

    }
    internal class AddEditGasketCommandHandler : IRequestHandler<AddEditGasketCommand, Result<AddEditGasketCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditGasketCommand> _logger;

        public AddEditGasketCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditGasketCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditGasketCommand>> Handle(AddEditGasketCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<Gasket>(command);

                _unitOfWork.Repository<Gasket>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditGasketCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(Gasket)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<Gasket>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditGasketCommand), typeof(Gasket));

                    _unitOfWork.Repository<Gasket>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditGasketCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(Gasket)}");
                }
                else
                {
                    return await Result<AddEditGasketCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditGasketCommandValidator : AbstractValidator<AddEditGasketCommand>
    {
        public AddEditGasketCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(6).WithMessage("Max 6 characters");

          

        }
    }
}
