

namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures.Command.Delete
{
    public class DeletePurchaseOrderMWOItemCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeletePurchaseOrderMWOItemCommandHandler : IRequestHandler<DeletePurchaseOrderMWOItemCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeletePurchaseOrderMWOItemCommand> _logger;

        public DeletePurchaseOrderMWOItemCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeletePurchaseOrderMWOItemCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeletePurchaseOrderMWOItemCommand request, CancellationToken cancellationToken)
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
