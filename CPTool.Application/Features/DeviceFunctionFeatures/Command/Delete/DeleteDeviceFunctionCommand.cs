

namespace CPTool.Application.Features.DeviceFunctionFeatures.Command.Delete
{
    public class DeleteDeviceFunctionCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteDeviceFunctionCommandHandler : IRequestHandler<DeleteDeviceFunctionCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteDeviceFunctionCommand> _logger;

        public DeleteDeviceFunctionCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteDeviceFunctionCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteDeviceFunctionCommand request, CancellationToken cancellationToken)
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
