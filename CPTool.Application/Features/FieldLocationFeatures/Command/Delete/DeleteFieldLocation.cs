

namespace CPTool.Application.Features.FieldLocationsFeatures
{
    public class DeleteFieldLocation : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteFieldLocationHandler : IRequestHandler<DeleteFieldLocation, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteFieldLocation> _logger;

        public DeleteFieldLocationHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteFieldLocation> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteFieldLocation request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<FieldLocation>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(FieldLocation), request.Id);

            }
            _unitofwork.Repository<FieldLocation>().Delete(ToDelete);
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
