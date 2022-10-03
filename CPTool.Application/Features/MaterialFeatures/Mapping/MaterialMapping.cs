



using CPTool.Application.Features.MaterialFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MaterialFeatures.Mapping
{
    internal class MaterialMapping : Profile
    {
        public MaterialMapping()
        {
            CreateMap<Material, AddEditMaterialCommand>();

            CreateMap<AddEditMaterialCommand, Material>();
        }
    }
}
