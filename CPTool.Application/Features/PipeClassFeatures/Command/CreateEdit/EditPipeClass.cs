using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.PipeClassFeatures.CreateEdit
{
    public class EditPipeClass : EditCommand, IRequest<Result<int>>
    {

        public List<EditPipingItem>? PipingItems { get; set; } = new();
        public List<EditNozzle>? Nozzles { get; set; } = new();
        public List<EditPipeDiameter> PipeDiameters { get; set; } = new();

        public override T AddDetailtoMaster<T>()
        {
            AddPipeDiameter detail = new();
            detail.PipeClass = this;


            return (detail as T)!;
        }
        public string ValidatePipeDiameterName(string arg)
        {
            if (arg == null || arg == "")
                return null!;
            if (PipeDiameters.Any(x => x.Name == arg))
                return $"Diameter: {arg} is in the list";

            return null!;
        }
    }
}
