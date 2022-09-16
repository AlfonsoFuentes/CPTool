



using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
    
    public class MWOItemDTO : AuditableEntityDTO
    {

        public List<PurchaseOrderMWOItemDTO>? PurchaseOrderMWOItemDTOs { get; set; } = new();

        public int? UnitaryBasePrizeId => UnitaryBasePrizeDTO?.Id;
        public int? ChapterId => ChapterDTO?.Id;
        public int? MWOId => MWODTO?.Id;
        public int? AlterationItemId => AlterationItemDTO?.Id;
        public int? FoundationItemId => FoundationItemDTO?.Id;
        public int? StructuralItemId => StructuralItemDTO?.Id;
        public int? EquipmentItemId => EquipmentItemDTO?.Id;
        public int? ElectricalItemId => ElectricalItemDTO?.Id;
        public int? PipingItemId => PipingItemDTO?.Id;
        public int? InstrumentItemId => InstrumentItemDTO?.Id;
        public int? InsulationItemId => InsulationItemDTO?.Id;
        public int? PaintingItemId => PaintingItemDTO?.Id;
        public int? EHSItemId => EHSItemDTO?.Id;
        public int? TaxesItemId => TaxesItemDTO?.Id;
        public int? TestingItemId => TestingItemDTO?.Id;
        public int? EngineeringCostItemId => EngineeringCostItemDTO?.Id;
        public int? ContingencyItemId => ContingencyItemDTO?.Id;
        public UnitaryBasePrizeDTO? UnitaryBasePrizeDTO { get; set; } = new();
        public ChapterDTO? ChapterDTO { get; set; } = new();
        public MWODTO? MWODTO { get => Master as MWODTO; set => Master = value; }
        public AlterationItemDTO? AlterationItemDTO { get; set; }
        public FoundationItemDTO? FoundationItemDTO { get; set; }
        public StructuralItemDTO? StructuralItemDTO { get; set; }
        public EquipmentItemDTO? EquipmentItemDTO { get; set; }
        public ElectricalItemDTO? ElectricalItemDTO { get; set; }
        public PipingItemDTO? PipingItemDTO { get; set; }
        public InstrumentItemDTO? InstrumentItemDTO { get; set; }
        public InsulationItemDTO? InsulationItemDTO { get; set; }
        public PaintingItemDTO? PaintingItemDTO { get; set; }
        public EHSItemDTO? EHSItemDTO { get; set; }
        public TaxesItemDTO? TaxesItemDTO { get; set; }
        public TestingItemDTO? TestingItemDTO { get; set; }
        public EngineeringCostItemDTO? EngineeringCostItemDTO { get; set; }
        public ContingencyItemDTO? ContingencyItemDTO { get; set; }
       

        public string Nomenclatore => $"{ChapterLetter}{Order}";
      
        string ChapterLetter => ChapterDTO?.Letter!;
        public int Order { get; set; }
        public decimal BudgetPrize => UnitaryPrize * Quantity;
        public decimal RealPrize { get; set; }
        public decimal UnitaryPrize { get; set; }
        public decimal Quantity { get; set; }

       
    }
    




}
