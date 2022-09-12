



using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
    
    public class MWOItemDTO : AuditableEntityDTO
    {
       
        public List<PurchaseOrderDTO>? PurchaseOrderDTOs { get; set; }
        public MWODTO? MWODTO { get; set; }
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
        public UnitaryBasePrizeDTO? UnitaryBasePrizeDTO { get; set; }
        public int Order { get; set; }
     
        public ChapterDTO? ChapterDTO { get; set; }

        public int? MWOId { get; set; } = null!;
        public int? AlterationItemId { get; set; }
        public int? FoundationItemId { get; set; }
        public int? StructuralItemId { get; set; }
        public int? EquipmentItemId { get; set; }
        public int? ElectricalItemId { get; set; }
        public int? PipingItemId { get; set; }
        public int? InstrumentItemId { get; set; }
        public int? InsulationItemId { get; set; }
        public int? PaintingItemId { get; set; }
        public int? EHSItemId { get; set; }
        public int? TaxesItemId { get; set; }
        public int? TestingItemId { get; set; }
        public int? EngineeringCostItemId { get; set; }
        public int? ContingencyItemId { get; set; }
        public int ChapterId { get; set; }
        public int? UnitaryBasePrizeId { get; set; }

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
