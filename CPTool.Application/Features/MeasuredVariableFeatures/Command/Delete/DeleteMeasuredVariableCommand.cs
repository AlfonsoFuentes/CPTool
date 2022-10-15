

namespace CPTool.Application.Features.MeasuredVariableFeatures
{
    public class DeleteMeasuredVariable : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeleteMeasuredVariableHandler : IRequestHandler<DeleteMeasuredVariable, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteMeasuredVariable> _logger;

        public DeleteMeasuredVariableHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteMeasuredVariable> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteMeasuredVariable request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<MeasuredVariable>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(MeasuredVariable), request.Id);

            }
            _unitofwork.Repository<MeasuredVariable>().Delete(ToDelete);
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
