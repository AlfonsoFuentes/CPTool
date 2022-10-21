



namespace CPTool.Application.Features.MMOTypeFeatures.Mapping
{
    internal class MWOTypeMapping : Profile
    {
        public MWOTypeMapping()
        {
            CreateMap<MWOType,EditMWOType>();
            CreateMap<EditMWOType, MWOType>();
            CreateMap<AddMWOType, MWOType>();
            CreateMap<EditMWOType, AddMWOType>();
        }
    }
}
