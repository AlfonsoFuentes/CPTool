
using CPTool.Application.Features.SignalTypesFeatures.CreateEdit;


namespace CPTool.Application.Features.SignalTypeFeatures
{
    internal class AddEditSignalTypeHandler : CommandHandler<EditSignalType, AddSignalType, SignalType>, IRequestHandler<EditSignalType, Result<int>>
    {

        public AddEditSignalTypeHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteSignalTypeHandler : DeleteCommandHandler<EditSignalType, SignalType>, IRequestHandler<DeleteCommand<EditSignalType>, IResult>
    {

        public DeleteSignalTypeHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListSignalTypeHandler : QueryListHandler<EditSignalType, SignalType>, IRequestHandler<QueryList<EditSignalType>, List<EditSignalType>>
    {

        public GetListSignalTypeHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditSignalType>> Handle(QueryList<EditSignalType> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositorySignalType.GetAllAsync();

            return _mapper.Map<List<EditSignalType>>(list);

        }
    }
    internal class QueryIdSignalTypeHandler : QueryIdHandler<EditSignalType, SignalType>, IRequestHandler<QueryId<EditSignalType>, EditSignalType>

    {


        public QueryIdSignalTypeHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditSignalType> Handle(QueryId<EditSignalType> request, CancellationToken cancellationToken)
        {
            EditSignalType result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositorySignalType.GetByIdAsync(request.Id);


                result = _mapper.Map<EditSignalType>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelMWOTypeHandler : QueryExcelHandler<EditMWOType>, IRequestHandler<QueryExcel<EditMWOType>, QueryExcel<EditMWOType>>

    {


        public QueryExcelMWOTypeHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
