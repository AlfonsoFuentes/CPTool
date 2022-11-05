

namespace CPTool.Application.Features.UserRequirementTypeFeatures
{
    public class DeleteUserRequirementType : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteUserRequirementTypeHandler : IRequestHandler<DeleteUserRequirementType, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteUserRequirementType> _logger;

        public DeleteUserRequirementTypeHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteUserRequirementType> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteUserRequirementType request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<UserRequirementType>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(UserRequirementType), request.Id);

            }
            _unitofwork.Repository<UserRequirementType>().Delete(ToDelete);
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
