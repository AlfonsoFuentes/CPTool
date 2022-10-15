

using CPTool.Application.Features.Base.DeleteCommand;

namespace CPTool.Application.Features.ContingencyItemFeatures
{
    public class DeleteContingencyItem : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeleteContingencyItemHandler : IRequestHandler<DeleteContingencyItem, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteContingencyItem> _logger;

        public DeleteContingencyItemHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteContingencyItem> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteContingencyItem request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<ContingencyItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(ContingencyItem), request.Id);

            }
            _unitofwork.Repository<ContingencyItem>().Delete(ToDelete);
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
