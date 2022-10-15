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

namespace CPTool.Application.Features.MWOItemFeatures.CreateEdit
{
    public class EditMWOItem : EditCommand, IRequest<Result<int>>
    {
       
        //public int? UnitaryBasePrizeId => UnitaryBasePrize?.Id == 0 ? null : UnitaryBasePrize?.Id;
        public EditUnitaryBasePrize? UnitaryBasePrize { get; set; } = new();
        public int Order { get; set; }
        public string? Nomenclatore => $"{Chapter.Letter}{Order}";
        public decimal BudgetPrize => UnitaryPrize * Quantity;
        public decimal RealPrize { get; set; }
        public decimal UnitaryPrize { get; set; }
        public decimal Quantity { get; set; }
        public string TagId => GetTagId();

        public int ChapterId => Chapter.Id;
        public EditChapter Chapter { get; set; } = new();
        //public int? AlterationItemId => AlterationItem == null ? null : AlterationItem?.Id;
        public EditAlterationItem? AlterationItem { get; set; }
        //public int? FoundationItemId => FoundationItem == null ? null : FoundationItem?.Id;
        public AddFoundationItem? FoundationItem { get; set; }
        //public int? StructuralItemId => StructuralItem == null ? null : StructuralItem?.Id;
        public EditStructuralItem? StructuralItem { get; set; }
        //public int? EquipmentItemId => EquipmentItem == null ? null : EquipmentItem?.Id;
        public EditEquipmentItem? EquipmentItem { get; set; }
        //public int? ElectricalItemId => ElectricalItem == null ? null : ElectricalItem?.Id;
        public EditElectricalItem? ElectricalItem { get; set; }
        //public int? PipingItemId => PipingItem == null ? null : PipingItem?.Id;
        public EditPipingItem? PipingItem { get; set; }
        //public int? InstrumentItemId => InstrumentItem == null ? null : InstrumentItem?.Id;
        public EditInstrumentItem? InstrumentItem { get; set; }
        //public int? InsulationItemId => InsulationItem == null ? null : InsulationItem?.Id;
        public EditInsulationItem? InsulationItem { get; set; }
        //public int? PaintingItemId => PaintingItem == null ? null : PaintingItem?.Id;
        public EditPaintingItem? PaintingItem { get; set; }
        //public int? EHSItemId => EHSItem == null ? null : EHSItem?.Id;
        public EditEHSItem? EHSItem { get; set; }
        //public int? TaxesItemId => TaxesItem == null ? null : TaxesItem?.Id;
        public EditTaxesItem? TaxesItem { get; set; }
        //public int? TestingItemId => TestingItem == null ? null : TestingItem?.Id;
        public EditTestingItem? TestingItem { get; set; }
        //public int? EngineeringCostItemId => EngineeringCostItem == null ? null : EngineeringCostItem?.Id;
        public EditEngineeringCostItem? EngineeringCostItem { get; set; }
        //public int? ContingencyItemId => ContingencyItem == null ? null : ContingencyItem?.Id;
        public EditContingencyItem? ContingencyItem { get; set; }

        public EditMWO? MWO { get; set; }
        string GetTagId()
        {
            switch (Chapter.Id)
            {
                case 4:
                    return EquipmentItem!.TagId;

                case 6:
                    return PipingItem!.TagId;

                case 7:
                    return InstrumentItem!.TagId;

            }
            return "";
        }

        public void AssignInternalItem()
        {
            var list = MWO!.MWOItems!.Where(x => x.ChapterId == Chapter.Id).ToList();
            Order = list.Count == 0 ? 1 : list.OrderBy(x => x.Order).Last().Order + 1;


            switch (Chapter.Id)
            {
                case 1:
                    AlterationItem = new();
                    break;
                case 2:
                    FoundationItem = new();
                    break;
                case 3:
                    StructuralItem = new();
                    break;
                case 4:
                    EquipmentItem = new();
                    break;
                case 5:
                    ElectricalItem = new();
                    break;
                case 6:
                    PipingItem = new();

                    break;
                case 7:
                    InstrumentItem = new();
                    break;
                case 8:
                    InsulationItem = new();
                    break;
                case 9:
                    PaintingItem = new();
                    break;
                case 10:
                    EHSItem = new();
                    break;
                case 11:
                    TaxesItem = new();
                    break;
                case 12:
                    TestingItem = new();
                    break;
                case 13:
                    EngineeringCostItem = new();
                    break;
                case 14:
                    ContingencyItem = new();
                    break;
            }
        }



    }
}
