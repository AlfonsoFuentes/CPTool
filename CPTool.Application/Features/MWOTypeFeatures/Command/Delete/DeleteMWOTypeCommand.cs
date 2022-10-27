

namespace CPTool.Application.Features.MMOTypeFeatures
{
    public class DeleteMWOType : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteMWOTypeHandler : IRequestHandler<DeleteMWOType, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteMWOType> _logger;

        public DeleteMWOTypeHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteMWOType> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteMWOType request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<MWOType>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(MWOType), request.Id);

            }
            _unitofwork.Repository<MWOType>().Delete(ToDelete);
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
