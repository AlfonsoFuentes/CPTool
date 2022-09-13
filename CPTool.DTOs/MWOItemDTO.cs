



using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
    
    public class MWOItemDTO : AuditableEntityDTO
    {
       
        public List<PurchaseOrderDTO>? PurchaseOrderDTOs { get; set; }
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
        public UnitaryBasePrizeDTO? UnitaryBasePrizeDTO { get; set; } = new();
        public int Order { get; set; }

        public ChapterDTO? ChapterDTO { get; set; } = new();

        public int MWOId => MWODTO == null ? 0 : MWODTO.Id; 
        public int? AlterationItemId  => AlterationItemDTO==null? null : AlterationItemDTO.Id;
        public int? FoundationItemId => FoundationItemDTO == null ? null : FoundationItemDTO.Id;
        public int? StructuralItemId => StructuralItemDTO == null ? null : StructuralItemDTO.Id;
        public int? EquipmentItemId => EquipmentItemDTO == null ? null : EquipmentItemDTO.Id;
        public int? ElectricalItemId => ElectricalItemDTO == null ? null : ElectricalItemDTO.Id;
        public int? PipingItemId => PipingItemDTO == null ? null : PipingItemDTO.Id;
        public int? InstrumentItemId => InstrumentItemDTO == null ? null : InstrumentItemDTO.Id;
        public int? InsulationItemId => InsulationItemDTO == null ? null : InsulationItemDTO.Id;
        public int? PaintingItemId => PaintingItemDTO == null ? null : PaintingItemDTO.Id;
        public int? EHSItemId => EHSItemDTO == null ? null : EHSItemDTO.Id;
        public int? TaxesItemId => TaxesItemDTO == null ? null : TaxesItemDTO.Id;
        public int? TestingItemId => TestingItemDTO == null ? null : TestingItemDTO.Id;
        public int? EngineeringCostItemId => EngineeringCostItemDTO == null ? null : EngineeringCostItemDTO.Id;
        public int? ContingencyItemId => ContingencyItemDTO == null ? null : ContingencyItemDTO.Id;
        public int ChapterId => ChapterDTO == null ? 0 : ChapterDTO.Id;
        public int UnitaryBasePrizeId => UnitaryBasePrizeDTO == null ? 0 : UnitaryBasePrizeDTO.Id;

        public string Nomenclatore => $"{ChapterLetter}{Order}";
        public string Letter { get; set; } = "";
        string ChapterLetter => ChapterDTO == null ? Letter : ChapterDTO.Letter!;

        public decimal BudgetPrize => UnitaryPrize * Quantity;
        public decimal RealPrize { get; set; }
        public decimal UnitaryPrize { get; set; }
        public decimal Quantity { get; set; }

       
    }
    public class CreateMWOItemDTO :MWOItemDTO
    {

    }




}
