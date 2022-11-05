
using CPTool.Application.Features.Base.Delete;

namespace CPTool.Application.Features.AlterationItemFeatures
{
    //public class DeleteAlterationItem : Delete, IRequest<Result<int>> 
    //{
      
    //}
    //public class DeleteAlterationItemHandler : IRequestHandler<DeleteAlterationItem, Result<int>>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    private readonly ILogger<DeleteAlterationItem> _logger;

    //    public DeleteAlterationItemHandler(IUnitOfWork unitofwork,
    //        IMapper mapper,
    //        ILogger<DeleteAlterationItem> logger)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;


    //        _logger = logger;
    //    }

    //    public async Task<Result<int>> Handle(DeleteAlterationItem request, CancellationToken cancellationToken)
    //    {
    //        var ToDelete = await _unitofwork.Repository<AlterationItem>().GetByIdAsync(request.Id);

    //        if (ToDelete == null)
    //        {
              
    //            _logger.LogError($"Not found {request.Id}");
    //            return await Result<int>.FailAsync($"Not found {request.Id}");
    //            throw new NotFoundException(nameof(AlterationItem), request.Id);

    //        }
    //        _unitofwork.Repository<AlterationItem>().Delete(ToDelete);
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
