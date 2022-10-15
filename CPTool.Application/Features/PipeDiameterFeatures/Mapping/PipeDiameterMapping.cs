



using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;

namespace CPTool.Application.Features.PipeDiameterFeatures.Mapping
{
    internal class PipeDiameterMapping : Profile
    {
        public PipeDiameterMapping()
        {
            CreateMap<PipeDiameter, EditPipeDiameter>();
            CreateMap<EditPipeDiameter, PipeDiameter>();
            CreateMap<AddPipeDiameter, PipeDiameter>();
        }
    }
}
