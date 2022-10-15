

namespace CPTool.Application.Features.DeviceFunctionFeatures
{
    public class DeleteDeviceFunction : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeleteDeviceFunctionHandler : IRequestHandler<DeleteDeviceFunction, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteDeviceFunction> _logger;

        public DeleteDeviceFunctionHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteDeviceFunction> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteDeviceFunction request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<DeviceFunction>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(DeviceFunction), request.Id);

            }
            _unitofwork.Repository<DeviceFunction>().Delete(ToDelete);
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
