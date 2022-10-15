

namespace CPTool.Application.Features.TaxCodeLDFeatures
{
    public class DeleteTaxCodeLD : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeleteTaxCodeLDHandler : IRequestHandler<DeleteTaxCodeLD, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteTaxCodeLD> _logger;

        public DeleteTaxCodeLDHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteTaxCodeLD> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteTaxCodeLD request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<TaxCodeLD>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(TaxCodeLD), request.Id);

            }
            _unitofwork.Repository<TaxCodeLD>().Delete(ToDelete);
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
