

using CPTool.Application.Features.AlterationItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;
using CPTool.Application.Features.ContingencyItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.EHSItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.ElectricalItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.EngineeringCostItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.FoundationItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.InsulationItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;
using CPTool.Application.Features.PaintingItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.StructuralItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.TaxesItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.TestingItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.Command.CreateEdit;
using System.Reflection;

namespace CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit
{
    public class AddEditMWOItemCommand : AddEditCommand, IRequest<Result<AddEditMWOItemCommand>>
    {
        public int MWOId => MWOCommand.Id;
        public AddEditMWOCommand MWOCommand { get => (Parent as AddEditMWOCommand)!; set => Parent = value; }
        public int? UnitaryBasePrizeId => UnitaryBasePrizeCommand?.Id == 0 ? null : UnitaryBasePrizeCommand?.Id;
        public AddEditUnitaryBasePrizeCommand? UnitaryBasePrizeCommand { get; set; } = new();
        public int Order { get; set; }
        public string? Nomenclatore => $"{ChapterCommand.Letter}{Order}";
        public decimal BudgetPrize => UnitaryPrize * Quantity;
        public decimal RealPrize { get; set; }
        public decimal UnitaryPrize { get; set; }
        public decimal Quantity { get; set; }
        public string TagId => GetTagId();

        public int ChapterId => ChapterCommand.Id;
        public AddEditChapterCommand ChapterCommand { get; set; } = new();
        public int? AlterationItemId => AlterationItemCommand == null ? null : AlterationItemCommand?.Id;
        public AddEditAlterationItemCommand? AlterationItemCommand { get; set; }
        public int? FoundationItemId => FoundationItemCommand == null ? null : FoundationItemCommand?.Id;
        public AddEditFoundationItemCommand? FoundationItemCommand { get; set; }
        public int? StructuralItemId => StructuralItemCommand == null ? null : StructuralItemCommand?.Id;
        public AddEditStructuralItemCommand? StructuralItemCommand { get; set; }
        public int? EquipmentItemId => EquipmentItemCommand == null ? null : EquipmentItemCommand?.Id;
        public AddEditEquipmentItemCommand? EquipmentItemCommand { get; set; }
        public int? ElectricalItemId => ElectricalItemCommand == null ? null : ElectricalItemCommand?.Id;
        public AddEditElectricalItemCommand? ElectricalItemCommand { get; set; }
        public int? PipingItemId => PipingItemCommand == null ? null : PipingItemCommand?.Id;
        public AddEditPipingItemCommand? PipingItemCommand { get; set; }
        public int? InstrumentItemId => InstrumentItemCommand == null ? null : InstrumentItemCommand?.Id;
        public AddEditInstrumentItemCommand? InstrumentItemCommand { get; set; }
        public int? InsulationItemId => InsulationItemCommand == null ? null : InsulationItemCommand?.Id;
        public AddEditInsulationItemCommand? InsulationItemCommand { get; set; }
        public int? PaintingItemId => PaintingItemCommand == null ? null : PaintingItemCommand?.Id;
        public AddEditPaintingItemCommand? PaintingItemCommand { get; set; }
        public int? EHSItemId => EHSItemCommand == null ? null : EHSItemCommand?.Id;
        public AddEditEHSItemCommand? EHSItemCommand { get; set; }
        public int? TaxesItemId => TaxesItemCommand == null ? null : TaxesItemCommand?.Id;
        public AddEditTaxesItemCommand? TaxesItemCommand { get; set; }
        public int? TestingItemId => TestingItemCommand == null ? null : TestingItemCommand?.Id;
        public AddEditTestingItemCommand? TestingItemCommand { get; set; }
        public int? EngineeringCostItemId => EngineeringCostItemCommand == null ? null : EngineeringCostItemCommand?.Id;
        public AddEditEngineeringCostItemCommand? EngineeringCostItemCommand { get; set; }
        public int? ContingencyItemId => ContingencyItemCommand == null ? null : ContingencyItemCommand?.Id;
        public AddEditContingencyItemCommand? ContingencyItemCommand { get; set; }

        string GetTagId()
        {
            switch(ChapterCommand.Id)
            {
                case 4:
                    return EquipmentItemCommand!.TagId;
                  
                case 6:
                    return PipingItemCommand!.TagId;
                  
                case 7:
                    return InstrumentItemCommand!.TagId;
                   
            }
            return "";
        }

        public void AssignInternalItem()
        {
            var list = MWOCommand.MWOItemsCommand.Where(x => x.ChapterId == ChapterCommand.Id).ToList();
            Order = list.Count == 0 ? 1 : list.OrderBy(x => x.Order).Last().Order + 1;


            switch (ChapterCommand.Id)
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
                try
                {
                    var table = _mapper.Map<MWOItem>(command);
                    _unitOfWork.Repository<MWOItem>().Add(table);
                    await _unitOfWork.Complete();
                    command.Id = table.Id;
                    return await Result<AddEditMWOItemCommand>.SuccessAsync(command, $"{table.Name} Added to {nameof(MWOItem)}");
                }
                catch (Exception ex)
                {
                    string exm = ex.Message;
                    return await Result<AddEditMWOItemCommand>.FailAsync($"{ex.Message}");
                }




            }
            else
            {
                var table = await _unitOfWork.RepositoryMWOItem.GetMWOItemIdAsync(command.Id);
                if (table != null)
                {
                    try
                    {

                        _mapper.Map(command, table, typeof(AddEditMWOItemCommand), typeof(MWOItem));

                        _unitOfWork.Repository<MWOItem>().Update(table);
                        await _unitOfWork.Complete();
                        return await Result<AddEditMWOItemCommand>.SuccessAsync(command, $"{table.Name} Updated in {nameof(MWOItem)}");
                    }
                    catch (Exception ex)
                    {
                        string exm = ex.Message;
                        return await Result<AddEditMWOItemCommand>.FailAsync($"{ex.Message}");
                    }
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
