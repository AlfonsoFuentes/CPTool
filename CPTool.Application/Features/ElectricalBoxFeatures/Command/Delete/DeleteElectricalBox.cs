

namespace CPTool.Application.Features.ElectricalBoxsFeatures
{
    public class DeleteElectricalBox : DeleteCommand, IRequest<Result<int>> 
    {
      
    }
    public class DeleteElectricalBoxHandler : IRequestHandler<DeleteElectricalBox, Result<int>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<DeleteElectricalBox> _logger;

        public DeleteElectricalBoxHandler(IUnitOfWork unitofwork,
            IMapper mapper,
            ILogger<DeleteElectricalBox> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;


            _logger = logger;
        }

        public async Task<Result<int>> Handle(DeleteElectricalBox request, CancellationToken cancellationToken)
        {
            var ToDelete = await _unitofwork.Repository<ElectricalBox>().GetByIdAsync(request.Id);

            if (ToDelete == null)
            {
              
                _logger.LogError($"Not found {request.Id}");
                return await Result<int>.FailAsync($"Not found {request.Id}");
                throw new NotFoundException(nameof(ElectricalBox), request.Id);

            }
            _unitofwork.Repository<ElectricalBox>().Delete(ToDelete);
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
