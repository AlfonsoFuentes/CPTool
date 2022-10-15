

namespace CPTool.Application.Features.InsulationItemFeatures
{
    public class DeleteInsulationItem : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeleteInsulationItemHandler : IRequestHandler<DeleteInsulationItem, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteInsulationItem> _logger;

        public DeleteInsulationItemHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteInsulationItem> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteInsulationItem request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<InsulationItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(InsulationItem), request.Id);

            }
            _unitofwork.Repository<InsulationItem>().Delete(ToDelete);
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
