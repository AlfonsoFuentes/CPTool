

using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.ChapterFeatures.CreateEdit;
using CPTool.Application.Features.ChapterFeatures.Query.GetList;

namespace CPTool.Application.Features.BrandFeatures.Query.GetList
{
   
    public class GetBrandListQuery : GetListQuery, IRequest<List<EditBrand>>
    {
        public GetBrandListQuery()
        {
        }

      

    }
    public class GetBrandListQueryHandler :
        GetListQueryHandler<EditBrand, Brand, GetBrandListQuery>, 
        IRequestHandler<GetBrandListQuery, List<EditBrand>>
    {

     
        public GetBrandListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork,mapper)
        {

        }
        public override async Task<List<EditBrand>> Handle(GetBrandListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryBrand.GetAllAsync();
            list = list.OrderBy(x => x.BrandType).ToList();
            var reteorno= _mapper.Map<List<EditBrand>>(list);
            return reteorno;

        }
    }

   
}
