

using CPTool.Application.Features.BrandSupplierFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.BrandSupplierFeatures.Query.GetList
{
   
    public class GetBrandSupplierListQuery : GetListQuery, IRequest<List<AddEditBrandSupplierCommand>>
    {
        public GetBrandSupplierListQuery()
        {
        }

      

    }
    public class GetBrandSupplierListQueryHandler : IRequestHandler<GetBrandSupplierListQuery, List<AddEditBrandSupplierCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetBrandSupplierListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditBrandSupplierCommand>> Handle(GetBrandSupplierListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<BrandSupplier>().GetAllAsync();

            var retorno = _mapper.Map<List<AddEditBrandSupplierCommand>>(list);
            return retorno;

        }
    }
}
