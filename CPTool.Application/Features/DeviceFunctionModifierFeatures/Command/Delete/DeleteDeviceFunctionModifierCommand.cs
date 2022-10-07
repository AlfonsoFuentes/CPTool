

namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.Command.Delete
{
    public class DeleteDeviceFunctionModifierCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteDeviceFunctionModifierCommandHandler : IRequestHandler<DeleteDeviceFunctionModifierCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteDeviceFunctionModifierCommand> _logger;

        public DeleteDeviceFunctionModifierCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteDeviceFunctionModifierCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteDeviceFunctionModifierCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<DeviceFunctionModifier>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(DeviceFunctionModifier), request.Id);

            }
            _unitofwork.Repository<DeviceFunctionModifier>().Delete(ToDelete);
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
