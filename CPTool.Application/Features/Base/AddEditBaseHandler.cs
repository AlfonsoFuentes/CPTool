

using CPTool.Application.Features.ChapterFeatures.CreateEdit;

namespace CPTool.Application.Features.Base
{
    public class AddEditBaseHandler<TAdd, TEdit, TEntity>: IRequestHandler<TEdit, Result<int>>
        where TAdd : AddCommand
        where TEdit : EditCommand
        where TEntity : BaseDomainModel
    {
        protected IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly ILogger<TEdit> _logger;

        public AddEditBaseHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TEdit> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public virtual async Task<Result<int>> Handle(TEdit command, CancellationToken cancellationToken)
        {


            try
            {
                if (command.Id == 0)
                {
                    var addcommand = _mapper.Map<TAdd>(command);
                    var table = _mapper.Map<TEntity>(addcommand);
                    _unitOfWork.Repository<TEntity>().Add(table);
                  
                    await _unitOfWork.Complete();
                    command.Id = table.Id;
                    return await Result<int>.SuccessAsync(table.Id, $"{table.Name} Added to {nameof(TEntity)}");
                }
                else
                {
                    var table = await _unitOfWork.Repository<TEntity>().GetByIdAsync(command.Id);
                    if (table != null)
                    {
                        var addcommand = _mapper.Map<TAdd>(command);
                        _mapper.Map(addcommand, table, typeof(TAdd), typeof(TEntity));

                        _unitOfWork.Repository<TEntity>().Update(table);
                        await _unitOfWork.Complete();
                        return await Result<int>.SuccessAsync(table.Id, $"{table.Name} Updated in {nameof(TEntity)}");
                    }
                    return await Result<int>.FailAsync("Not found!!");
                }



            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
