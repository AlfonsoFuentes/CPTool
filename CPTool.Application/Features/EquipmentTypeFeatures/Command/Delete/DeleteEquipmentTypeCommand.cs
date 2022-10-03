



using CPtool.ExtensionMethods;
using CPTool.Application.Features.EquipmentTypeFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.EquipmentTypeFeatures.Command.Delete
{
    public class DeleteEquipmentTypeCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteEquipmentTypeCommandHandler : IRequestHandler<DeleteEquipmentTypeCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteEquipmentTypeCommand> _logger;

        public DeleteEquipmentTypeCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteEquipmentTypeCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteEquipmentTypeCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<EquipmentType>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(EquipmentType), request.Id);

            }
            _unitofwork.Repository<EquipmentType>().Delete(ToDelete);
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
