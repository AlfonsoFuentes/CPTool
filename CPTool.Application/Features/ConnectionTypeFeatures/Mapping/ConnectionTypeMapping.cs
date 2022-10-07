



using CPTool.Application.Features.ConnectionTypeFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ConnectionTypeFeatures.Mapping
{
    internal class ConnectionTypeMapping : Profile
    {
        public ConnectionTypeMapping()
        {
            CreateMap<ConnectionType, AddEditConnectionTypeCommand>()
                .ForMember(dest => dest.NozzlesCommand, act => { act.PreCondition(src => (src.Nozzles != null)); act.MapFrom(src => src.Nozzles); });
           

            CreateMap<AddEditConnectionTypeCommand, ConnectionType>();
        }
    }
}
