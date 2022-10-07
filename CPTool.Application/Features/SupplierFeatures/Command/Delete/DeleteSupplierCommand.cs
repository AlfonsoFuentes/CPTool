﻿




namespace CPTool.Application.Features.SupplierFeatures.Command.Delete
{
    public class DeleteSupplierCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteSupplierCommand> _logger;

        public DeleteSupplierCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteSupplierCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<Supplier>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(Supplier), request.Id);

            }
            _unitofwork.Repository<Supplier>().Delete(ToDelete);
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