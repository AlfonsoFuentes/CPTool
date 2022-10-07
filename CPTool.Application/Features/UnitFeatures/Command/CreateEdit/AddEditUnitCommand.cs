





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.Command.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.Command.CreateEdit;
using CPTool.UnitsSystem;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTool.Application.Features.UnitFeatures.Command.CreateEdit
{
    public class AddEditUnitCommand : AddEditCommand, IRequest<Result<AddEditUnitCommand>>
    {
        public AddEditUnitCommand()
        {
            Amount = new UnitLess(UnitLessUnits.None);
        }
        public AddEditUnitCommand(CPTool.UnitsSystem.Unit unit)
        {
            Amount = new(unit);
        }
        public string? UnitName
        {
            get
            {
                return Amount!.UnitName;
            }
            set
            {
                Amount!.UnitName = value;
            }
        }
        public double Value
        {
            get
            {
                return Amount!.Value;
            }
            set
            {
                Amount!.SetValue(Amount!.Value, Amount!.UnitName);
            }
        }
        Amount? Amount { get; init; }

       
        public List<AddEditPipeDiameterCommand> ODsCommand { get; set; } = new();
      
        public List<AddEditPipeDiameterCommand> IDsCommand { get; set; } = new();
  
        public List<AddEditPipeDiameterCommand> ThicknesssCommand { get; set; } = new();


       
        public List<AddEditProcessConditionCommand> SpecificCpsCommand { get; set; } = new();
       
        public List<AddEditProcessConditionCommand> ThermalConductivitysCommand { get; set; } = new();

       
        public List<AddEditProcessConditionCommand> SpecificEnthalpysCommand { get; set; } = new();
  
        public List<AddEditProcessConditionCommand> EnthalpyFlowsCommand { get; set; } = new();
       
        public List<AddEditProcessConditionCommand> ViscositysCommand { get; set; } = new();
      
        public List<AddEditProcessConditionCommand> DensitysCommand { get; set; } = new();
       
        public List<AddEditProcessConditionCommand> VolumetricFlowsCommand { get; set; } = new();
      
        public List<AddEditProcessConditionCommand> MassFlowsCommand { get; set; } = new();
       
        public List<AddEditProcessConditionCommand> TemperaturesCommand { get; set; } = new();
       
        public List<AddEditProcessConditionCommand> PressuresCommand { get; set; } = new();
    
        public List<AddEditPipeAccesoryCommand> FrictionPipeAccesorysCommand { get; set; } = new();
      
        public List<AddEditPipeAccesoryCommand> ReynoldPipeAccesorysCommand { get; set; } = new();
       
        public List<AddEditPipeAccesoryCommand> LevelInletPipeAccesorysCommand { get; set; } = new();
       
        public List<AddEditPipeAccesoryCommand> LevelOutletPipeAccesorysCommand { get; set; } = new();
     
        public List<AddEditPipeAccesoryCommand> FrictionDropPressurePipeAccesorysCommand { get; set; } = new();
       
        public List<AddEditPipeAccesoryCommand> OverallDropPressurePipeAccesorysCommand { get; set; } = new();
        
        public List<AddEditPipeAccesoryCommand> ElevationChangePipeAccesorysCommand { get; set; } = new();
    }
    internal class AddEditUnitCommandHandler : IRequestHandler<AddEditUnitCommand, Result<AddEditUnitCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditUnitCommand> _logger;

        public AddEditUnitCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditUnitCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditUnitCommand>> Handle(AddEditUnitCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<CPTool.Domain.Entities.Unit>(command);

                _unitOfWork.Repository<CPTool.Domain.Entities.Unit>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditUnitCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(Unit)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<CPTool.Domain.Entities.Unit>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditUnitCommand), typeof(Unit));

                    _unitOfWork.Repository<CPTool.Domain.Entities.Unit>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditUnitCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(Unit)}");
                }
                else
                {
                    return await Result<AddEditUnitCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditUnitCommandValidator : AbstractValidator<AddEditUnitCommand>
    {
        public AddEditUnitCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
