




namespace CPTool.Application.Features.BrandFeatures
{
    public class DeleteBrand : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeleteBrandHandler : IRequestHandler<DeleteBrand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteBrand> _logger;

        public DeleteBrandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteBrand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteBrand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<Brand>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(Brand), request.Id);

            }
            _unitofwork.Repository<Brand>().Delete(ToDelete);
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
