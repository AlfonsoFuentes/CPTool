using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.ElectricalItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.ElectricalItemFeatures.Mapping
{
    internal class ElectricalItemMapping : Profile
    {
        public ElectricalItemMapping()
        {
            CreateMap<ElectricalItem, AddEditElectricalItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => src.MWOItems != null); act.MapFrom(src => src.MWOItems); });
              


            CreateMap<AddEditElectricalItemCommand, ElectricalItem>();
        }
    }

}
