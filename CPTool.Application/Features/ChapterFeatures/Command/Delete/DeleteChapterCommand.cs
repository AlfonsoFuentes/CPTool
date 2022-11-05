

using CPTool.Application.Features.Base.Delete;

namespace CPTool.Application.Features.ChapterFeatures
{
    public class DeleteChapter : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteChapterHandler : IRequestHandler<DeleteChapter, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteChapter> _logger;

        public DeleteChapterHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteChapter> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteChapter request, CancellationToken cancellationToken)
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
