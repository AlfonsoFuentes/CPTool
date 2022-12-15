using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;

using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.PipeClassFeatures.CreateEdit
{
    public class EditPipeClass : EditCommand, IRequest<Result<int>>
    {
        public List<EditPipeDiameter>? PipeDiameters { get; set; } = new();

        public List<EditPipeAccesory>? PipeAccesorys { get; set; } = new();

        
    }
}
