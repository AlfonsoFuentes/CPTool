



using CPTool.Application.Features.MaterialFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MaterialFeatures.Mapping
{
    internal class MaterialMapping : Profile
    {
        public MaterialMapping()
        {
            CreateMap<Material, AddEditMaterialCommand>()

                .ForMember(dest => dest.InstrumentItemInnerMaterialsCommand, act => { act.PreCondition(src => (src.InstrumentItemInnerMaterials != null)); act.MapFrom(src => src.InstrumentItemInnerMaterials); })

                .ForMember(dest => dest.InstrumentItemOuterMaterialsCommand, act => { act.PreCondition(src => (src.InstrumentItemOuterMaterials != null)); act.MapFrom(src => src.InstrumentItemOuterMaterials); })

                .ForMember(dest => dest.EquipmentItemInnerMaterialsCommand, act => { act.PreCondition(src => (src.EquipmentItemInnerMaterials != null)); act.MapFrom(src => src.EquipmentItemInnerMaterials); })

                .ForMember(dest => dest.EquipmentItemOuterMaterialsCommand, act => { act.PreCondition(src => (src.EquipmentItemOuterMaterials != null)); act.MapFrom(src => src.EquipmentItemOuterMaterials); })
            .ForMember(dest => dest.PipingItemsCommand, act => { act.PreCondition(src => (src.PipingItems != null)); act.MapFrom(src => src.PipingItems); })
                .ForMember(dest => dest.NozzlesCommand, act => { act.PreCondition(src => (src.Nozzles != null)); act.MapFrom(src => src.Nozzles); });

            CreateMap<AddEditMaterialCommand, Material>();
        }
    }
}
