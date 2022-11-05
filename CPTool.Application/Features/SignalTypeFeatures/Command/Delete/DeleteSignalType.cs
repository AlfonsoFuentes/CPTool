

namespace CPTool.Application.Features.SignalTypesFeatures
{
    public class DeleteSignalType : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteSignalTypeHandler : IRequestHandler<DeleteSignalType, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteSignalType> _logger;

        public DeleteSignalTypeHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteSignalType> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteSignalType request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<SignalType>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(SignalType), request.Id);

            }
            _unitofwork.Repository<SignalType>().Delete(ToDelete);
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
