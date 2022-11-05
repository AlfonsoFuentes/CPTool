

namespace CPTool.Application.Features.UserRequirementFeatures
{
    public class DeleteUserRequirement : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteUserRequirementHandler : IRequestHandler<DeleteUserRequirement, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteUserRequirement> _logger;

        public DeleteUserRequirementHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteUserRequirement> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteUserRequirement request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<UserRequirement>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(UserRequirement), request.Id);

            }
            _unitofwork.Repository<UserRequirement>().Delete(ToDelete);
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
