

namespace CPTool.Application.Features.ElectricalItemFeatures.Command.Delete
{
    public class DeleteElectricalItemCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteElectricalItemCommandHandler : IRequestHandler<DeleteElectricalItemCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteElectricalItemCommand> _logger;

        public DeleteElectricalItemCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteElectricalItemCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteElectricalItemCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<ElectricalItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(ElectricalItem), request.Id);

            }
            _unitofwork.Repository<ElectricalItem>().Delete(ToDelete);
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
