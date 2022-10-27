

namespace CPTool.Application.Features.PipeAccesoryFeatures
{
    public class DeletePipeAccesory : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeletePipeAccesoryHandler : IRequestHandler<DeletePipeAccesory, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeletePipeAccesory> _logger;

        public DeletePipeAccesoryHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeletePipeAccesory> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeletePipeAccesory request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<PipeAccesory>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(PipeAccesory), request.Id);

            }
            _unitofwork.Repository<PipeAccesory>().Delete(ToDelete);
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
