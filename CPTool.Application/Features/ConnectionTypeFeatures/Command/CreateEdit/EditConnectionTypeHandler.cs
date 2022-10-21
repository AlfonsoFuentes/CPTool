namespace CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit
{
    internal class ConnectionTypeHandler : AddEditBaseHandler<AddConnectionType,EditConnectionType, ConnectionType>, IRequestHandler<EditConnectionType, Result<int>>
    {


        public ConnectionTypeHandler(IUnitOfWork unitofwork, IMapper mapper,  ILogger<EditConnectionType> logger)
             : base(unitofwork, mapper,  logger)
        {

        }


    }
}
