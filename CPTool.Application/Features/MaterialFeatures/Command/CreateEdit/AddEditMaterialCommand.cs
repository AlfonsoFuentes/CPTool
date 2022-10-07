

using CPTool.Application.Features.EquipmentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.Command.CreateEdit;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTool.Application.Features.MaterialFeatures.Command.CreateEdit
{
    public class AddEditMaterialCommand : AddEditCommand, IRequest<Result<AddEditMaterialCommand>>
    {
        public string? Abbreviation { get; set; }

        
        public List<AddEditInstrumentItemCommand> InstrumentItemInnerMaterialsCommand { get; set; } = new();

   
        public List<AddEditInstrumentItemCommand> InstrumentItemOuterMaterialsCommand { get; set; } = new();

  
        public List<AddEditEquipmentItemCommand> EquipmentItemInnerMaterialsCommand { get; set; } = new();

  
        public List<AddEditEquipmentItemCommand> EquipmentItemOuterMaterialsCommand { get; set; } = new();

        public List<AddEditPipingItemCommand> PipingItemsCommand { get; set; } = new();

        public List<AddEditNozzleCommand> NozzlesCommand { get; set; } = new();
    

    }
    internal class AddEditMaterialCommandHandler : IRequestHandler<AddEditMaterialCommand, Result<AddEditMaterialCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditMaterialCommand> _logger;

        public AddEditMaterialCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditMaterialCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditMaterialCommand>> Handle(AddEditMaterialCommand command, CancellationToken cancellationToken)
        {


            if (command.Id == 0)
            {

                var table = _mapper.Map<Material>(command);

                _unitOfWork.Repository<Material>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditMaterialCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(Material)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<Material>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditMaterialCommand), typeof(Material));

                    _unitOfWork.Repository<Material>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditMaterialCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(Material)}");
                }
                else
                {
                    return await Result<AddEditMaterialCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditMaterialCommandValidator : AbstractValidator<AddEditMaterialCommand>
    {
        public AddEditMaterialCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(6).WithMessage("Max 6 characters");



        }
    }
}
