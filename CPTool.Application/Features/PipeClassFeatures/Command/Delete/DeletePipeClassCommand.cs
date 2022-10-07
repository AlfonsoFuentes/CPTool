

namespace CPTool.Application.Features.PipeClassFeatures.Command.Delete
{
    public class DeletePipeClassCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeletePipeClassCommandHandler : IRequestHandler<DeletePipeClassCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeletePipeClassCommand> _logger;

        public DeletePipeClassCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeletePipeClassCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeletePipeClassCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<PipeClass>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(PipeClass), request.Id);

            }
            _unitofwork.Repository<PipeClass>().Delete(ToDelete);
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
