





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.Command.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.Command.CreateEdit;
using CPTool.Application.Features.UnitFeatures.Command.CreateEdit;
using CPTool.UnitsSystem;

namespace CPTool.Application.Features.PipeAccesoryFeatures.Command.CreateEdit
{
    public class AddEditPipeAccesoryCommand : AddEditCommand, IRequest<Result<AddEditPipeAccesoryCommand>>
    {
        public int? PipingItemId => PipingItemCommand == null ? null : PipingItemCommand?.Id;
        public AddEditPipingItemCommand? PipingItemCommand { get; set; } = new();
        public int? ProcessConditionId => ProcessConditionCommand == null ? null : ProcessConditionCommand?.Id;
        public AddEditProcessConditionCommand? ProcessConditionCommand { get; set; } = new();

        public int? ProcessFluidId => ProcessFluidCommand == null ? null : ProcessFluidCommand?.Id;
        public AddEditProcessFluidCommand? ProcessFluidCommand { get; set; } = null;
        public int? FrictionId => FrictionCommand == null ? null : FrictionCommand?.Id;
        public AddEditUnitCommand? FrictionCommand { get; set; } = new();
        public int? ReynoldId => ReynoldCommand == null ? null : ReynoldCommand?.Id;
        public AddEditUnitCommand? ReynoldCommand { get; set; } = new();
        public int? LevelInletId => LevelInletCommand == null ? null : LevelInletCommand?.Id;
        public AddEditUnitCommand? LevelInletCommand { get; set; } = new(LengthUnits.MilliMeter);
        public int? LevelOutletId => LevelOutletCommand == null ? null : LevelOutletCommand?.Id;
        public AddEditUnitCommand? LevelOutletCommand { get; set; } = new(LengthUnits.MilliMeter);
        public int? FrictionDropPressureId => FrictionDropPressureCommand == null ? null : FrictionDropPressureCommand?.Id;
        public AddEditUnitCommand? FrictionDropPressureCommand { get; set; } = new(PressureDropUnits.psi);
        public int? OverallDropPressureId => OverallDropPressureCommand == null ? null : OverallDropPressureCommand?.Id;
        public AddEditUnitCommand? OverallDropPressureCommand { get; set; } = new(PressureDropUnits.psi);
        public int? ElevationChangeId => ElevationChangeCommand == null ? null : ElevationChangeCommand?.Id;
        public AddEditUnitCommand? ElevationChangeCommand { get; set; } = new(PressureDropUnits.psi);


        public FlowDirection FlowDirection { get; set; }
        public PipeAccesorySectionType SectionType { get; set; }

        public List<AddEditNozzleCommand>? NozzlesCommand { get; set; } = new();

       
    }
    internal class AddEditPipeAccesoryCommandHandler : IRequestHandler<AddEditPipeAccesoryCommand, Result<AddEditPipeAccesoryCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditPipeAccesoryCommand> _logger;

        public AddEditPipeAccesoryCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditPipeAccesoryCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditPipeAccesoryCommand>> Handle(AddEditPipeAccesoryCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<PipeAccesory>(command);

                _unitOfWork.Repository<PipeAccesory>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditPipeAccesoryCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(PipeAccesory)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<PipeAccesory>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditPipeAccesoryCommand), typeof(PipeAccesory));

                    _unitOfWork.Repository<PipeAccesory>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditPipeAccesoryCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(PipeAccesory)}");
                }
                else
                {
                    return await Result<AddEditPipeAccesoryCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditPipeAccesoryCommandValidator : AbstractValidator<AddEditPipeAccesoryCommand>
    {
        public AddEditPipeAccesoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
