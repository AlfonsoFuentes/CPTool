

namespace CPTool.Entities
{
    public class MWOItem : AuditableEntity
    {

        public ICollection<PurchaseOrder>? PurchaseOrders { get; set; }
        public  MWO MWO { get; set; } = null!;
        public  AlterationItem? AlterationItem { get; set; }
        public  FoundationItem? FoundationItem { get; set; }
        public  StructuralItem? StructuralItem { get; set; }
        public  EquipmentItem? EquipmentItem { get; set; }
        public  ElectricalItem? ElectricalItem { get; set; }
        public  PipingItem? PipingItem { get; set; }
        public  InstrumentItem? InstrumentItem { get; set; }
        public  InsulationItem? InsulationItem { get; set; }
        public  PaintingItem? PaintingItem { get; set; }
        public  EHSItem? EHSItem { get; set; }
        public  TaxesItem? TaxesItem { get; set; }
        public  TestingItem? TestingItem { get; set; }
        public  EngineeringCostItem? EngineeringCostItem { get; set; }
        public  ContingencyItem? ContingencyItem { get; set; }
        public  Chapter Chapter { get; set; } = null!;
        public  UnitaryBasePrize? UnitaryBasePrize { get; set; }

        public int? MWOId { get; set; } = null!;
        public int ? AlterationItemId { get; set; }
        public int ? FoundationItemId { get; set; }
        public int ? StructuralItemId { get; set; }
        public int ? EquipmentItemId { get; set; }
        public int ? ElectricalItemId { get; set; }
        public int ? PipingItemId { get; set; }
        public int ? InstrumentItemId { get; set; }
        public int ? InsulationItemId { get; set; }
        public int ? PaintingItemId { get; set; }
        public int ? EHSItemId { get; set; }
        public int ? TaxesItemId { get; set; }
        public int ? TestingItemId { get; set; }
        public int ? EngineeringCostItemId { get; set; }
        public int ? ContingencyItemId { get; set; }
        public int  ChapterId { get; set; } 
        public int ? UnitaryBasePrizeId { get; set; }

        public int Order { get; set; }
        public string? Nomenclatore { get; set; }
        public decimal BudgetPrize { get; set; }
        public decimal RealPrize { get; set; }
        public decimal UnitaryPrize { get; set; }
        public decimal Quantity { get; set; }


    }





}
