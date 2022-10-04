using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.EHSItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.EHSItemFeatures.Mapping
{
    internal class EHSItemMapping : Profile
    {
        public EHSItemMapping()
        {
            CreateMap<EHSItem, AddEditEHSItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => src.MWOItems != null); act.MapFrom(src => src.MWOItems); });
              


            CreateMap<AddEditEHSItemCommand, EHSItem>();
        }
    }

}
