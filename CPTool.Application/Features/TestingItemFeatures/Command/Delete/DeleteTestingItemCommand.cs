

namespace CPTool.Application.Features.TestingItemFeatures.Command.Delete
{
    public class DeleteTestingItemCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteTestingItemCommandHandler : IRequestHandler<DeleteTestingItemCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteTestingItemCommand> _logger;

        public DeleteTestingItemCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteTestingItemCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteTestingItemCommand request, CancellationToken cancellationToken)
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
