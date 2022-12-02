using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.TaxCodeLPs
{
    internal class AddEditTaxCodeLPHandler : CommandHandler<EditTaxCodeLP, AddTaxCodeLP, TaxCodeLP>, IRequestHandler<Command<EditTaxCodeLP>, IResult>
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

    }
    internal class QueryIdTaxCodeLPHandler : QueryIdHandler<EditTaxCodeLP, TaxCodeLP>, IRequestHandler<QueryId<EditTaxCodeLP>, EditTaxCodeLP>

    {


        public QueryIdTaxCodeLPHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
