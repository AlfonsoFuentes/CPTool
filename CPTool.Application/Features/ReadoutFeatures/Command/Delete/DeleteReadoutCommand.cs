

namespace CPTool.Application.Features.ReadoutFeatures.Command.Delete
{
    public class DeleteReadoutCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteReadoutCommandHandler : IRequestHandler<DeleteReadoutCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteReadoutCommand> _logger;

        public DeleteReadoutCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteReadoutCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteReadoutCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<Readout>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(Readout), request.Id);

            }
            _unitofwork.Repository<Readout>().Delete(ToDelete);
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
