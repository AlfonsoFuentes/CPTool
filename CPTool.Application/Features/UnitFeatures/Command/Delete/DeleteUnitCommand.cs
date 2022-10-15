

namespace CPTool.Application.Features.UnitFeatures
{
    public class DeleteUnit : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeleteUnitHandler : IRequestHandler<DeleteUnit, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteUnit> _logger;

        public DeleteUnitHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteUnit> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteUnit request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<CPTool.Domain.Entities.Unit>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(Unit), request.Id);

            }
            _unitofwork.Repository<CPTool.Domain.Entities.Unit>().Delete(ToDelete);
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
