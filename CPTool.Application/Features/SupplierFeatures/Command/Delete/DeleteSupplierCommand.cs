




namespace CPTool.Application.Features.SupplierFeatures
{
    public class DeleteSupplier : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeleteSupplierHandler : IRequestHandler<DeleteSupplier, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteSupplier> _logger;

        public DeleteSupplierHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteSupplier> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteSupplier request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<Supplier>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(Supplier), request.Id);

            }
            _unitofwork.Repository<Supplier>().Delete(ToDelete);
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
