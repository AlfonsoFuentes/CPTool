

namespace CPTool.Application.Features.EngineeringCostItemFeatures.Command.Delete
{
    public class DeleteEngineeringCostItemCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteEngineeringCostItemCommandHandler : IRequestHandler<DeleteEngineeringCostItemCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteEngineeringCostItemCommand> _logger;

        public DeleteEngineeringCostItemCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteEngineeringCostItemCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteEngineeringCostItemCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<EngineeringCostItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(EngineeringCostItem), request.Id);

            }
            _unitofwork.Repository<EngineeringCostItem>().Delete(ToDelete);
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
