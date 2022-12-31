using CPtool.ExtensionMethods;
using CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.Domain.Enums;
using CPTool.UnitsSystem;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate
{
    public class CommandPipeAccesory : CommandBase, IRequest<PipeAccesoryCommandResponse>
    {


        public int? pPipingItemId => pPipingItem?.Id == 0 ? null : pPipingItem?.Id;
        public CommandPipingItem? pPipingItem { get; set; } = new();
        public int? pProcessConditionId => pProcessCondition?.Id == 0 ? null : pProcessCondition?.Id;
        public CommandProcessCondition? pProcessCondition { get; set; } = new();

        public int? paProcessFluidId => paProcessFluid == null ? null : paProcessFluid?.Id;
        public CommandProcessFluid? paProcessFluid { get; set; } = null;
        public string ProcessFluidName => paProcessFluid == null ? "" : paProcessFluid!.Name;
        public int? FrictionId => Friction?.Id == 0 ? null : Friction?.Id;
        public CommandUnit? Friction { get; set; } = new(UnitLessUnits.None);
        public string FrictionValue => Friction == null ? "" : Friction!.StringValue;
        public int? ReynoldId => Reynold?.Id == 0 ? null : Reynold?.Id;
        public CommandUnit? Reynold { get; set; } = new(UnitLessUnits.None);
        public string ReynoldValue => Reynold == null ? "" : Reynold!.StringValue;
        public int? LevelInletId => LevelInlet?.Id == 0 ? null : LevelInlet?.Id;
        public CommandUnit? LevelInlet { get; set; } = new(LengthUnits.MilliMeter);
        public string LevelInletValue => LevelInlet == null ? "" : LevelInlet!.StringValue;
        public int? LevelOutletId => LevelOutlet?.Id == 0 ? null : LevelOutlet?.Id;
        public CommandUnit? LevelOutlet { get; set; } = new(LengthUnits.MilliMeter);
        public string LevelOutletValue => LevelOutlet == null ? "" : LevelOutlet!.StringValue;
        public int? FrictionDropPressureId => FrictionDropPressure?.Id == 0 ? null : FrictionDropPressure?.Id;
        public CommandUnit? FrictionDropPressure { get; set; } = new(PressureDropUnits.psi);
        public string FrictionDropPressureValue => FrictionDropPressure == null ? "" : FrictionDropPressure!.StringValue;
        public int? OverallDropPressureId => OverallDropPressure?.Id == 0 ? null : OverallDropPressure?.Id;
        public CommandUnit? OverallDropPressure { get; set; } = new(PressureDropUnits.psi);
        public string OverallDropPressureValue => OverallDropPressure == null ? "" : OverallDropPressure!.StringValue;
        public int? ElevationChangeId => ElevationChange?.Id == 0 ? null : ElevationChange?.Id;
        public CommandUnit? ElevationChange { get; set; } = new(PressureDropUnits.psi);
        public string ElevationChangeValue => ElevationChange == null ? "" : ElevationChange!.StringValue;
        public int? paMaterialId => paMaterial?.Id == 0 ? null : paMaterial?.Id;
        public CommandMaterial? paMaterial { get; set; } = new();
      
        public string MaterialName => paMaterial == null ? "" : paMaterial!.Name;
        public int? paDiameterId => paDiameter?.Id == 0 ? null : paDiameter?.Id;
        public CommandPipeDiameter? paDiameter { get; set; } = new();
        
        public string DiameterName => paDiameter == null ? "" : paDiameter!.Name;
        public int? paPipeClassId => paPipeClass?.Id == 0 ? null : paPipeClass?.Id;
        public CommandPipeClass? paPipeClass { get; set; } = new();
      
        public string PipeClassName => paPipeClass == null ? "" : paPipeClass!.Name;
        public List<CommandNozzle> Nozzles { get; set; } = new();
  
        public string FlowDirectionName => FlowDirection.ToString();
        public FlowDirection FlowDirection { get; set; }
        PipeAccesorySectionType _SectionType;
       
        public string SectionTypeName => SectionType.ToString();
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

        CommandNozzle CreateSingleNozzle(StreamType type)
        {

            CommandNozzle nozzle = new();
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

    }

}
