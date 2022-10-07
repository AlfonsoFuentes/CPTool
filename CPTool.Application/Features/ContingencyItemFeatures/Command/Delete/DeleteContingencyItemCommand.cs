

namespace CPTool.Application.Features.ContingencyItemFeatures.Command.Delete
{
    public class DeleteContingencyItemCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteContingencyItemCommandHandler : IRequestHandler<DeleteContingencyItemCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteContingencyItemCommand> _logger;

        public DeleteContingencyItemCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteContingencyItemCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteContingencyItemCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<ContingencyItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(ContingencyItem), request.Id);

            }
            _unitofwork.Repository<ContingencyItem>().Delete(ToDelete);
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
