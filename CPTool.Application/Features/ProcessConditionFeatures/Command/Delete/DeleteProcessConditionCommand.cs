

namespace CPTool.Application.Features.ProcessConditionFeatures
{
    public class DeleteProcessCondition : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeleteProcessConditionHandler : IRequestHandler<DeleteProcessCondition, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteProcessCondition> _logger;

        public DeleteProcessConditionHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteProcessCondition> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteProcessCondition request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<ProcessCondition>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(ProcessCondition), request.Id);

            }
            _unitofwork.Repository<ProcessCondition>().Delete(ToDelete);
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
