

namespace CPTool.Application.Features.NozzleFeatures.Command.Delete
{
    public class DeleteNozzleCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteNozzleCommandHandler : IRequestHandler<DeleteNozzleCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteNozzleCommand> _logger;

        public DeleteNozzleCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteNozzleCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteNozzleCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<Nozzle>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(Nozzle), request.Id);

            }
            _unitofwork.Repository<Nozzle>().Delete(ToDelete);
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
