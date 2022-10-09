





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
                if (Amount == null)
                {
                    Amount = new(value);
                }
                if (value != Amount!.UnitName)
                {
                    Amount!.UnitName = value;
                }
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
                Amount!.SetValue(value, Amount!.Unit);
            }
        }
        public Amount? Amount { get; set; }
        public List<CPTool.UnitsSystem.Unit> UnitsList=>Amount!.UnitsList;


        public string StringValue => $"{Value} {UnitName}";
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
