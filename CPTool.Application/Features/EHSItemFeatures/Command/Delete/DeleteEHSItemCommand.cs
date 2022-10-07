

namespace CPTool.Application.Features.EHSItemFeatures.Command.Delete
{
    public class DeleteEHSItemCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteEHSItemCommandHandler : IRequestHandler<DeleteEHSItemCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteEHSItemCommand> _logger;

        public DeleteEHSItemCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteEHSItemCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteEHSItemCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<EHSItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(EHSItem), request.Id);

            }
            _unitofwork.Repository<EHSItem>().Delete(ToDelete);
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
