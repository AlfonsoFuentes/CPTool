





using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.UnitFeatures.Command.CreateEdit;
using CPTool.UnitsSystem;

namespace CPTool.Application.Features.PipeDiameterFeatures.Command.CreateEdit
{
    public class AddEditPipeDiameterCommand : AddEditCommand, IRequest<Result<AddEditPipeDiameterCommand>>,IDisposable
    {
        public AddEditPipeDiameterCommand()
        {
            
            ODCommand.Amount!.OnValueChanged += CalculateInternalDiameter;
            ThicknessCommand.Amount!.OnValueChanged += CalculateInternalDiameter;
            ODCommand.Name = "Outer Diameter";
            IDCommand.Name = "Inner Diameter";
            ThicknessCommand.Name = "Thickness";
        }
        public List<AddEditPipingItemCommand>? PipingItemsCommandCommand { get; set; } = null!;
        public List<AddEditNozzleCommand>? NozzlesCommandCommand { get; set; } = null!;
        public int? ODId => ODCommand.Id == 0 ? null : ODCommand.Id;
        public AddEditUnitCommand ODCommand { get; set; } = new(LengthUnits.Inch);
        public int? IDId => IDCommand.Id == 0 ? null : IDCommand.Id;
        public AddEditUnitCommand IDCommand { get; set; } = new(LengthUnits.Inch);


        public int? ThicknessId => ThicknessCommand.Id == 0 ? null : ThicknessCommand.Id;
        public AddEditUnitCommand ThicknessCommand { get; set; } = new(LengthUnits.Inch);

        public int? PipeClassId => PipeClassCommand?.Id == 0 ? null : PipeClassCommand?.Id;
        public AddEditPipeClassCommand? PipeClassCommand { get; set; } = new();

        void CalculateInternalDiameter()
        {
            IDCommand.Amount = ODCommand.Amount - 2 * ThicknessCommand.Amount;
        }

        public void Dispose()
        {
            ODCommand.Amount!.OnValueChanged -= CalculateInternalDiameter;
            ThicknessCommand.Amount!.OnValueChanged -= CalculateInternalDiameter;
        }
    }
    internal class AddEditPipeDiameterCommandHandler : IRequestHandler<AddEditPipeDiameterCommand, Result<AddEditPipeDiameterCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditPipeDiameterCommand> _logger;

        public AddEditPipeDiameterCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditPipeDiameterCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditPipeDiameterCommand>> Handle(AddEditPipeDiameterCommand command, CancellationToken cancellationToken)
        {


            if (command.Id == 0)
            {
                try
                {
                    var table = _mapper.Map<PipeDiameter>(command);

                    _unitOfWork.Repository<PipeDiameter>().Add(table);
                    await _unitOfWork.Complete();
                    command.Id = table.Id;
                    return await Result<AddEditPipeDiameterCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(PipeDiameter)}");
                }
                catch(Exception ex)
                {
                    string exm = ex.Message;
                    return await Result<AddEditPipeDiameterCommand>.FailAsync(exm);
                }

                
            }
            else
            {
                var table = await _unitOfWork.Repository<PipeDiameter>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditPipeDiameterCommand), typeof(PipeDiameter));

                    _unitOfWork.Repository<PipeDiameter>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditPipeDiameterCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(PipeDiameter)}");
                }
                else
                {
                    return await Result<AddEditPipeDiameterCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditPipeDiameterCommandValidator : AbstractValidator<AddEditPipeDiameterCommand>
    {
        public AddEditPipeDiameterCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");



        }
    }
}
