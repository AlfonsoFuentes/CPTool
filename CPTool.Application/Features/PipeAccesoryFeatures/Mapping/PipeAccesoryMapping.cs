



using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;

namespace CPTool.Application.Features.PipeAccesoryFeatures.Mapping
{
    internal class PipeAccesoryMapping : Profile
    {
        public PipeAccesoryMapping()
        {
            CreateMap<PipeAccesory, EditPipeAccesory>();

            CreateMap<EditPipeAccesory, PipeAccesory>();
            CreateMap<AddPipeAccesory, PipeAccesory>();
        }
    }
}
