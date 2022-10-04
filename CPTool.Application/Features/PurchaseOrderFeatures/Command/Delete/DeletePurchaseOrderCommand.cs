

namespace CPTool.Application.Features.PurchaseOrderFeatures.Command.Delete
{
    public class DeletePurchaseOrderCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeletePurchaseOrderCommandHandler : IRequestHandler<DeletePurchaseOrderCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeletePurchaseOrderCommand> _logger;

        public DeletePurchaseOrderCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeletePurchaseOrderCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeletePurchaseOrderCommand request, CancellationToken cancellationToken)
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
