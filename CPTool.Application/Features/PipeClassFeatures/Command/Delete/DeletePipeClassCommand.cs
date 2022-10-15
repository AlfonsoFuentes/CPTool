﻿

namespace CPTool.Application.Features.PipeClassFeatures
{
    public class DeletePipeClass : Delete, IRequest<Result<int>> 
    {
      
    }
    public class DeletePipeClassHandler : IRequestHandler<DeletePipeClass, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeletePipeClass> _logger;

        public DeletePipeClassHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeletePipeClass> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeletePipeClass request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<PipeClass>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(PipeClass), request.Id);

            }
            _unitofwork.Repository<PipeClass>().Delete(ToDelete);
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
