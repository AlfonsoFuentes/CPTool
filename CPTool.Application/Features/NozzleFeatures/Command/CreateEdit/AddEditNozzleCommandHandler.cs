

using CPTool.Application.Features.ConnectionTypeFeatures.Command.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.GasketsFeatures.Command.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.Command.CreateEdit;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTool.Application.Features.NozzleFeatures.Command.CreateEdit
{
    public class AddEditNozzleCommand : AddEditCommand, IRequest<Result<AddEditNozzleCommand>>
    {

       
        public List<AddEditPipingItemCommand>? StartPipingItemsCommand { get; set; } = new();
      
        public List<AddEditPipingItemCommand>? FinishPipingItemsCommand { get; set; } = new();

        public int? PipeClassId => PipeClassCommand == null ? null : PipeClassCommand?.Id;
        public AddEditPipeClassCommand? PipeClassCommand { get; set; }

        public int? PipeDiameterId => PipeDiameterCommand == null ? null : PipeDiameterCommand?.Id;
        public AddEditPipeDiameterCommand? PipeDiameterCommand { get; set; }
        public int? ConnectionTypeId => ConnectionTypeCommand == null ? null : ConnectionTypeCommand?.Id;
        public AddEditConnectionTypeCommand? ConnectionTypeCommand { get; set; }
        public int? GasketId => GasketCommand == null ? null : GasketCommand?.Id;
        public AddEditGasketCommand? GasketCommand { get; set; }
        public int? MaterialID => MaterialCommand == null ? null : MaterialCommand?.Id;
        public AddEditMaterialCommand? MaterialCommand { get; set; }

        public StreamType StreamType { get; set; }

        public AddEditPipeAccesoryCommand? PipeAccesoryCommand { get; set; }
        public int? PipeAccesoryId => PipeAccesoryCommand == null ? null : PipeAccesoryCommand?.Id;

        public int? EquipmentItemId => EquipmentItemCommand == null ? null : EquipmentItemCommand?.Id;
        public AddEditEquipmentItemCommand? EquipmentItemCommand { get; set; }
        public int? InstrumentItemId => InstrumentItemCommand == null ? null : InstrumentItemCommand?.Id;
        public AddEditInstrumentItemCommand? InstrumentItemCommand { get; set; }

        public int? PipingItemId => PipingItemCommand == null ? null : PipingItemCommand?.Id;
        public AddEditPipingItemCommand PipingItemCommand { get; set; } = null!;
    }
    internal class AddEditNozzleCommandHandler : IRequestHandler<AddEditNozzleCommand, Result<AddEditNozzleCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditNozzleCommand> _logger;

        public AddEditNozzleCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditNozzleCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditNozzleCommand>> Handle(AddEditNozzleCommand command, CancellationToken cancellationToken)
        {
            command.Name = command.Name.ToUpper();

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<Nozzle>(command);

                _unitOfWork.Repository<Nozzle>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditNozzleCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(Nozzle)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<Nozzle>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditNozzleCommand), typeof(Nozzle));

                    _unitOfWork.Repository<Nozzle>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditNozzleCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(Nozzle)}");
                }
                else
                {
                    return await Result<AddEditNozzleCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditNozzleCommandValidator : AbstractValidator<AddEditNozzleCommand>
    {
        public AddEditNozzleCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
