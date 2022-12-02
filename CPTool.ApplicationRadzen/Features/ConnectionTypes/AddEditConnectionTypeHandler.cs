using CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.ConnectionTypes
{
    internal class AddEditConnectionTypeHandler : CommandHandler<EditConnectionType, AddConnectionType, ConnectionType>, IRequestHandler<Command<EditConnectionType>, IResult>
    {

        public AddEditConnectionTypeHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteConnectionTypeHandler : DeleteCommandHandler<EditConnectionType, ConnectionType>, IRequestHandler<DeleteCommand<EditConnectionType>, IResult>
    {

        public DeleteConnectionTypeHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListConnectionTypeHandler : QueryListHandler<EditConnectionType, ConnectionType>, IRequestHandler<QueryList<EditConnectionType>, List<EditConnectionType>>
    {

        public GetListConnectionTypeHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdConnectionTypeHandler : QueryIdHandler<EditConnectionType, ConnectionType>, IRequestHandler<QueryId<EditConnectionType>, EditConnectionType>

    {


        public QueryIdConnectionTypeHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
