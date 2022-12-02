

using CPTool.Application.Features.Base.Delete;

namespace CPTool.Application.Features.MWOItemFeatures
{
    
    public class DeletePurchaseOrderItem : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeletePurchaseOrderItemHandler : IRequestHandler<DeletePurchaseOrderItem, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<PurchaseOrderItem> _logger;

        public DeletePurchaseOrderItemHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<PurchaseOrderItem> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeletePurchaseOrderItem request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<PurchaseOrderItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(PurchaseOrderItem), request.Id);

            }
            _unitofwork.Repository<PurchaseOrderItem>().Delete(ToDelete);
            var result = await _unitofwork.Complete();
            if (result <= 0)
            {
                return await Result<int>.FailAsync($"Not deleted {request.Id}");
            }
            _logger.LogInformation($"Deleted {request.Id}");
            return await Result<int>.SuccessAsync(request.Id, $"Deleted {request.Id}");
        }
    }
}
