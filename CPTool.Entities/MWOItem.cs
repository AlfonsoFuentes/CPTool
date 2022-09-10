

namespace CPTool.Entities
{
    public class MWOItem : AuditableEntity
    {
       
        public virtual MWO MWO { get; set; } = null!;
        public virtual AlterationItem? AlterationItem { get; set; }
        public virtual FoundationItem? FoundationItem { get; set; }
        public virtual StructuralItem? StructuralItem { get; set; }
        public virtual EquipmentItem? EquipmentItem { get; set; }
        public virtual ElectricalItem? ElectricalItem { get; set; }
        public virtual PipingItem? PipingItem { get; set; }
        public virtual InstrumentItem? InstrumentItem { get; set; }
        public virtual InsulationItem? InsulationItem { get; set; }
        public virtual PaintingItem? PaintingItem { get; set; }
        public virtual EHSItem? EHSItem { get; set; }
        public virtual TaxesItem? TaxesItem { get; set; }
        public virtual TestingItem? TestingItem { get; set; }
        public virtual EngineeringCostItem? EngineeringCostItem { get; set; }
        public virtual ContingencyItem? ContingencyItem { get; set; }

       
        public virtual Chapter Chapter { get; set; } = null!;


        public virtual UnitaryBasePrize? UnitaryBasePrize { get; set; }
     

        public int Order { get; set; }
        public string? Nomenclatore { get; set; }
        public decimal BudgetPrize { get; set; }
        public decimal RealPrize { get; set; }
        public decimal UnitaryPrize { get; set; }
        public decimal Quantity { get; set; }

        
    }





}
