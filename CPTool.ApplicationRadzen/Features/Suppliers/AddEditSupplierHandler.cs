using CPTool.Application.Features.SupplierFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.Suppliers
{
    internal class AddEditSupplierHandler : CommandHandler<EditSupplier, AddSupplier, Supplier>, IRequestHandler<Command<EditSupplier>, IResult>
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

    }
    internal class QueryIdSupplierHandler : QueryIdHandler<EditSupplier, Supplier>, IRequestHandler<QueryId<EditSupplier>, EditSupplier>

    {


        public QueryIdSupplierHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
