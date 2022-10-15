

using CPTool.Application.Features.SupplierFeatures.CreateEdit;

namespace CPTool.Application.Features.SupplierFeatures.Query.GetList
{
   
    public class GetSupplierListQuery : GetListQuery, IRequest<List<EditSupplier>>
    {
        public GetSupplierListQuery()
        {
        }

      

    }
    public class GetSupplierListQueryHandler : IRequestHandler<GetSupplierListQuery, List<EditSupplier>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetSupplierListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditSupplier>> Handle(GetSupplierListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<Supplier>().GetAllAsync();

            var retorno= _mapper.Map<List<EditSupplier>>(list);
            return retorno;

        }
    }
}
