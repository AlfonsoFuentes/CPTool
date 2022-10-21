



using CPTool.Application.Features.PipeClassFeatures.CreateEdit;

namespace CPTool.Application.Features.PipeClassFeatures.Mapping
{
    internal class PipeClassMapping : Profile
    {
        public PipeClassMapping()
        {
            CreateMap<PipeClass, EditPipeClass>();
            CreateMap<EditPipeClass, PipeClass>();
            CreateMap<AddPipeClass, PipeClass>();
            CreateMap<EditPipeClass, AddPipeClass>();
        }
    }
}
