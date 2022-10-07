

namespace CPTool.Application.Features.InstrumentItemFeatures.Command.Delete
{
    public class DeleteInstrumentItemCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteInstrumentItemCommandHandler : IRequestHandler<DeleteInstrumentItemCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteInstrumentItemCommand> _logger;

        public DeleteInstrumentItemCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteInstrumentItemCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteInstrumentItemCommand request, CancellationToken cancellationToken)
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
