﻿

namespace CPTool.Application.Features.ConnectionTypeFeatures.Command.Delete
{
    public class DeleteConnectionTypeCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteConnectionTypeCommandHandler : IRequestHandler<DeleteConnectionTypeCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteConnectionTypeCommand> _logger;

        public DeleteConnectionTypeCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteConnectionTypeCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteConnectionTypeCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<ConnectionType>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(ConnectionType), request.Id);

            }
            _unitofwork.Repository<ConnectionType>().Delete(ToDelete);
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