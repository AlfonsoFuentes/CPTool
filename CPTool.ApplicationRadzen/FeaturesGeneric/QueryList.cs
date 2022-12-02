using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationRadzen.FeaturesGeneric
{

    public class QueryList<T> : IRequest<List<T>> where T : EditCommand
    {
      
    }

  
    public class QueryListHandler<T, TEntity> : IRequestHandler<QueryList<T>, List<T>>
      where T : EditCommand
     where TEntity : BaseDomainModel

    {

        protected readonly IMapper _mapper;
        protected IUnitOfWork _unitofwork;
        public QueryListHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public virtual async Task<List<T>> Handle(QueryList<T> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<TEntity>().GetAllAsync();

            return _mapper.Map<List<T>>(list);

         
        }
    }
}
