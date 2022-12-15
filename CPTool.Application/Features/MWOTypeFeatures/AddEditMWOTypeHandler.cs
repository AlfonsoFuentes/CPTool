

namespace CPTool.Application.Features.MWOTypeFeatures
{
    internal class AddEditMWOTypeHandler : CommandHandler<EditMWOType, AddMWOType, MWOType>, IRequestHandler<EditMWOType, Result<int>>
    {

        public AddEditMWOTypeHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteMWOTypeHandler : DeleteCommandHandler<EditMWOType, MWOType>, IRequestHandler<DeleteCommand<EditMWOType>, IResult>
    {

        public DeleteMWOTypeHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListMWOTypeHandler : QueryListHandler<EditMWOType, MWOType>, IRequestHandler<QueryList<EditMWOType>, List<EditMWOType>>
    {

        public GetListMWOTypeHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditMWOType>> Handle(QueryList<EditMWOType> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryMWOType.GetAllAsync();

            return _mapper.Map<List<EditMWOType>>(list);

        }
    }
    internal class QueryIdMWOTypeHandler : QueryIdHandler<EditMWOType, MWOType>, IRequestHandler<QueryId<EditMWOType>, EditMWOType>

    {


        public QueryIdMWOTypeHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditMWOType> Handle(QueryId<EditMWOType> request, CancellationToken cancellationToken)
        {
            EditMWOType result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryMWOType.GetByIdAsync(request.Id);


                result = _mapper.Map<EditMWOType>(table2);
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
