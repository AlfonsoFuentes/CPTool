

namespace CPTool.Application.Features.PipingItemFeatures
{
    public class DeletePipingItem : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeletePipingItemHandler : IRequestHandler<DeletePipingItem, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeletePipingItem> _logger;

        public DeletePipingItemHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeletePipingItem> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeletePipingItem request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<PipingItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(PipingItem), request.Id);

            }
            _unitofwork.Repository<PipingItem>().Delete(ToDelete);
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
