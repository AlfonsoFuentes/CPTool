




namespace CPTool.ApplicationCA.Base.Interactors
{
    public class AddEditBase<TAdd, TEdit, TEntity> : IAddEditPort<TAdd, TEdit, TEntity>
        where TAdd : AddCommand
        where TEdit : EditCommand
        where TEntity : BaseDomainModel
    {
        protected IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public AddEditBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public virtual async Task<Result<int>> Handle(TEdit command)
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
