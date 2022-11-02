

namespace CPTool.Application.Features.TaksFeatures
{
    public class DeleteTaks : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteTaksHandler : IRequestHandler<DeleteTaks, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteTaks> _logger;

        public DeleteTaksHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteTaks> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteTaks request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<Taks>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(Taks), request.Id);

            }
            _unitofwork.Repository<Taks>().Delete(ToDelete);
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
