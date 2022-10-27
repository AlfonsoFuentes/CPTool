

using CPTool.Application.Features.AlterationItemFeatures.CreateEdit;
using CPTool.Application.Features.ContingencyItemFeatures.CreateEdit;
using CPTool.Application.Features.EHSItemFeatures.CreateEdit;
using CPTool.Application.Features.ElectricalItemFeatures.CreateEdit;
using CPTool.Application.Features.EngineeringCostItemFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.FoundationItemFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.InsulationItemFeatures.CreateEdit;
using CPTool.Application.Features.PaintingItemFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using CPTool.Application.Features.StructuralItemFeatures.CreateEdit;
using CPTool.Application.Features.TaxesItemFeatures.CreateEdit;
using CPTool.Application.Features.TestingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.CreateEdit
{
    public class AddMWOItem : AddCommand
    {
        public int? MWOId { get; set; }
        public int? UnitaryBasePrizeId { get; set; }
        public int Order { get; set; }
        public string? Nomenclatore { get; set; }
        public decimal BudgetPrize { get; set; }
        public decimal RealPrize { get; set; }
        public decimal UnitaryPrize { get; set; }
        public decimal Quantity { get; set; }
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
    }
}
