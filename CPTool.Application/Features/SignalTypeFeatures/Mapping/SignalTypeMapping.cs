



using CPTool.Application.Features.SignalTypesFeatures.CreateEdit;


namespace CPTool.Application.Features.SignalTypesFeatures.Mapping
{
    internal class SignalTypeMapping : Profile
    {
        public SignalTypeMapping()
        {
            CreateMap<SignalType, EditSignalType>();
            CreateMap<AddSignalType, SignalType>();
            CreateMap<EditSignalType, SignalType>();
            CreateMap<EditSignalType, AddSignalType>();
        }
    }
}
