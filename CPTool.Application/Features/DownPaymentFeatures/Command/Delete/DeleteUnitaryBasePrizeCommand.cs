﻿

namespace CPTool.Application.Features.DownPaymentFeatures.Command.Delete
{
    public class DeleteDownPaymentCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteDownPaymentCommandHandler : IRequestHandler<DeleteDownPaymentCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteDownPaymentCommand> _logger;

        public DeleteDownPaymentCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteDownPaymentCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteDownPaymentCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<DownPayment>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(DownPayment), request.Id);

            }
            _unitofwork.Repository<DownPayment>().Delete(ToDelete);
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