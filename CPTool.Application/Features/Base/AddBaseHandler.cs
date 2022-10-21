

namespace CPTool.Application.Features.Base
{
    //public class AddBaseHandler<TAdd, TEntity> where TAdd : AddCommand where TEntity : BaseDomainModel
    //{
    //    protected IUnitOfWork _unitOfWork;
    //    protected readonly IMapper _mapper;
    //    protected readonly IEmailService _emailService;
    //    protected readonly ILogger<TAdd> _logger;

    //    public AddBaseHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, ILogger<TAdd> logger)
    //    {
    //        _unitOfWork = unitOfWork;
    //        _mapper = mapper;
    //        _emailService = emailService;
    //        _logger = logger;
    //    }

    //    public virtual async Task<Result<int>> Handle(TAdd command, CancellationToken cancellationToken)
    //    {


    //        try
    //        {
    //            var table = _mapper.Map<TEntity>(command);
    //            _unitOfWork.Repository<TEntity>().Add(table);
    //            await _unitOfWork.Complete();

    //            return await Result<int>.SuccessAsync(table.Id, $"{table.Name} Added to {nameof(TEntity)}");
    //        }
    //        catch (Exception ex)
    //        {
    //            return await Result<int>.FailAsync(ex.Message);
    //        }
    //    }
    //}
}
