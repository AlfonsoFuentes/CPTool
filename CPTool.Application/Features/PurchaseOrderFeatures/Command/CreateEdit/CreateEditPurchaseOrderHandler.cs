using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using MediatR;
using static System.Net.Mime.MediaTypeNames;

namespace CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit
{
    internal class CreateEditPurchaseOrderHandler : IRequestHandler<CreateEditPurchaseOrder, Result<int>>
    {
        protected IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly ILogger<CreateEditPurchaseOrder> _logger;

        public CreateEditPurchaseOrderHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateEditPurchaseOrder> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<int>> Handle(CreateEditPurchaseOrder request, CancellationToken cancellationToken)
        {

            var addcommandPurchaseOrder = _mapper.Map<AddPurchaseOrder>(request.PurchaseOrder);
            var table = _mapper.Map<PurchaseOrder>(addcommandPurchaseOrder);
           
            _unitOfWork.Repository<PurchaseOrder>().Add(table);

            await _unitOfWork.Complete();
            request.PurchaseOrder.Id = table.Id;
            await CreateTask(request.PurchaseOrder);
            foreach (var row in request.MWOItems)
            {
                PurchaseOrderMWOItem purchaseOrderMWOItem = new()
                {
                    PurchaseOrderId = table.Id,
                    MWOItemId = row.Id
                };
                _unitOfWork.Repository<PurchaseOrderMWOItem>().Add(purchaseOrderMWOItem);
                var mwoitem = await _unitOfWork.Repository<MWOItem>().GetByIdAsync(row.Id);
                if (mwoitem != null)
                {
                    //var addcommand = _mapper.Map<AddMWOItem>(row);
                    //_mapper.Map(addcommand, mwoitem, typeof(AddMWOItem), typeof(MWOItem));

                    //_unitOfWork.Repository<MWOItem>().Update(mwoitem);
                    var addMwoItemValue = _mapper.Map<AddMWOItemCurrencyValue>(row.MWOItemCurrencyValue);
                    var tableMwoItemValue = _mapper.Map<MWOItemCurrencyValue>(addMwoItemValue);
                    tableMwoItemValue.MWOItemId = mwoitem.Id;
                    tableMwoItemValue.PurchaseOrderId = table.Id;
                    _unitOfWork.Repository<MWOItemCurrencyValue>().Add(tableMwoItemValue);

                }


            }
            await _unitOfWork.Complete();
            return await Result<int>.SuccessAsync(table.Id, $"{table.Name} Added to {nameof(PurchaseOrder)}");
        }
        async Task CreateTask(EditPurchaseOrder purchaseOrder)
        {
            EditTaks editTaks = new();
            editTaks.MWO=purchaseOrder.MWO;
            editTaks.Name = $"Create PO from {purchaseOrder.PurchaseRequisition}";
            editTaks.PurchaseOrder = purchaseOrder;
            editTaks.TaksType = TaksType.Automatic;
            editTaks.CreatedDate = DateTime.Now;
            editTaks.TaksStatus = TaksStatus.Pending;
            var addcommandTaks = _mapper.Map<AddTaks>(editTaks);
            var table = _mapper.Map<Taks>(addcommandTaks);

            _unitOfWork.Repository<Taks>().Add(table);

            await _unitOfWork.Complete();
        }
    }
}
