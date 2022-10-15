

namespace CPTool.Application.Features.MWOFeatures
{
    public class DeleteMWO : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeleteMWOHandler : IRequestHandler<DeleteMWO, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteMWO> _logger;

        public DeleteMWOHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteMWO> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteMWO request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<MWO>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(MWO), request.Id);

            }
            _unitofwork.Repository<MWO>().Delete(ToDelete);
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
