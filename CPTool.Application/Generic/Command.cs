

namespace CPTool.Application.Generic
{

   
    public class CommandHandler<TEdit, TAdd, TEntity> : IRequestHandler<TEdit, Result<int>>
        where TAdd : AddCommand
        where TEdit : EditCommand
        where TEntity : BaseDomainModel
    {

        protected readonly IMapper _mapper;
        protected IUnitOfWork _unitOfWork;

        public CommandHandler(IUnitOfWork unitofwork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitofwork;
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
                    return await Result<int>.SuccessAsync($"{table.Name} Added to {nameof(TEntity)}");
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
                        return await Result<int>.SuccessAsync($"{table.Name} Added to {nameof(TEntity)}");
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
