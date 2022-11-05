

namespace CPTool.Application.Features.UserFeatures
{
    public class DeleteRequestedBy : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteRequestedByHandler : IRequestHandler<DeleteRequestedBy, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteRequestedBy> _logger;

        public DeleteRequestedByHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteRequestedBy> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteRequestedBy request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<User>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(User), request.Id);

            }
            _unitofwork.Repository<User>().Delete(ToDelete);
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
