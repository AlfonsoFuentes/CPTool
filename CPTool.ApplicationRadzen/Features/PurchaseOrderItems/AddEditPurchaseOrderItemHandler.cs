using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;



namespace CPTool.ApplicationRadzen.Features.PurchaseOrderItems
{
    internal class AddEditPurchaseOrderItemHandler : CommandHandler<EditPurchaseOrderItem, AddPurchaseOrderItem, PurchaseOrderItem>, IRequestHandler<Command<EditPurchaseOrderItem>, IResult>
    {

        public AddEditPurchaseOrderItemHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeletePurchaseOrderItemHandler : DeleteCommandHandler<EditPurchaseOrderItem, PurchaseOrderItem>, IRequestHandler<DeleteCommand<EditPurchaseOrderItem>, IResult>
    {

        public DeletePurchaseOrderItemHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListPurchaseOrderItemHandler : QueryListHandler<EditPurchaseOrderItem, PurchaseOrderItem>, IRequestHandler<QueryList<EditPurchaseOrderItem>, List<EditPurchaseOrderItem>>
    {

        public GetListPurchaseOrderItemHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
       

    }
    internal class QueryIdPurchaseOrderItemHandler : QueryIdHandler<EditPurchaseOrderItem, PurchaseOrderItem>, IRequestHandler<QueryId<EditPurchaseOrderItem>, EditPurchaseOrderItem>

    {


        public QueryIdPurchaseOrderItemHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
