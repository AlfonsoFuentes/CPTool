

using CPTool.Application.Features.BrandFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.BrandFeatures.Query.GetList
{
   
    public class GetBrandListQuery : GetListQuery, IRequest<List<AddEditBrandCommand>>
    {
        public GetBrandListQuery()
        {
        }

      

    }
    public class GetBrandListQueryHandler : IRequestHandler<GetBrandListQuery, List<AddEditBrandCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetBrandListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditBrandCommand>> Handle(GetBrandListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<Brand>().GetAllAsync();

            var reteorno= _mapper.Map<List<AddEditBrandCommand>>(list);
            return reteorno;

        }
    }
}
