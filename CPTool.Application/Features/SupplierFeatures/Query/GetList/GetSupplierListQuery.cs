

using CPTool.Application.Features.SupplierFeatures.CreateEdit;

namespace CPTool.Application.Features.SupplierFeatures.Query.GetList
{
   
    public class GetSupplierListQuery : GetListQuery, IRequest<List<EditSupplier>>
    {
        public GetSupplierListQuery()
        {
        }

      

    }
    public class GetSupplierListQueryHandler :
         GetListQueryHandler<EditSupplier, Supplier, GetSupplierListQuery>, 
        IRequestHandler<GetSupplierListQuery, List<EditSupplier>>
    {
        public GetSupplierListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }

        public override async Task<List<EditSupplier>> Handle(GetSupplierListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositorySupplier.GetAllAsync();

            var retorno= _mapper.Map<List<EditSupplier>>(list);
            return retorno;

        }
    }
}
