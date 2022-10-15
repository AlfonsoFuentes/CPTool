

namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures
{
    public class DeletePurchaseOrderMWOItem : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeletePurchaseOrderMWOItemHandler : IRequestHandler<DeletePurchaseOrderMWOItem, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeletePurchaseOrderMWOItem> _logger;

        public DeletePurchaseOrderMWOItemHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeletePurchaseOrderMWOItem> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeletePurchaseOrderMWOItem request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<PurchaseOrderMWOItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(PurchaseOrderMWOItem), request.Id);

            }
            _unitofwork.Repository<PurchaseOrderMWOItem>().Delete(ToDelete);
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
