

namespace CPTool.Application.Features.PropertyPackageFeatures
{
    public class DeletePropertyPackage : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeleteProcessFluidHandler : IRequestHandler<DeletePropertyPackage, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeletePropertyPackage> _logger;

        public DeleteProcessFluidHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeletePropertyPackage> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeletePropertyPackage request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<ProcessFluid>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(ProcessFluid), request.Id);

            }
            _unitofwork.Repository<ProcessFluid>().Delete(ToDelete);
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
