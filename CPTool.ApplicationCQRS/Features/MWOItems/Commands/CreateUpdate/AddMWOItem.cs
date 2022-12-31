using CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ContingencyItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EHSItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ElectricalItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EngineeringCostItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.FoundationItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.InsulationItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PaintingItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.StructuralItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.TaxesItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.TestingItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate
{
    public class AddMWOItem
    {

       
        public string Name { get; set; } = string.Empty;
        public int? MWOId { get; set; }
        public int? UnitaryBasePrizeId { get; set; }
        public int Order { get; set; }
        public string? Nomenclatore { get; set; }
        public double BudgetPrize { get; set; }
        public double RealPrize { get; set; }
        public double UnitaryPrize { get; set; }
        public double Quantity { get; set; }
        public string? TagId { get; set; }
        public int? ChapterId { get; set; }
        public AddAlterationItem? AlterationItem { get; set; }
        public AddFoundationItem? FoundationItem { get; set; }
        public AddStructuralItem? StructuralItem { get; set; }
        public AddEquipmentItem? EquipmentItem { get; set; }
        public AddElectricalItem? ElectricalItem { get; set; }
        public AddPipingItem? PipingItem { get; set; }
        public AddInstrumentItem? InstrumentItem { get; set; }
        public AddInsulationItem? InsulationItem { get; set; }
        public AddPaintingItem? PaintingItem { get; set; }
        public AddEHSItem? EHSItem { get; set; }
        public AddTaxesItem? TaxesItem { get; set; }
        public AddTestingItem? TestingItem { get; set; }
        public AddEngineeringCostItem? EngineeringCostItem { get; set; }
        public AddContingencyItem? ContingencyItem { get; set; }
        public bool Existing { get; set; }
    }
    public class UpdateMWOItem
    {


        public string Name { get; set; } = string.Empty;
        public int? MWOId { get; set; }
        public int? UnitaryBasePrizeId { get; set; }
        public int Order { get; set; }
        public string? Nomenclatore { get; set; }
        public double BudgetPrize { get; set; }
        public double RealPrize { get; set; }
        public double UnitaryPrize { get; set; }
        public double Quantity { get; set; }
        public string? TagId { get; set; }
        public int? ChapterId { get; set; }
       
        public bool Existing { get; set; }
    }

}
