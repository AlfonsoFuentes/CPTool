





using CPTool.Application.Features.EquipmentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ProcessFluidFeatures.Command.CreateEdit
{
    public class AddEditProcessFluidCommand : AddEditCommand, IRequest<Result<AddEditProcessFluidCommand>>
    {

        public List<AddEditEquipmentItemCommand> EquipmentItemsCommand { get; set; } = new();
        public List<AddEditInstrumentItemCommand> InstrumentItemsCommand { get; set; } = new();
        public List<AddEditPipingItemCommand> PipingItemsCommand { get; set; } = new();
       
    }
    internal class AddEditProcessFluidCommandHandler : IRequestHandler<AddEditProcessFluidCommand, Result<AddEditProcessFluidCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditProcessFluidCommand> _logger;

        public AddEditProcessFluidCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditProcessFluidCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditProcessFluidCommand>> Handle(AddEditProcessFluidCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<ProcessFluid>(command);

                _unitOfWork.Repository<ProcessFluid>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditProcessFluidCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(ProcessFluid)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<ProcessFluid>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditProcessFluidCommand), typeof(ProcessFluid));

                    _unitOfWork.Repository<ProcessFluid>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditProcessFluidCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(ProcessFluid)}");
                }
                else
                {
                    return await Result<AddEditProcessFluidCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditProcessFluidCommandValidator : AbstractValidator<AddEditProcessFluidCommand>
    {
        public AddEditProcessFluidCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
