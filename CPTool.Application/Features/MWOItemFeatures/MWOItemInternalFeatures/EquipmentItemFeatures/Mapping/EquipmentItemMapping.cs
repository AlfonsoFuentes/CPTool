using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.EquipmentItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.EquipmentItemFeatures.Mapping
{
    internal class EquipmentItemMapping : Profile
    {
        public EquipmentItemMapping()
        {
            CreateMap<EquipmentItem, AddEditEquipmentItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => src.MWOItems != null); act.MapFrom(src => src.MWOItems); });
              


            CreateMap<AddEditEquipmentItemCommand, EquipmentItem>();
        }
    }

}
