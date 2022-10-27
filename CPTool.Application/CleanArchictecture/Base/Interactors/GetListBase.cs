

namespace CPTool.ApplicationCA.Base.Interactors
{
    public class GetListBase<TEditDTO, TEntity>: IListPort<TEditDTO, TEntity>
        where TEditDTO : EditCommand
        where TEntity : BaseDomainModel 
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetListBase(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public virtual async Task<List<TEditDTO>> Handle()
        {
            var list = await _unitofwork.Repository<TEntity>().GetAllAsync();

            return _mapper.Map<List<TEditDTO>>(list);

        }
        public virtual bool FilterFunc(TEditDTO element, string searchString)
        {


            var retorno = element!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase);
            return retorno;


        }
    }
}
