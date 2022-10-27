

namespace CPTool.Application.Features.GasketsFeatures
{
    public class DeleteGasket : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteGasketHandler : IRequestHandler<DeleteGasket, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteGasket> _logger;

        public DeleteGasketHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteGasket> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteGasket request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<Gasket>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(Gasket), request.Id);

            }
            _unitofwork.Repository<Gasket>().Delete(ToDelete);
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
