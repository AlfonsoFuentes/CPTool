

namespace CPTool.Application.Features.GasketsFeatures.Command.Delete
{
    public class DeleteGasketCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteGasketCommandHandler : IRequestHandler<DeleteGasketCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteGasketCommand> _logger;

        public DeleteGasketCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteGasketCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteGasketCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<Gasket>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(Gasket), request.Id);

            }
            _unitofwork.Repository<Gasket>().Delete(ToDelete);
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
