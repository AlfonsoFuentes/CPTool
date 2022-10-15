

namespace CPTool.Application.Features.VendorCodeFeatures
{
    public class DeleteVendorCode : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeleteVendorCodeHandler : IRequestHandler<DeleteVendorCode, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteVendorCode> _logger;

        public DeleteVendorCodeHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteVendorCode> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteVendorCode request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<VendorCode>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(VendorCode), request.Id);

            }
            _unitofwork.Repository<VendorCode>().Delete(ToDelete);
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
