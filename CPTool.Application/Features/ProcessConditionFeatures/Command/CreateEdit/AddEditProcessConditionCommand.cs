





using CPTool.Application.Features.EquipmentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.Command.CreateEdit;
using CPTool.Application.Features.UnitFeatures.Command.CreateEdit;
using CPTool.UnitsSystem;

namespace CPTool.Application.Features.ProcessConditionFeatures.Command.CreateEdit
{
    public class AddEditProcessConditionCommand : AddEditCommand, IRequest<Result<AddEditProcessConditionCommand>>
    {
        public List<AddEditPipeAccesoryCommand> PipeAccesorysCommand { get; set; } = new();
        public List<AddEditEquipmentItemCommand> EquipmentItemsCommand { get; set; } = new();
        public List<AddEditInstrumentItemCommand> InstrumentItemsCommand { get; set; } = new();
        public int? PressureId => PressureCommand.Id;
        public AddEditUnitCommand PressureCommand { get; set; } = new(PressureUnits.Bar);
        public int? TemperatureId => TemperatureCommand.Id;
        public AddEditUnitCommand TemperatureCommand { get; set; } = new(TemperatureUnits.DegreeCelcius);
        public int? MassFlowId => MassFlowCommand.Id;
        public AddEditUnitCommand MassFlowCommand { get; set; } = new(MassFlowUnits.Kg_hr);
        public int? VolumetricFlowId => VolumetricFlowCommand.Id;
        public AddEditUnitCommand VolumetricFlowCommand { get; set; } = new(VolumetricFlowUnits.m3_hr);
        public int? DensityId => DensityCommand.Id;
        public AddEditUnitCommand DensityCommand { get; set; } = new(MassDensityUnits.Kg_m3);
        public int? ViscosityId => ViscosityCommand.Id;
        public AddEditUnitCommand ViscosityCommand { get; set; }=new(ViscosityUnits.cPoise);
        public int? EnthalpyFlowId => EnthalpyFlowCommand.Id;
        public AddEditUnitCommand EnthalpyFlowCommand { get; set; }=new(EnergyFlowUnits.Kcal_hr);
        public int? SpecificEnthalpyId => SpecificEnthalpyCommand.Id;
        public AddEditUnitCommand SpecificEnthalpyCommand { get; set; } = new(MassEnergyUnits.Kcal_Kg);
        public int? ThermalConductivityId => ThermalConductivityCommand.Id;
        public AddEditUnitCommand ThermalConductivityCommand { get; set; } = new(ThermalConductivityUnits.kW_m_K);
        public int? SpecificCpId =>SpecificCpCommand.Id;
        public AddEditUnitCommand SpecificCpCommand { get; set; }=new(MassEntropyUnits.Kcal_Kg_C);

   
    }
    internal class AddEditProcessConditionCommandHandler : IRequestHandler<AddEditProcessConditionCommand, Result<AddEditProcessConditionCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditProcessConditionCommand> _logger;

        public AddEditProcessConditionCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditProcessConditionCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditProcessConditionCommand>> Handle(AddEditProcessConditionCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<ProcessCondition>(command);

                _unitOfWork.Repository<ProcessCondition>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditProcessConditionCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(ProcessCondition)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<ProcessCondition>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditProcessConditionCommand), typeof(ProcessCondition));

                    _unitOfWork.Repository<ProcessCondition>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditProcessConditionCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(ProcessCondition)}");
                }
                else
                {
                    return await Result<AddEditProcessConditionCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditProcessConditionCommandValidator : AbstractValidator<AddEditProcessConditionCommand>
    {
        public AddEditProcessConditionCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
