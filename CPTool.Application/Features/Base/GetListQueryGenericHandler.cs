namespace CPTool.Application.Features.Base
{
    public class GetListQueryGeneric<T> : IRequest<List<T>> where T : EditCommand
    {
     
        public virtual bool FilterFunc(EditCommand element, string searchString)
        {


            var retorno = element!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase);
            return retorno;


        }
        public List<T> FilteredList = new();
    }
    public class GetListQueryGenericHandler<TEdit, TEntity>
       where TEdit : EditCommand, new()
       where TEntity : BaseDomainModel

    {

        protected readonly IMapper _mapper;
        protected IUnitOfWork _unitofwork;
        public GetListQueryGenericHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public virtual async Task<List<TEdit>> Handle(GetListQueryGeneric<TEdit> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<TEntity>().GetAllAsync();
            var retorno = _mapper.Map<List<TEdit>>(list);
          

            return _mapper.Map<List<TEdit>>(list);

        
        }
    }

}
