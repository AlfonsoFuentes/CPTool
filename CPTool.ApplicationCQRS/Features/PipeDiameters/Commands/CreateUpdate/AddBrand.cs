using CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate
{
    public class AddPipeDiameter
    {

       
        public string Name { get; set; } = string.Empty;
        public AddUnit? OuterDiameter { get; set; }
        public AddUnit? InternalDiameter { get; set; }
        public AddUnit? Thickness { get; set; }

        public int? dPipeClassId { get; set; }
    }

}
