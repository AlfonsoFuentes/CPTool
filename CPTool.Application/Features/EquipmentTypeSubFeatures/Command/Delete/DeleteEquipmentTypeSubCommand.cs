namespace CPTool.Application.Features.EquipmentTypeSubFeatures
{
    public class DeleteEquipmentTypeSub : DeleteCommand, IRequest<Result<int>>
    {
       
    }
    public class DeleteEquipmentTypeSubHandler : IRequestHandler<DeleteEquipmentTypeSub, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteEquipmentTypeSub> _logger;

        public DeleteEquipmentTypeSubHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteEquipmentTypeSub> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteEquipmentTypeSub request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<EquipmentTypeSub>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {

                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(EquipmentTypeSub), request.Id);

            }
            _unitofwork.Repository<EquipmentTypeSub>().Delete(ToDelete);
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
