using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.Query.GetById;
using CPTool.Application.Features.PipeAccesoryFeatures.Query.GetList;
using CPTool.Application.Features.PipeClassFeatures.Query.GetById;
using CPTool.Application.Features.PipeClassFeatures.Query.GetList;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.PipeClassFeatures.CreateEdit
{
    public class EditPipeClass : EditCommand, IRequest<Result<int>>
    {
         public List<EditPipeDiameter>? PipeDiameters { get; set; } = new();

        

        public override T AddDetailtoMaster<T>()
        {
            T detail = new();
            (detail as EditPipeDiameter)!.dPipeClass = this;
            return detail!;
        }
    }
}
