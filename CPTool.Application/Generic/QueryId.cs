namespace CPTool.Application.Generic
{
    public class QueryId<T> : IRequest<T> where T : EditCommand
    {
        public int Id { get; set; }
    }
    public class QueryIdHandler<T, TEntity> : IRequestHandler<QueryId<T>, T>
    where T : EditCommand, new()
   where TEntity : AuditableEntity
    {
        protected readonly IMapper _mapper;
        protected IUnitOfWork _unitofwork;

        public QueryIdHandler(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }
        public virtual async Task<T> Handle(QueryId<T> request, CancellationToken cancellationToken)
        {
            T result = new T();

            if (request.Id != 0)
            {
                var table = await _unitofwork.Repository<TEntity>().GetByIdAsync(request.Id);
                result = _mapper.Map<T>(table);
            }


            return result;

        }
    }
}
