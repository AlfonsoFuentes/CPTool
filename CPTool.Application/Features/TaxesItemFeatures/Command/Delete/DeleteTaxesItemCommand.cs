

namespace CPTool.Application.Features.TaxesItemFeatures
{
    public class DeleteTaxesItem : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeleteTaxesItemHandler : IRequestHandler<DeleteTaxesItem, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteTaxesItem> _logger;

        public DeleteTaxesItemHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteTaxesItem> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteTaxesItem request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<TaxesItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(TaxesItem), request.Id);

            }
            _unitofwork.Repository<TaxesItem>().Delete(ToDelete);
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
