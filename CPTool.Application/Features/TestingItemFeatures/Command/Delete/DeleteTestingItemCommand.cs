

namespace CPTool.Application.Features.TestingItemFeatures
{
    public class DeleteTestingItem : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteTestingItemHandler : IRequestHandler<DeleteTestingItem, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteTestingItem> _logger;

        public DeleteTestingItemHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteTestingItem> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteTestingItem request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<TestingItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(TestingItem), request.Id);

            }
            _unitofwork.Repository<TestingItem>().Delete(ToDelete);
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
