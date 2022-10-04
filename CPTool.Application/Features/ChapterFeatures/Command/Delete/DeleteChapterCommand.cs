

namespace CPTool.Application.Features.ChapterFeatures.Command.Delete
{
    public class DeleteChapterCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteChapterCommandHandler : IRequestHandler<DeleteChapterCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteChapterCommand> _logger;

        public DeleteChapterCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteChapterCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteChapterCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<Chapter>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(Chapter), request.Id);

            }
            _unitofwork.Repository<Chapter>().Delete(ToDelete);
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
