using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.TaxCodeLDs
{
    internal class AddEditTaxCodeLDHandler : CommandHandler<EditTaxCodeLD, AddTaxCodeLD, TaxCodeLD>, IRequestHandler<Command<EditTaxCodeLD>, IResult>
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

    }
    internal class QueryIdTaxCodeLDHandler : QueryIdHandler<EditTaxCodeLD, TaxCodeLD>, IRequestHandler<QueryId<EditTaxCodeLD>, EditTaxCodeLD>

    {


        public QueryIdTaxCodeLDHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
