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
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PaintingItemFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;

using CPTool.Application.Features.StructuralItemFeatures.CreateEdit;
using CPTool.Application.Features.TaxesItemFeatures.CreateEdit;
using CPTool.Application.Features.TestingItemFeatures.CreateEdit;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;
using CPTool.Application.Features.SignalsFeatures.CreateEdit;

using System.Security.Cryptography.X509Certificates;
using System;
using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;
using CPTool.Domain.Enums;

namespace CPTool.Application.Features.MWOItemFeatures.CreateEdit
{
    public class EditMWOItem : EditCommand, IRequest<Result<int>>
    {
        public List<EditSignal> Signals { get; set; } = new();

        public int? UnitaryBasePrizeId => UnitaryBasePrize?.Id == 0 ? null : UnitaryBasePrize?.Id;
        public EditUnitaryBasePrize? UnitaryBasePrize { get; set; } = new();
        [Report(Order = 3)]
        public string UnitaryBasePrizeName => UnitaryBasePrize == null ? "" : UnitaryBasePrize!.Name;
        public int Order { get; set; }
        [Report(Order = 4)]
        public string? Nomenclatore => $"{Chapter?.Letter}{Order}";
        [Report(Order = 5)]
        public double BudgetPrize { get; set; }


        public List<EditPurchaseOrderItem> PurchaseOrderItems { get; set; } = new();
       

        public int? ChapterId => Chapter?.Id == 0 ? null : Chapter?.Id;
        public EditChapter? Chapter { get; set; } = new();
        [Report(Order = 7)]
        public string ChapterName => Chapter == null ? "" : Chapter!.Name;
        public int? AlterationItemId => AlterationItem == null ? null : AlterationItem?.Id;
        public EditAlterationItem? AlterationItem { get; set; }
        public int? FoundationItemId => FoundationItem == null ? null : FoundationItem?.Id;
        public EditFoundationItem? FoundationItem { get; set; }
        public int? StructuralItemId => StructuralItem == null ? null : StructuralItem?.Id;
        public EditStructuralItem? StructuralItem { get; set; }
        public int? EquipmentItemId => EquipmentItem == null ? null : EquipmentItem?.Id;
        
        public EditEquipmentItem? EquipmentItem { get; set; }
        public int? ElectricalItemId => ElectricalItem == null ? null : ElectricalItem?.Id;
        public EditElectricalItem? ElectricalItem { get; set; }
        public int? PipingItemId => PipingItem == null ? null : PipingItem?.Id;
        public EditPipingItem? PipingItem { get; set; }
        public int? InstrumentItemId => InstrumentItem == null ? null : InstrumentItem?.Id;
        public EditInstrumentItem? InstrumentItem { get; set; }
        public int? InsulationItemId => InsulationItem == null ? null : InsulationItem?.Id;
        public EditInsulationItem? InsulationItem { get; set; }
        public int? PaintingItemId => PaintingItem == null ? null : PaintingItem?.Id;
        public EditPaintingItem? PaintingItem { get; set; }
        public int? EHSItemId => EHSItem == null ? null : EHSItem?.Id;
        public EditEHSItem? EHSItem { get; set; }
        public int? TaxesItemId => TaxesItem == null ? null : TaxesItem?.Id;
        public EditTaxesItem? TaxesItem { get; set; }
        public int? TestingItemId => TestingItem == null ? null : TestingItem?.Id;
        public EditTestingItem? TestingItem { get; set; }
        public int? EngineeringCostItemId => EngineeringCostItem == null ? null : EngineeringCostItem?.Id;
        public EditEngineeringCostItem? EngineeringCostItem { get; set; }
        public int? ContingencyItemId => ContingencyItem == null ? null : ContingencyItem?.Id;
        public EditContingencyItem? ContingencyItem { get; set; }
        public int? MWOId => MWO?.Id == 0 ? null : MWO?.Id;
        [Report(Order = 8)]
        public bool Existing { get; set; }
        [Report(Order = 9)]
        public double Actual => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(y => y.ActualValue);
        [Report(Order = 10)] 
        public double Assigned => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(y => y.PrizeUSD);

        [Report(Order = 11)] 
        public double Commitment => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(y => y.CommitmentValue);

        [Report(Order = 12)] 
        public double Pending => BudgetPrize - Assigned;
        public EditMWO? MWO { get; set; } = new();
        [Report(Order = 13)] public string MWOName => MWO == null ? "" : MWO!.Name;
        [Report(Order = 6)]
        public string TagId => GetTagId();
        string tagid = "";
        string GetTagId()
        {
            switch (Chapter?.Id)
            {
                case 4:
                    return EquipmentItem==null? "" : EquipmentItem!.TagId;

                case 6:
                    return PipingItem == null ? "" : PipingItem!.TagId;

                case 7:
                    return InstrumentItem == null ? "" : InstrumentItem!.TagId;

            }
            return "";
        }
        public List<EditNozzle> Nozzles => GetNozzles();
        List<EditNozzle> GetNozzles()
        {
            List<EditNozzle> nozzles = new();
            switch (ChapterId)
            {
                case 4:
                    nozzles = EquipmentItem!.Nozzles!;
                    break;
                case 6:
                    nozzles = PipingItem!.Nozzles!;
                    break;
                case 7:
                    nozzles = InstrumentItem!.Nozzles!;
                    break;
            }
            return nozzles!;
        }
        public void AddNozzle(EditNozzle nozzle)
        {



            nozzle.Order = Nozzles!.Count == 0 ? 1 : this.Nozzles.OrderBy(x => x.Order).Last().Order + 1;
            nozzle.Name = $"N{nozzle.Order}";
            List<EditNozzle> nozzles = new();
            switch (ChapterId)
            {
                case 4:
                    nozzle.EquipmentItem = Id == 0 ? null : EquipmentItem;
                    nozzles = EquipmentItem!.Nozzles!;
                    break;
                case 6:
                    nozzle.PipingItem = Id == 0 ? null : PipingItem;
                    nozzles = PipingItem!.Nozzles!;
                    break;
                case 7:
                    nozzle.InstrumentItem = Id == 0 ? null : InstrumentItem;
                    nozzles = InstrumentItem!.Nozzles!;
                    break;
            }
            if (nozzles == null) nozzles = new();


            nozzles.Add(nozzle);




        }
        public void RemoveNozzle(EditNozzle nozzle)
        {
            List<EditNozzle> nozzles = new();
            switch (ChapterId)
            {
                case 4:
                    nozzle.EquipmentItem = null;
                    nozzles = EquipmentItem!.Nozzles!;
                    break;
                case 6:
                    nozzle.PipingItem = null;
                    nozzles = PipingItem!.Nozzles!;
                    break;
                case 7:
                    nozzle.InstrumentItem = null;
                    nozzles = InstrumentItem!.Nozzles!;
                    break;
            }
            nozzles.Remove(nozzle);
        }
        public void AssignInternalItem()
        {

            var chapterlist = MWO!.MWOItems!.Where(x => x.ChapterId != 0).ToList();

            var list = chapterlist.Where(x => x.ChapterId == ChapterId).ToList();
            Order = list.Count == 0 ? 1 : list.OrderBy(x => x.Order).Last().Order + 1;


            switch (Chapter?.Id)
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
