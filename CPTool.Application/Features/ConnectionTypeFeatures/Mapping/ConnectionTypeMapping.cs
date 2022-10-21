



using CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit;

namespace CPTool.Application.Features.ConnectionTypeFeatures.Mapping
{
    internal class ConnectionTypeMapping : Profile
    {
        public ConnectionTypeMapping()
        {
            
            CreateMap<ConnectionType, EditConnectionType>();

            CreateMap<EditConnectionType, ConnectionType>();
            CreateMap<AddConnectionType, ConnectionType>();
            CreateMap<EditConnectionType, AddConnectionType>();
        }
    }
}
