

using CPTool.Application.Features.AlterationItemFeatures.CreateEdit;
using CPTool.Application.Features.ChapterFeatures.CreateEdit;
using CPTool.Application.Features.ContingencyItemFeatures.CreateEdit;
using CPTool.Application.Features.EHSItemFeatures.CreateEdit;
using CPTool.Application.Features.ElectricalItemFeatures.CreateEdit;
using CPTool.Application.Features.EngineeringCostItemFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.FoundationItemFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.InsulationItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.PaintingItemFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using CPTool.Application.Features.StructuralItemFeatures.CreateEdit;
using CPTool.Application.Features.TaxesItemFeatures.CreateEdit;
using CPTool.Application.Features.TestingItemFeatures.CreateEdit;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;
using System.Reflection;

namespace CPTool.Application.Features.MWOItemFeatures.CreateEdit
{
    public class AddMWOItem : AddCommand, IRequest<Result<int>>
    {
        public int? MWOId => MWO == null ? null : MWO.Id;
        public EditMWO? MWO { get; set; }
        public int? UnitaryBasePrizeId => UnitaryBasePrizeCommand?.Id == 0 ? null : UnitaryBasePrizeCommand?.Id;
        public EditUnitaryBasePrize? UnitaryBasePrizeCommand { get; set; } = new();
        public int Order { get; set; }
       
        public decimal BudgetPrize => UnitaryPrize * Quantity;
        public decimal RealPrize { get; set; }
        public decimal UnitaryPrize { get; set; }
        public decimal Quantity { get; set; }
       
        public string? Nomenclatore => $"{ChapterCommand.Letter}{Order}";
        public int ChapterId => ChapterCommand.Id;
        public EditChapter ChapterCommand { get; set; } = new();
       
        public AddAlterationItem? AlterationItem { get; set; }
        //public int? FoundationItemId => FoundationItem == null ? null : FoundationItem?.Id;
        public AddFoundationItem? FoundationItem { get; set; }
        //public int? StructuralItemId => StructuralItem == null ? null : StructuralItem?.Id;
        public AddStructuralItem? StructuralItem { get; set; }
        //public int? EquipmentItemId => EquipmentItem == null ? null : EquipmentItem?.Id;
        public AddEquipmentItem? EquipmentItem { get; set; }
        //public int? ElectricalItemId => ElectricalItem == null ? null : ElectricalItem?.Id;
        public AddElectricalItem? ElectricalItem { get; set; }
        //public int? PipingItemId => PipingItem == null ? null : PipingItem?.Id;
        public AddPipingItem? PipingItem { get; set; }
        //public int? InstrumentItemId => InstrumentItem == null ? null : InstrumentItem?.Id;
        public AddInstrumentItem? InstrumentItem { get; set; }
        //public int? InsulationItemId => InsulationItem == null ? null : InsulationItem?.Id;
        public AddInsulationItem? InsulationItem { get; set; }
        //public int? PaintingItemId => PaintingItem == null ? null : PaintingItem?.Id;
        public AddPaintingItem? PaintingItem { get; set; }
        //public int? EHSItemId => EHSItem == null ? null : EHSItem?.Id;
        public AddEHSItem? EHSItem { get; set; }
        //public int? TaxesItemId => TaxesItem == null ? null : TaxesItem?.Id;
        public AddTaxesItem? TaxesItem { get; set; }
        //public int? TestingItemId => TestingItem == null ? null : TestingItem?.Id;
        public AddTestingItem? TestingItem { get; set; }
        //public int? EngineeringCostItemId => EngineeringCostItem == null ? null : EngineeringCostItem?.Id;
        public AddEngineeringCostItem? EngineeringCostItem { get; set; }
        //public int? ContingencyItemId => ContingencyItem == null ? null : ContingencyItem?.Id;
        public AddContingencyItem? ContingencyItem { get; set; }

       

    }
}
