

using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetList;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;

namespace CPTool.Application.Features.BrandSupplierFeatures.Query.GetList
{
   
    public class GetBrandSupplierListQuery : GetListQuery, IRequest<List<EditBrandSupplier>>
    {
        public GetBrandSupplierListQuery()
        {
        }

      

    }
    public class GetBrandSupplierListQueryHandler :
        GetListQueryHandler<EditBrandSupplier, BrandSupplier, GetBrandSupplierListQuery>, 
        IRequestHandler<GetBrandSupplierListQuery, List<EditBrandSupplier>>
    {

      
        public GetBrandSupplierListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper)
        {

        }
        public override async Task<List<EditBrandSupplier>> Handle(GetBrandSupplierListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryBrandSupplier.GetAllAsync();

            var retorno = _mapper.Map<List<EditBrandSupplier>>(list);
            return retorno;

        }
    }
}
