

namespace CPTool.ApplicationCA.Base.Interactors
{
    public class GetByIdBase<TEditDTO, TEntity>: IGetByIdPort<TEditDTO, TEntity>
         where TEditDTO : EditCommand
        where TEntity : BaseDomainModel  
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdBase(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<TEditDTO> Handle(int id)
        {
            var table = await _unitofwork.Repository<TEntity>().GetByIdAsync(id);

            return _mapper.Map<TEditDTO>(table);

        }
    }
}
