﻿

namespace CPTool.Application.Features.StructuralItemFeatures.Command.Delete
{
    public class DeleteStructuralItemCommand : DeleteCommand, IRequest<Result<int>>
    {

    }
    public class DeleteStructuralItemCommandHandler : IRequestHandler<DeleteStructuralItemCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteStructuralItemCommand> _logger;

        public DeleteStructuralItemCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteStructuralItemCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteStructuralItemCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<StructuralItem>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(StructuralItem), request.Id);

            }
            _unitofwork.Repository<StructuralItem>().Delete(ToDelete);
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
