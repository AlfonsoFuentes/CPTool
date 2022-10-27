

namespace CPTool.Application.Features.PipeDiameterFeatures
{
    public class DeletePipeDiameter : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeletePipeDiameterHandler : IRequestHandler<DeletePipeDiameter, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeletePipeDiameter> _logger;

        public DeletePipeDiameterHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeletePipeDiameter> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeletePipeDiameter request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<PipeDiameter>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(PipeDiameter), request.Id);

            }
            _unitofwork.Repository<PipeDiameter>().Delete(ToDelete);
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
