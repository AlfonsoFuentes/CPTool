using CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.Query.GetById;
using CPTool.Application.Features.NozzleFeatures.Query.GetList;
using CPTool.Application.Features.PipeAccesoryFeatures.Query.GetById;
using CPTool.Application.Features.PipeAccesoryFeatures.Query.GetList;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.UnitsSystem;
using System.Linq;

namespace CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit
{
    public class EditPipeAccesory : EditCommand, IRequest<Result<int>>
    {
        public int? pPipingItemId => pPipingItem?.Id == 0 ? null : pPipingItem?.Id;
        public EditPipingItem? pPipingItem { get; set; } = new();
        public int? pProcessConditionId => pProcessCondition?.Id == 0 ? null : pProcessCondition?.Id;
        public EditProcessCondition? pProcessCondition { get; set; } = new();

        public int? paProcessFluidId => paProcessFluid == null ? null : paProcessFluid?.Id;
        public EditProcessFluid? paProcessFluid { get; set; } = null;
        public int? FrictionId => Friction?.Id == 0 ? null : Friction?.Id;
        public EditUnit? Friction { get; set; } = new(UnitLessUnits.None);
        public int? ReynoldId => Reynold?.Id == 0 ? null : Reynold?.Id;
        public EditUnit? Reynold { get; set; } = new(UnitLessUnits.None);
        public int? LevelInletId => LevelInlet?.Id == 0 ? null : LevelInlet?.Id;
        public EditUnit? LevelInlet { get; set; } = new(LengthUnits.MilliMeter);
        public int? LevelOutletId => LevelOutlet?.Id == 0 ? null : LevelOutlet?.Id;
        public EditUnit? LevelOutlet { get; set; } = new(LengthUnits.MilliMeter);
        public int? FrictionDropPressureId => FrictionDropPressure?.Id == 0 ? null : FrictionDropPressure?.Id;
        public EditUnit? FrictionDropPressure { get; set; } = new(PressureDropUnits.psi);
        public int? OverallDropPressureId => OverallDropPressure?.Id == 0 ? null : OverallDropPressure?.Id;
        public EditUnit? OverallDropPressure { get; set; } = new(PressureDropUnits.psi);
        public int? ElevationChangeId => ElevationChange?.Id == 0 ? null : ElevationChange?.Id;
        public EditUnit? ElevationChange { get; set; } = new(PressureDropUnits.psi);

        public int? paMaterialId => paMaterial?.Id == 0 ? null : paDiameter?.Id;
        public EditMaterial? paMaterial { get; set; } = new();
        public int? paDiameterId => paDiameter?.Id == 0 ? null : paDiameter?.Id;
        public EditPipeDiameter? paDiameter { get; set; } = new();
        public int? paPipeClassId => paPipeClass?.Id == 0 ? null : paPipeClass?.Id;
        public EditPipeClass? paPipeClass { get; set; } = new();
        public List<EditNozzle> Nozzles { get; set; } = new();
        public FlowDirection FlowDirection { get; set; }
        PipeAccesorySectionType _SectionType;
        public PipeAccesorySectionType SectionType
        {
            get
            {
                return _SectionType;
            }
            set
            {
                _SectionType = value;
                CreateNozzles();
            }
        }



        public override string Name => GetName();

        EditNozzle CreateSingleNozzle(StreamType type)
        {

            EditNozzle nozzle = new();
            nozzle.StreamType = type;
            nozzle.PipeDiameter = paDiameter;
            nozzle.nPipeClass = paPipeClass;
            nozzle.Name = $"N{Nozzles.Count + 1}"; ;
            nozzle.nMaterial = paMaterial;
            nozzle.PipeAccesory = this;
            return nozzle;
        }
        void CreateNozzles()
        {
            Nozzles = new();
            switch (SectionType)
            {
                case PipeAccesorySectionType.OutletVessel:
                    {
                        Nozzles?.Add(CreateSingleNozzle(StreamType.Outlet));
                    }
                    break;
                case PipeAccesorySectionType.InletVessel:
                    {
                        Nozzles?.Add(CreateSingleNozzle(StreamType.Inlet));

                    }
                    break;
                case PipeAccesorySectionType.Tube:
                case PipeAccesorySectionType.Elbow90:
                case PipeAccesorySectionType.Elbow45:

                case PipeAccesorySectionType.Reducer:
                case PipeAccesorySectionType.Expansion:

                    {
                        Nozzles?.Add(CreateSingleNozzle(StreamType.Inlet));
                        Nozzles?.Add(CreateSingleNozzle(StreamType.Outlet));
                    }
                    break;
                case PipeAccesorySectionType.TEE:
                    {
                        Nozzles?.Add(CreateSingleNozzle(StreamType.Inlet));
                        Nozzles?.Add(CreateSingleNozzle(StreamType.Outlet));
                        Nozzles?.Add(CreateSingleNozzle(StreamType.Outlet));
                    }
                    break;
                case PipeAccesorySectionType.CrossTEE:
                    {
                        Nozzles?.Add(CreateSingleNozzle(StreamType.Inlet));
                        Nozzles?.Add(CreateSingleNozzle(StreamType.Outlet));
                        Nozzles?.Add(CreateSingleNozzle(StreamType.Outlet));
                        Nozzles?.Add(CreateSingleNozzle(StreamType.Outlet));
                    }
                    break;
            }
        }
        string GetName()
        {
            if (SectionType == PipeAccesorySectionType.None) return "";

            string nozzlename = "";
            foreach (var row in Nozzles)
            {
                nozzlename += row.Name;
                if (row != Nozzles.Last() && Nozzles.Count != 2)
                    nozzlename += " x ";

            }
            return $"{SectionType} {nozzlename}";


        }
        public override T AddDetailtoMaster<T>()
        {
            T detail = new();
            (detail as EditNozzle)!.PipeAccesory = this;
            return detail!;
        }
    }

}
