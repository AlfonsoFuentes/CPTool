namespace CPTool.Application.Features.EquipmentTypeSubFeatures.Command.Delete
{
    public class DeleteEquipmentTypeSubCommand : DeleteCommand, IRequest<Result<int>>
    {
       
    }
    public class DeleteEquipmentTypeSubCommandHandler : IRequestHandler<DeleteEquipmentTypeSubCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteEquipmentTypeSubCommand> _logger;

        public DeleteEquipmentTypeSubCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteEquipmentTypeSubCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteEquipmentTypeSubCommand request, CancellationToken cancellationToken)
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
