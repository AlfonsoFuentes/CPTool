



using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
    
    public class MWOItemDTO : AuditableEntityDTO
    {

        public List<PurchaseOrderDTO>? PurchaseOrderDTOs { get; set; } = new();

        public int? UnitaryBasePrizeId => UnitaryBasePrizeDTO?.Id;
        public UnitaryBasePrizeDTO? UnitaryBasePrizeDTO { get; set; } = new();

        public int? ChapterId => ChapterDTO?.Id;
        public ChapterDTO? ChapterDTO { get; set; } = new();

        public int? MWOId => MWODTO?.Id;
        public MWODTO? MWODTO { get => Master as MWODTO; set => Master = value; }

        public int? AlterationItemId => AlterationItemDTO?.Id;
        public AlterationItemDTO? AlterationItemDTO { get; set; }

        public int? FoundationItemId => FoundationItemDTO?.Id;
        public FoundationItemDTO? FoundationItemDTO { get; set; }

        public int? StructuralItemId => StructuralItemDTO?.Id;
        public StructuralItemDTO? StructuralItemDTO { get; set; }

        public int? EquipmentItemId => EquipmentItemDTO?.Id;
        public EquipmentItemDTO? EquipmentItemDTO { get; set; }

        public int? ElectricalItemId => ElectricalItemDTO?.Id;
        public ElectricalItemDTO? ElectricalItemDTO { get; set; }

        public int? PipingItemId => PipingItemDTO?.Id;
        public PipingItemDTO? PipingItemDTO { get; set; }

        public int? InstrumentItemId => InstrumentItemDTO?.Id;
        public InstrumentItemDTO? InstrumentItemDTO { get; set; }

        public int? InsulationItemId => InsulationItemDTO?.Id;
        public InsulationItemDTO? InsulationItemDTO { get; set; }

        public int? PaintingItemId => PaintingItemDTO?.Id;
        public PaintingItemDTO? PaintingItemDTO { get; set; }

        public int? EHSItemId => EHSItemDTO?.Id;
        public EHSItemDTO? EHSItemDTO { get; set; }

        public int? TaxesItemId => TaxesItemDTO?.Id;
        public TaxesItemDTO? TaxesItemDTO { get; set; }

        public int? TestingItemId => TestingItemDTO?.Id;
        public TestingItemDTO? TestingItemDTO { get; set; }

        public int? EngineeringCostItemId => EngineeringCostItemDTO?.Id;
        public EngineeringCostItemDTO? EngineeringCostItemDTO { get; set; }

        public int? ContingencyItemId => ContingencyItemDTO?.Id;
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
