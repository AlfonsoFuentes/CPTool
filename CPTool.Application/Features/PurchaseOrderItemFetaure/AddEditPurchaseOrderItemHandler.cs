

using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;


namespace CPTool.Application.Features.PurchaseOrderItemFetaure
{
    internal class AddEditPurchaseOrderItemHandler : CommandHandler<EditPurchaseOrderItem, AddPurchaseOrderItem, PurchaseOrderItem>, IRequestHandler<EditPurchaseOrderItem, Result<int>>
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
        public override async Task<List<EditPurchaseOrderItem>> Handle(QueryList<EditPurchaseOrderItem> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryPurchaseOrderItem.GetAllAsync();

            return _mapper.Map<List<EditPurchaseOrderItem>>(list);

        }

    }
    internal class QueryIdPurchaseOrderItemHandler : QueryIdHandler<EditPurchaseOrderItem, PurchaseOrderItem>, IRequestHandler<QueryId<EditPurchaseOrderItem>, EditPurchaseOrderItem>

    {


        public QueryIdPurchaseOrderItemHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditPurchaseOrderItem> Handle(QueryId<EditPurchaseOrderItem> request, CancellationToken cancellationToken)
        {
            EditPurchaseOrderItem result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryPurchaseOrderItem.GetByIdAsync(request.Id);


                result = _mapper.Map<EditPurchaseOrderItem>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelPurchaseOrderItemHandler : QueryExcelHandler<EditPurchaseOrderItem>, IRequestHandler<QueryExcel<EditPurchaseOrderItem>, QueryExcel<EditPurchaseOrderItem>>

    {


        public QueryExcelPurchaseOrderItemHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
