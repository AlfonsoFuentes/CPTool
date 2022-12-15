using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;


namespace CPTool.Application.Features.TaxCodeLDFeatures
{
    internal class AddEditTaxCodeLDHandler : CommandHandler<EditTaxCodeLD, AddTaxCodeLD, TaxCodeLD>, IRequestHandler<EditTaxCodeLD, Result<int>>
    {

        public AddEditTaxCodeLDHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteTaxCodeLDHandler : DeleteCommandHandler<EditTaxCodeLD, TaxCodeLD>, IRequestHandler<DeleteCommand<EditTaxCodeLD>, IResult>
    {

        public DeleteTaxCodeLDHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListTaxCodeLDHandler : QueryListHandler<EditTaxCodeLD, TaxCodeLD>, IRequestHandler<QueryList<EditTaxCodeLD>, List<EditTaxCodeLD>>
    {

        public GetListTaxCodeLDHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditTaxCodeLD>> Handle(QueryList<EditTaxCodeLD> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryTaxCodeLD.GetAllAsync();

            return _mapper.Map<List<EditTaxCodeLD>>(list);

        }
    }
    internal class QueryIdTaxCodeLDHandler : QueryIdHandler<EditTaxCodeLD, TaxCodeLD>, IRequestHandler<QueryId<EditTaxCodeLD>, EditTaxCodeLD>

    {


        public QueryIdTaxCodeLDHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditTaxCodeLD> Handle(QueryId<EditTaxCodeLD> request, CancellationToken cancellationToken)
        {
            EditTaxCodeLD result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryTaxCodeLD.GetByIdAsync(request.Id);


                result = _mapper.Map<EditTaxCodeLD>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelTaxCodeLDHandler : QueryExcelHandler<EditTaxCodeLD>, IRequestHandler<QueryExcel<EditTaxCodeLD>, QueryExcel<EditTaxCodeLD>>

    {


        public QueryExcelTaxCodeLDHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
