

using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;

namespace CPTool.Application.Features.BrandSupplierFeatures.Query.GetList
{
   
    public class GetBrandSupplierListQuery : GetListQuery, IRequest<List<EditBrandSupplier>>
    {
        public GetBrandSupplierListQuery()
        {
        }

      

    }
    public class GetBrandSupplierListQueryHandler : IRequestHandler<GetBrandSupplierListQuery, List<EditBrandSupplier>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetBrandSupplierListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditBrandSupplier>> Handle(GetBrandSupplierListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<BrandSupplier>().GetAllAsync();

            var retorno = _mapper.Map<List<EditBrandSupplier>>(list);
            return retorno;

        }
    }
}
