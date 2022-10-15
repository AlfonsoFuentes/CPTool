

using CPTool.Application.Features.BrandFeatures.CreateEdit;

namespace CPTool.Application.Features.BrandFeatures.Query.GetList
{
   
    public class GetBrandListQuery : GetListQuery, IRequest<List<EditBrand>>
    {
        public GetBrandListQuery()
        {
        }

      

    }
    public class GetBrandListQueryHandler : IRequestHandler<GetBrandListQuery, List<EditBrand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetBrandListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditBrand>> Handle(GetBrandListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryBrand.GetAllAsync();

            var reteorno= _mapper.Map<List<EditBrand>>(list);
            return reteorno;

        }
    }
}
