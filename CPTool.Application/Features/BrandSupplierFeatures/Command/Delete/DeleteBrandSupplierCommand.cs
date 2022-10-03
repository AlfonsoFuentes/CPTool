

namespace CPTool.Application.Features.BrandSupplierFeatures.Command.Delete
{
    public class DeleteBrandSupplierCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteBrandSupplierCommandHandler : IRequestHandler<DeleteBrandSupplierCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteBrandSupplierCommand> _logger;

        public DeleteBrandSupplierCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteBrandSupplierCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteBrandSupplierCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<BrandSupplier>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(BrandSupplier), request.Id);

            }
            _unitofwork.Repository<BrandSupplier>().Delete(ToDelete);
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
