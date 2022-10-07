

namespace CPTool.Application.Features.MeasuredVariableModifierFeatures.Command.Delete
{
    public class DeleteMeasuredVariableModifierCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteMeasuredVariableModifierCommandHandler : IRequestHandler<DeleteMeasuredVariableModifierCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteMeasuredVariableModifierCommand> _logger;

        public DeleteMeasuredVariableModifierCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteMeasuredVariableModifierCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteMeasuredVariableModifierCommand request, CancellationToken cancellationToken)
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
