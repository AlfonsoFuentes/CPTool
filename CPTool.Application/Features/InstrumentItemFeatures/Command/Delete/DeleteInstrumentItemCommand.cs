

namespace CPTool.Application.Features.InstrumentItemFeatures
{
    public class DeleteInstrumentItem : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeleteInstrumentItemHandler : IRequestHandler<DeleteInstrumentItem, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteInstrumentItem> _logger;

        public DeleteInstrumentItemHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteInstrumentItem> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteInstrumentItem request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<InstrumentItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(InstrumentItem), request.Id);

            }
            _unitofwork.Repository<InstrumentItem>().Delete(ToDelete);
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
