using CPTool.Application.Features.WireFeatures.CreateEdit;


namespace CPTool.Application.Features.WireFeatures
{
    internal class AddEditWireHandler : CommandHandler<EditWire, AddWire, Wire>, IRequestHandler<EditWire, Result<int>>
    {

        public AddEditWireHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteWireHandler : DeleteCommandHandler<EditWire, Wire>, IRequestHandler<DeleteCommand<EditWire>, IResult>
    {

        public DeleteWireHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListWireHandler : QueryListHandler<EditWire, Wire>, IRequestHandler<QueryList<EditWire>, List<EditWire>>
    {

        public GetListWireHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditWire>> Handle(QueryList<EditWire> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryWire.GetAllAsync();

            return _mapper.Map<List<EditWire>>(list);

        }
    }
    internal class QueryIdWireHandler : QueryIdHandler<EditWire, Wire>, IRequestHandler<QueryId<EditWire>, EditWire>

    {


        public QueryIdWireHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditWire> Handle(QueryId<EditWire> request, CancellationToken cancellationToken)
        {
            EditWire result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryWire.GetByIdAsync(request.Id);


                result = _mapper.Map<EditWire>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelWireHandler : QueryExcelHandler<EditWire>, IRequestHandler<QueryExcel<EditWire>, QueryExcel<EditWire>>

    {


        public QueryExcelWireHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
