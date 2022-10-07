

namespace CPTool.Application.Features.FoundationItemFeatures.Command.Delete
{
    public class DeleteFoundationItemCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteFoundationItemCommandHandler : IRequestHandler<DeleteFoundationItemCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteFoundationItemCommand> _logger;

        public DeleteFoundationItemCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteFoundationItemCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteFoundationItemCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<FoundationItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(FoundationItem), request.Id);

            }
            _unitofwork.Repository<FoundationItem>().Delete(ToDelete);
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
