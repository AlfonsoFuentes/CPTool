

namespace CPTool.Application.Features.FoundationItemFeatures
{
    public class DeleteFoundationItem : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteFoundationItemHandler : IRequestHandler<DeleteFoundationItem, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteFoundationItem> _logger;

        public DeleteFoundationItemHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteFoundationItem> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteFoundationItem request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<FoundationItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(FoundationItem), request.Id);

            }
            _unitofwork.Repository<FoundationItem>().Delete(ToDelete);
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
