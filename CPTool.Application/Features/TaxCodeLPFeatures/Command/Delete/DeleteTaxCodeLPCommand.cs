

namespace CPTool.Application.Features.TaxCodeLPFeatures
{
    public class DeleteTaxCodeLP : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteTaxCodeLPHandler : IRequestHandler<DeleteTaxCodeLP, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteTaxCodeLP> _logger;

        public DeleteTaxCodeLPHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteTaxCodeLP> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteTaxCodeLP request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<TaxCodeLP>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(TaxCodeLP), request.Id);

            }
            _unitofwork.Repository<TaxCodeLP>().Delete(ToDelete);
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
