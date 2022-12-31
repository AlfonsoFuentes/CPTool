using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate
{
    public class AddPipeAccesory
    {

       
        public string Name { get; set; } = string.Empty;
        public int? pPipingItemId { get; set; }
        public AddProcessCondition? pProcessCondition { get; set; }

        public int? paProcessFluidId { get; set; }

        public AddUnit? Friction { get; set; }
        public AddUnit? Reynold { get; set; }
        public AddUnit? LevelInlet { get; set; }
        public AddUnit? LevelOutlet { get; set; }
        public AddUnit? FrictionDropPressure { get; set; }
        public AddUnit? OverallDropPressure { get; set; }
        public AddUnit? ElevationChange { get; set; }


        public FlowDirection FlowDirection { get; set; }
        public PipeAccesorySectionType SectionType { get; set; }

        public int? paMaterialId { get; set; }
        public int? paDiameterId { get; set; }
        public int? paPipeClassId { get; set; }
    }
    public class UpdatePipeAccesory
    {


        public string Name { get; set; } = string.Empty;
        public int? pPipingItemId { get; set; }
      

        public int? paProcessFluidId { get; set; }

        public AddUnit? Friction { get; set; }
        public AddUnit? Reynold { get; set; }
        public AddUnit? LevelInlet { get; set; }
        public AddUnit? LevelOutlet { get; set; }
        public AddUnit? FrictionDropPressure { get; set; }
        public AddUnit? OverallDropPressure { get; set; }
        public AddUnit? ElevationChange { get; set; }


        public FlowDirection FlowDirection { get; set; }
        public PipeAccesorySectionType SectionType { get; set; }

        public int? paMaterialId { get; set; }
        public int? paDiameterId { get; set; }
        public int? paPipeClassId { get; set; }
    }

}
