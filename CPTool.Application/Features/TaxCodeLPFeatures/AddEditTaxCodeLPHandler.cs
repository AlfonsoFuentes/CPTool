using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;


namespace CPTool.Application.Features.TaxCodeLPFeatures
{
    internal class AddEditTaxCodeLPHandler : CommandHandler<EditTaxCodeLP, AddTaxCodeLP, TaxCodeLP>, IRequestHandler<EditTaxCodeLP, Result<int>>
    {

        public AddEditTaxCodeLPHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteTaxCodeLPHandler : DeleteCommandHandler<EditTaxCodeLP, TaxCodeLP>, IRequestHandler<DeleteCommand<EditTaxCodeLP>, IResult>
    {

        public DeleteTaxCodeLPHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListTaxCodeLPHandler : QueryListHandler<EditTaxCodeLP, TaxCodeLP>, IRequestHandler<QueryList<EditTaxCodeLP>, List<EditTaxCodeLP>>
    {

        public GetListTaxCodeLPHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditTaxCodeLP>> Handle(QueryList<EditTaxCodeLP> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryTaxCodeLP.GetAllAsync();

            return _mapper.Map<List<EditTaxCodeLP>>(list);

        }
    }
    internal class QueryIdTaxCodeLPHandler : QueryIdHandler<EditTaxCodeLP, TaxCodeLP>, IRequestHandler<QueryId<EditTaxCodeLP>, EditTaxCodeLP>

    {


        public QueryIdTaxCodeLPHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditTaxCodeLP> Handle(QueryId<EditTaxCodeLP> request, CancellationToken cancellationToken)
        {
            EditTaxCodeLP result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryTaxCodeLP.GetByIdAsync(request.Id);


                result = _mapper.Map<EditTaxCodeLP>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelTaxCodeLPHandler : QueryExcelHandler<EditTaxCodeLP>, IRequestHandler<QueryExcel<EditTaxCodeLP>, QueryExcel<EditTaxCodeLP>>

    {


        public QueryExcelTaxCodeLPHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
