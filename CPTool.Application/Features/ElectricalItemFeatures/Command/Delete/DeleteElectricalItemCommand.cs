

namespace CPTool.Application.Features.ElectricalItemFeatures
{
    //public class DeleteElectricalItem : Delete, IRequest<Result<int>> 
    //{
      
    //}
    //public class DeleteElectricalItemHandler : IRequestHandler<DeleteElectricalItem, Result<int>>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    private readonly ILogger<DeleteElectricalItem> _logger;

    //    public DeleteElectricalItemHandler(IUnitOfWork unitofwork,
    //        IMapper mapper,
    //        ILogger<DeleteElectricalItem> logger)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;


    //        _logger = logger;
    //    }

    //    public async Task<Result<int>> Handle(DeleteElectricalItem request, CancellationToken cancellationToken)
    //    {
    //        var ToDelete = await _unitofwork.Repository<ElectricalItem>().GetByIdAsync(request.Id);

    //        if (ToDelete == null)
    //        {
              
    //            _logger.LogError($"Not found {request.Id}");
    //            return await Result<int>.FailAsync($"Not found {request.Id}");
    //            throw new NotFoundException(nameof(ElectricalItem), request.Id);

    //        }
    //        _unitofwork.Repository<ElectricalItem>().Delete(ToDelete);
    //        var result = await _unitofwork.Complete();
    //        if (result <= 0)
    //        {
    //            return await Result<int>.FailAsync($"Not deleted {request.Id}");
    //        }
    //        _logger.LogInformation($"Deleted {request.Id}");
    //        return await Result<int>.SuccessAsync(request.Id, $"Deleted {request.Id}");
    //    }
    //}
}
