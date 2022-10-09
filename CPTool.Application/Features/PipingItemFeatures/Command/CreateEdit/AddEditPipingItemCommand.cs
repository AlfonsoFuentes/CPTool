





using CPTool.Application.Features.MaterialFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.Command.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PipingItemFeatures.Command.CreateEdit
{
    public class AddEditPipingItemCommand : AddEditCommand, IRequest<Result<AddEditPipingItemCommand>>
    {
        public List<AddEditNozzleCommand>? NozzlesCommand { get; set; } =new();
        public List<AddEditMWOItemCommand>? MWOItemsCommand { get; set; } = new();
        public List<AddEditPipeAccesoryCommand>? PipeAccesorysCommand { get; set; } = new();
        public int? MaterialId => MaterialCommand == null ? null : MaterialCommand.Id;
        public AddEditMaterialCommand? MaterialCommand { get; set; }
        public int? ProcessFluidId => ProcessFluidCommand == null ? null : ProcessFluidCommand.Id;
        public AddEditProcessFluidCommand? ProcessFluidCommand { get; set; }
        public int? DiameterId => DiameterCommand == null ? null : DiameterCommand.Id;
        public AddEditPipeDiameterCommand? DiameterCommand { get; set; }
        public int? NozzleStartId => NozzleStartCommand == null ? null : NozzleStartCommand.Id;
        public AddEditNozzleCommand? NozzleStartCommand { get; set; }
        public int? NozzleFinishId => NozzleFinishCommand == null ? null : NozzleFinishCommand.Id;
        public AddEditNozzleCommand? NozzleFinishCommand { get; set; }
        public int? StartMWOItemId => StartMWOItemCommand == null ? null : StartMWOItemCommand.Id;
        public AddEditMWOItemCommand? StartMWOItemCommand { get; set; }
        public int? FinishMWOItemId => FinishMWOItemCommand == null ? null : FinishMWOItemCommand.Id;
        public AddEditMWOItemCommand? FinishMWOItemCommand { get; set; }
        public int? PipeClassId => PipeClassCommand == null ? null : PipeClassCommand.Id;
        public AddEditPipeClassCommand? PipeClassCommand { get; set; }
        public string TagId { get; set; } = String.Empty;
        public bool Insulation { get; set; }

     
    }
    internal class AddEditPipingItemCommandHandler : IRequestHandler<AddEditPipingItemCommand, Result<AddEditPipingItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditPipingItemCommand> _logger;

        public AddEditPipingItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditPipingItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditPipingItemCommand>> Handle(AddEditPipingItemCommand command, CancellationToken cancellationToken)
        {
          

            if (command.Id == 0)
            {
                
                var table = _mapper.Map<PipingItem>(command);

                _unitOfWork.Repository<PipingItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditPipingItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(PipingItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<PipingItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditPipingItemCommand), typeof(PipingItem));

                    _unitOfWork.Repository<PipingItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditPipingItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(PipingItem)}");
                }
                else
                {
                    return await Result<AddEditPipingItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditPipingItemCommandValidator : AbstractValidator<AddEditPipingItemCommand>
    {
        public AddEditPipingItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
