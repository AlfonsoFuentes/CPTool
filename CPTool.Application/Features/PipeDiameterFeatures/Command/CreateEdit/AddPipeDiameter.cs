





using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.UnitsSystem;

namespace CPTool.Application.Features.PipeDiameterFeatures.CreateEdit
{
    public class AddPipeDiameter : AddCommand
    {
       

        
        public AddUnit? OuterDiameter { get; set; }
        public AddUnit? InternalDiameter { get; set; }
        public AddUnit? Thickness { get; set; }

        public int? dPipeClassId { get; set; }



    }

}
