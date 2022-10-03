

namespace CPTool.Application.Features.MaterialFeatures.Command.Delete
{
    public class DeleteMaterialCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteMaterialCommand> _logger;

        public DeleteMaterialCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteMaterialCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<Material>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(Material), request.Id);

            }
            _unitofwork.Repository<Material>().Delete(ToDelete);
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
