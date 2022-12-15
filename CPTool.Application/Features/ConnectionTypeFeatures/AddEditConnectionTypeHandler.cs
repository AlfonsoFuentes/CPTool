using CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit;

namespace CPTool.Application.Features.ConnectionTypeFeatures
{
    internal class AddEditConnectionTypeHandler : CommandHandler<EditConnectionType, AddConnectionType, ConnectionType>, IRequestHandler<EditConnectionType, Result<int>>
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
        public override async Task<List<EditConnectionType>> Handle(QueryList<EditConnectionType> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryConnectionType.GetAllAsync();

            return _mapper.Map<List<EditConnectionType>>(list);

        }
    }
    internal class QueryIdConnectionTypeHandler : QueryIdHandler<EditConnectionType, ConnectionType>, IRequestHandler<QueryId<EditConnectionType>, EditConnectionType>

    {


        public QueryIdConnectionTypeHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditConnectionType> Handle(QueryId<EditConnectionType> request, CancellationToken cancellationToken)
        {
            EditConnectionType result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryConnectionType.GetByIdAsync(request.Id);


                result = _mapper.Map<EditConnectionType>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelConnectionTypeHandler : QueryExcelHandler<EditConnectionType>, IRequestHandler<QueryExcel<EditConnectionType>, QueryExcel<EditConnectionType>>

    {


        public QueryExcelConnectionTypeHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
