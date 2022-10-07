

namespace CPTool.Application.Features.MeasuredVariableFeatures.Command.Delete
{
    public class DeleteMeasuredVariableCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteMeasuredVariableCommandHandler : IRequestHandler<DeleteMeasuredVariableCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteMeasuredVariableCommand> _logger;

        public DeleteMeasuredVariableCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteMeasuredVariableCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteMeasuredVariableCommand request, CancellationToken cancellationToken)
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
