

namespace CPTool.Application.Features.UnitaryBasePrizeFeatures.Command.Delete
{
    public class DeleteUnitaryBasePrizeCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteUnitaryBasePrizeCommandHandler : IRequestHandler<DeleteUnitaryBasePrizeCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteUnitaryBasePrizeCommand> _logger;

        public DeleteUnitaryBasePrizeCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteUnitaryBasePrizeCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteUnitaryBasePrizeCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<UnitaryBasePrize>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(UnitaryBasePrize), request.Id);

            }
            _unitofwork.Repository<UnitaryBasePrize>().Delete(ToDelete);
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
