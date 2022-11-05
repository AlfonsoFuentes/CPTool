

namespace CPTool.Application.Features.WireFeatures
{
    public class DeleteWire : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteWireHandler : IRequestHandler<DeleteWire, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteWire> _logger;

        public DeleteWireHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteWire> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteWire request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<Wire>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(Wire), request.Id);

            }
            _unitofwork.Repository<Wire>().Delete(ToDelete);
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
