



using CPTool.Application.Features.StructuralItemFeatures.CreateEdit;

namespace CPTool.Application.Features.StructuralItemFeatures.Mapping
{
    internal class StructuralItemMapping : Profile
    {
        public StructuralItemMapping()
        {
            CreateMap<StructuralItem, EditStructuralItem>();

            CreateMap<AddStructuralItem, StructuralItem>();
            CreateMap<EditStructuralItem, StructuralItem>();
        }
    }
}
