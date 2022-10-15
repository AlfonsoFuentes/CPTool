

namespace CPTool.Application.Features.MeasuredVariableModifierFeatures
{
    public class DeleteMeasuredVariableModifier : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeleteMeasuredVariableModifierHandler : IRequestHandler<DeleteMeasuredVariableModifier, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteMeasuredVariableModifier> _logger;

        public DeleteMeasuredVariableModifierHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteMeasuredVariableModifier> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteMeasuredVariableModifier request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<MeasuredVariableModifier>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(MeasuredVariableModifier), request.Id);

            }
            _unitofwork.Repository<MeasuredVariableModifier>().Delete(ToDelete);
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
