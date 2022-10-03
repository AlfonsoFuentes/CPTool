

namespace CPTool.Application.Features.VendorCodeFeatures.Command.Delete
{
    public class DeleteVendorCodeCommand : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteVendorCodeCommandHandler : IRequestHandler<DeleteVendorCodeCommand, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteVendorCodeCommand> _logger;

        public DeleteVendorCodeCommandHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteVendorCodeCommand> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteVendorCodeCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<VendorCode>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(VendorCode), request.Id);

            }
            _unitofwork.Repository<VendorCode>().Delete(ToDelete);
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
