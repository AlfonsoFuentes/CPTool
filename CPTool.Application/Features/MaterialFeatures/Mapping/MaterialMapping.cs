



using CPTool.Application.Features.MaterialFeatures.CreateEdit;

namespace CPTool.Application.Features.MaterialFeatures.Mapping
{
    internal class MaterialMapping : Profile
    {
        public MaterialMapping()
        {
            CreateMap<Material, EditMaterial>();

            CreateMap<AddMaterial, Material>();
            CreateMap<EditMaterial, Material>();
        }
    }
}
