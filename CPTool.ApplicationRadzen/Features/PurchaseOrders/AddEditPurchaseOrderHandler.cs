using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.PurchaseOrders
{
    internal class AddEditPurchaseOrderHandler : CommandHandler<EditPurchaseOrder, AddPurchaseOrder, PurchaseOrder>, IRequestHandler<Command<EditPurchaseOrder>, IResult>
    {

        public AddEditPurchaseOrderHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeletePurchaseOrderHandler : DeleteCommandHandler<EditPurchaseOrder, PurchaseOrder>, IRequestHandler<DeleteCommand<EditPurchaseOrder>, IResult>
    {

        public DeletePurchaseOrderHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListPurchaseOrderHandler : QueryListHandler<EditPurchaseOrder, PurchaseOrder>, IRequestHandler<QueryList<EditPurchaseOrder>, List<EditPurchaseOrder>>
    {

        public GetListPurchaseOrderHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditPurchaseOrder>> Handle(QueryList<EditPurchaseOrder> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<PurchaseOrder>().GetAllAsync();
            list = list.OrderBy(x => x.PurchaseOrderStatus).ToList();
            return _mapper.Map<List<EditPurchaseOrder>>(list);


        }
    }
    internal class QueryIdPurchaseOrderHandler : QueryIdHandler<EditPurchaseOrder, PurchaseOrder>, IRequestHandler<QueryId<EditPurchaseOrder>, EditPurchaseOrder>

    {


        public QueryIdPurchaseOrderHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
