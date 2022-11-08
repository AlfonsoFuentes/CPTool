

namespace CPTool.Application.Features.SignalModifiersFeatures
{
    public class DeleteSignalModifier : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteSignalModifierHandler : IRequestHandler<DeleteSignalModifier, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteSignalModifier> _logger;

        public DeleteSignalModifierHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteSignalModifier> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteSignalModifier request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<SignalModifier>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(SignalModifier), request.Id);

            }
            _unitofwork.Repository<SignalModifier>().Delete(ToDelete);
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
