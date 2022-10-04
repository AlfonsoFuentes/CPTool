

using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.ContingencyItemFeatures.ContingencyItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.AlterationItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.EHSItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.ElectricalItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.EngineeringCostItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.FoundationItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.InsulationItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.PaintingItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.PipingItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.StructuralItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.TaxesItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.TestingItemFeatures.CreateEdit;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit
{
    public class AddEditMWOItemCommand : AddEditCommand, IRequest<Result<AddEditMWOItemCommand>>
    {
        public int MWOId => MWOCommand.Id;
        public AddEditMWOCommand MWOCommand { get; set; } = new();
        public int Order { get; set; }
        public string? Nomenclatore { get; set; }
        public decimal BudgetPrize { get; set; }
        public decimal RealPrize { get; set; }
        public decimal UnitaryPrize { get; set; }
        public decimal Quantity { get; set; }
        public string TagId { get; set; } = string.Empty;

        public int ChapterId => ChapterCommand.Id;
        public AddEditChapterCommand ChapterCommand { get; set; } = new();
        public int? AlterationItemId => AlterationItemCommand?.Id;
        public AddEditAlterationItemCommand? AlterationItemCommand { get; set; }
        public int? FoundationItemId => FoundationItemCommand?.Id;
        public AddEditFoundationItemCommand? FoundationItemCommand { get; set; }
        public int? StructuralItemId => StructuralItemCommand?.Id;
        public AddEditStructuralItemCommand? StructuralItemCommand { get; set; }
        public int? EquipmentItemId => EquipmentItemCommand?.Id;
        public AddEditEquipmentItemCommand? EquipmentItemCommand { get; set; }
        public int? ElectricalItemId => ElectricalItemCommand?.Id;
        public AddEditElectricalItemCommand? ElectricalItemCommand { get; set; }
        public int? PipingItemId => PipingItemCommand?.Id;
        public AddEditPipingItemCommand? PipingItemCommand { get; set; }
        public int? InstrumentItemId => InstrumentItemCommand?.Id;
        public AddEditInstrumentItemCommand? InstrumentItemCommand { get; set; }
        public int? InsulationItemId => InsulationItemCommand?.Id;
        public AddEditInsulationItemCommand? InsulationItemCommand { get; set; }
        public int? PaintingItemId => PaintingItemCommand?.Id;
        public AddEditPaintingItemCommand? PaintingItemCommand { get; set; }
        public int? EHSItemId => EHSItemCommand?.Id;
        public AddEditEHSItemCommand? EHSItemCommand { get; set; }
        public int? TaxesItemId => TaxesItemCommand?.Id;
        public AddEditTaxesItemCommand? TaxesItemCommand { get; set; }
        public int? TestingItemId => TestingItemCommand?.Id;
        public AddEditTestingItemCommand? TestingItemCommand { get; set; }
        public int? EngineeringCostItemId => EngineeringCostItemCommand?.Id;
        public AddEditEngineeringCostItemCommand? EngineeringCostItemCommand { get; set; }
        public int? ContingencyItemId => ContingencyItemCommand?.Id;
        public AddEditContingencyItemCommand? ContingencyItemCommand { get; set; }

        public int? UnitaryBasePrizeId => UnitaryBasePrizeCommand.Id;
        public AddEditUnitaryBasePrizeCommand UnitaryBasePrizeCommand { get; set; } = new();
        
       public void AssignInternalItem(AddEditChapterCommand chapterCommand)
        {
            ChapterCommand = chapterCommand;
            switch (chapterCommand.Id)
            {
                case 1:
                    AlterationItemCommand = new();
                    break;
                case 2:
                    FoundationItemCommand = new();
                    break;
                case 3:
                    StructuralItemCommand = new();
                    break;
                case 4:
                    EquipmentItemCommand = new();
                    break;
                case 5:
                    ElectricalItemCommand = new();
                    break;
                case 6:
                    PipingItemCommand = new();
                   
                    break;
                case 7:
                    InstrumentItemCommand = new();
                    break;
                case 8:
                    InsulationItemCommand = new();
                    break;
                case 9:
                    PaintingItemCommand = new();
                    break;
                case 10:
                    EHSItemCommand = new();
                    break;
                case 11:
                    TaxesItemCommand = new();
                    break;
                case 12:
                    TestingItemCommand = new();
                    break;
                case 13:
                    EngineeringCostItemCommand = new();
                    break;
                case 14:
                    ContingencyItemCommand = new();
                    break;
            }
        }
        
    }
    internal class AddEditMWOItemCommandHandler : IRequestHandler<AddEditMWOItemCommand, Result<AddEditMWOItemCommand>>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddEditMWOItemCommand> _logger;

        public AddEditMWOItemCommandHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddEditMWOItemCommand> logger)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Result<AddEditMWOItemCommand>> Handle(AddEditMWOItemCommand command, CancellationToken cancellationToken)
        {
           
            if (command.Id == 0)
            {
                
                var table = _mapper.Map<MWOItem>(command);

                _unitOfWork.Repository<MWOItem>().Add(table);
                await _unitOfWork.Complete();
                command.Id = table.Id;
                return await Result<AddEditMWOItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(MWOItem)}");
            }
            else
            {
                var table = await _unitOfWork.Repository<MWOItem>().GetByIdAsync(command.Id);
                if (table != null)
                {
                    _mapper.Map(command, table, typeof(AddEditMWOItemCommand), typeof(MWOItem));

                    _unitOfWork.Repository<MWOItem>().Update(table);
                    await _unitOfWork.Complete();
                    return await Result<AddEditMWOItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(MWOItem)}");
                }
                else
                {
                    return await Result<AddEditMWOItemCommand>.FailAsync($"{command.Name} not found");
                }
            }
        }
    }
    public class AddEditMWOItemCommandValidator : AbstractValidator<AddEditMWOItemCommand>
    {
        public AddEditMWOItemCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MaximumLength(50).WithMessage("Max 50 characters");

          

        }
    }
}
