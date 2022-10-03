



namespace CPTool.Application.Features.MMOTypeFeatures.Mapping
{
    internal class MWOTypeMapping : Profile
    {
        public MWOTypeMapping()
        {
            CreateMap<MWOType, AddEditMWOTypeCommand>()
                .ForMember(dest => dest.MWOs, act => { act.PreCondition(src => (src.MWOs != null)); act.MapFrom(src => src.MWOs); });
            ;

            CreateMap<AddEditMWOTypeCommand, MWOType>();
        }
    }
}
