

namespace CPTool.Application.Features.PurchaseOrderFeatures
{
    public class DeletePurchaseOrder : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeletePurchaseOrderHandler : IRequestHandler<DeletePurchaseOrder, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeletePurchaseOrder> _logger;

        public DeletePurchaseOrderHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeletePurchaseOrder> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeletePurchaseOrder request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<PurchaseOrder>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(PurchaseOrder), request.Id);

            }
            _unitofwork.Repository<PurchaseOrder>().Delete(ToDelete);
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
