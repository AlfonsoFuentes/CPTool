

namespace CPTool.Application.Features.EquipmentItemFeatures.Command.Delete
{
    public class DeleteEquipmentItemCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteEquipmentItemCommandHandler : IRequestHandler<DeleteEquipmentItemCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteEquipmentItemCommand> _logger;

        public DeleteEquipmentItemCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteEquipmentItemCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteEquipmentItemCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<EquipmentItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(EquipmentItem), request.Id);

            }
            _unitofwork.Repository<EquipmentItem>().Delete(ToDelete);
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
