using CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Chapters.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ContingencyItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EHSItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ElectricalItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EngineeringCostItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.FoundationItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.InsulationItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PaintingItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.StructuralItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.TaxesItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.TestingItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate
{
    public class CommandMWOItem : CommandBase, IRequest<MWOItemCommandResponse>
    {


        public List<CommandSignal> Signals { get; set; } = new();

        public int? UnitaryBasePrizeId => UnitaryBasePrize?.Id == 0 ? null : UnitaryBasePrize?.Id;
        public CommandUnitaryBasePrize? UnitaryBasePrize { get; set; } = new();

        public string UnitaryBasePrizeName => UnitaryBasePrize == null ? "" : UnitaryBasePrize!.Name;
        public int Order { get; set; }

        public string? Nomenclatore => $"{Chapter?.Letter}{Order}";

        public double BudgetPrize { get; set; }


        public List<CommandPurchaseOrderItem> PurchaseOrderItems { get; set; } = new();


        public int? ChapterId => Chapter?.Id == 0 ? null : Chapter?.Id;
        public CommandChapter? Chapter { get; set; } = new();

        public string ChapterName => Chapter == null ? "" : Chapter!.Name;
        public int? AlterationItemId => AlterationItem == null ? null : AlterationItem?.Id;
        public CommandAlterationItem? AlterationItem { get; set; }
        public int? FoundationItemId => FoundationItem == null ? null : FoundationItem?.Id;
        public CommandFoundationItem? FoundationItem { get; set; }
        public int? StructuralItemId => StructuralItem == null ? null : StructuralItem?.Id;
        public CommandStructuralItem? StructuralItem { get; set; }
        public int? EquipmentItemId => EquipmentItem == null ? null : EquipmentItem?.Id;

        public CommandEquipmentItem? EquipmentItem { get; set; }
        public int? ElectricalItemId => ElectricalItem == null ? null : ElectricalItem?.Id;
        public CommandElectricalItem? ElectricalItem { get; set; }
        public int? PipingItemId => PipingItem == null ? null : PipingItem?.Id;
        public CommandPipingItem? PipingItem { get; set; }
        public int? InstrumentItemId => InstrumentItem == null ? null : InstrumentItem?.Id;
        public CommandInstrumentItem? InstrumentItem { get; set; }
        public int? InsulationItemId => InsulationItem == null ? null : InsulationItem?.Id;
        public CommandInsulationItem? InsulationItem { get; set; }
        public int? PaintingItemId => PaintingItem == null ? null : PaintingItem?.Id;
        public CommandPaintingItem? PaintingItem { get; set; }
        public int? EHSItemId => EHSItem == null ? null : EHSItem?.Id;
        public CommandEHSItem? EHSItem { get; set; }
        public int? TaxesItemId => TaxesItem == null ? null : TaxesItem?.Id;
        public CommandTaxesItem? TaxesItem { get; set; }
        public int? TestingItemId => TestingItem == null ? null : TestingItem?.Id;
        public CommandTestingItem? TestingItem { get; set; }
        public int? EngineeringCostItemId => EngineeringCostItem == null ? null : EngineeringCostItem?.Id;
        public CommandEngineeringCostItem? EngineeringCostItem { get; set; }
        public int? ContingencyItemId => ContingencyItem == null ? null : ContingencyItem?.Id;
        public CommandContingencyItem? ContingencyItem { get; set; }
        public int? MWOId => MWO?.Id == 0 ? null : MWO?.Id;

        public bool Existing { get; set; }

        public double Actual => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(y => y.ActualValue);
        public double Budget => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(y => y.ActualValue);
        public double Assigned => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(y => y.PrizeUSD);


        public double Commitment => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(y => y.CommitmentValue);


        public double Pending => BudgetPrize - Assigned;
        public CommandMWO? MWO { get; set; } = new();

        public string MWOName => MWO == null ? "" : MWO!.Name;

        public string TagId => GetTagId();

        string GetTagId()
        {
            switch (Chapter?.Id)
            {
                case 4:
                    return EquipmentItem == null ? "" : EquipmentItem!.TagId;

                case 6:
                    return PipingItem == null ? "" : PipingItem!.TagId;

                case 7:
                    return InstrumentItem == null ? "" : InstrumentItem!.TagId;

            }
            return "";
        }
        public List<CommandNozzle> Nozzles => GetNozzles();
        List<CommandNozzle> GetNozzles()
        {
            List<CommandNozzle> nozzles = new();
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
        public void AddNozzle(CommandNozzle nozzle)
        {



            nozzle.Order = Nozzles!.Count == 0 ? 1 : this.Nozzles.OrderBy(x => x.Order).Last().Order + 1;
            nozzle.Name = $"N{nozzle.Order}";
            List<CommandNozzle> nozzles = new();
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
        public void RemoveNozzle(CommandNozzle nozzle)
        {
            List<CommandNozzle> nozzles = new();
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

        public CommandProcessFluid ProcessFluid
        {
            get
            {
                switch (ChapterId)
                {
                    case 4: return EquipmentItem!.eProcessFluid!;
                    case 6: return PipingItem!.pProcessFluid!;
                    case 7: return InstrumentItem!.iProcessFluid!;
                }
                return null!;
            }
            set
            {
                switch (ChapterId)
                {
                    case 4:
                        EquipmentItem!.eProcessFluid = value;
                        break;
                    case 6:
                        PipingItem!.pProcessFluid = value;
                        break;
                    case 7:
                        InstrumentItem!.iProcessFluid = value;
                        break;
                }
            }
        }
        public CommandProcessCondition ProcessCondition
        {
            get
            {
                switch (ChapterId)
                {
                    case 4: return EquipmentItem!.eProcessCondition!;
                    case 6: return PipingItem!.pProcessCondition!;
                    case 7: return InstrumentItem!.iProcessCondition!;
                }
                return null!;
            }
            set
            {
                switch (ChapterId)
                {
                    case 4:
                        EquipmentItem!.eProcessCondition = value;
                        break;
                    case 6:
                        PipingItem!.pProcessCondition = value;
                        break;
                    case 7:
                        InstrumentItem!.iProcessCondition = value;
                        break;
                }
            }
        }

    }

}
