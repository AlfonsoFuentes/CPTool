﻿

namespace CPTool.Application.Features.PaintingItemFeatures.Command.Delete
{
    public class DeletePaintingItemCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeletePaintingItemCommandHandler : IRequestHandler<DeletePaintingItemCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeletePaintingItemCommand> _logger;

        public DeletePaintingItemCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeletePaintingItemCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeletePaintingItemCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<PaintingItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(PaintingItem), request.Id);

            }
            _unitofwork.Repository<PaintingItem>().Delete(ToDelete);
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