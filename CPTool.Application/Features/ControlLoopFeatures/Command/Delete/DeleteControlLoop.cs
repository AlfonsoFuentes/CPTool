

namespace CPTool.Application.Features.ControlLoopFeatures
{
    public class DeleteControlLoop : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteControlLoopHandler : IRequestHandler<DeleteControlLoop, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteControlLoop> _logger;

        public DeleteControlLoopHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteControlLoop> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteControlLoop request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<ControlLoop>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(ControlLoop), request.Id);

            }
            _unitofwork.Repository<ControlLoop>().Delete(ToDelete);
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
