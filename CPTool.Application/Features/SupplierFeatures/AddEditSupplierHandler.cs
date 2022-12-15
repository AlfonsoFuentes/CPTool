using CPTool.Application.Features.SupplierFeatures.CreateEdit;



namespace CPTool.Application.Features.SupplierFeatures
{
    internal class AddEditSupplierHandler : CommandHandler<EditSupplier, AddSupplier, Supplier>, IRequestHandler<EditSupplier, Result<int>>
    {

        public AddEditSupplierHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteSupplierHandler : DeleteCommandHandler<EditSupplier, Supplier>, IRequestHandler<DeleteCommand<EditSupplier>, IResult>
    {

        public DeleteSupplierHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListSupplierHandler : QueryListHandler<EditSupplier, Supplier>, IRequestHandler<QueryList<EditSupplier>, List<EditSupplier>>
    {

        public GetListSupplierHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditSupplier>> Handle(QueryList<EditSupplier> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositorySupplier.GetAllAsync();

            return _mapper.Map<List<EditSupplier>>(list);

        }
    }
    internal class QueryIdSupplierHandler : QueryIdHandler<EditSupplier, Supplier>, IRequestHandler<QueryId<EditSupplier>, EditSupplier>

    {


        public QueryIdSupplierHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        //public override async Task<EditSupplier> Handle(QueryId<EditSupplier> request, CancellationToken cancellationToken)
        //{
        //    EditSupplier result = new();
        //    if (request.Id != 0)
        //    {
        //        var table2 = await _unitofwork.RepositorySupplier.GetByIdAsync(request.Id);


        //        result = _mapper.Map<EditSupplier>(table2);
        //    }

        //    return result;

        //}
    }
    internal class QueryExcelSupplierHandler : QueryExcelHandler<EditSupplier>, IRequestHandler<QueryExcel<EditSupplier>, QueryExcel<EditSupplier>>

    {


        public QueryExcelSupplierHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
