

namespace CPTool.Application.Features.SignalsFeatures
{
    public class DeleteSignal : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteSignalHandler : IRequestHandler<DeleteSignal, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteSignal> _logger;

        public DeleteSignalHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteSignal> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteSignal request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<Signal>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(Signal), request.Id);

            }
            _unitofwork.Repository<Signal>().Delete(ToDelete);
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
