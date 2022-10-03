

namespace CPTool.Application.Features.MWOItemFeatures.Command.Delete
{
    public class DeleteMWOItemCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteMWOItemCommandHandler : IRequestHandler<DeleteMWOItemCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteMWOItemCommand> _logger;

        public DeleteMWOItemCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteMWOItemCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteMWOItemCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<MWOItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(MWOItem), request.Id);

            }
            _unitofwork.Repository<MWOItem>().Delete(ToDelete);
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
