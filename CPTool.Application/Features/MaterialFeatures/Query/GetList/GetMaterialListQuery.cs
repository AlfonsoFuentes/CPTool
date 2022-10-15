using CPTool.Application.Features.MaterialFeatures.CreateEdit;

namespace CPTool.Application.Features.MaterialFeatures.Query.GetList
{

    public class GetMaterialListQuery : GetListQuery, IRequest<List<EditMaterial>>
    {



    }
    public class GetMaterialListQueryHandler : IRequestHandler<GetMaterialListQuery, List<EditMaterial>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetMaterialListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditMaterial>> Handle(GetMaterialListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<Material>().GetAllAsync();

            return _mapper.Map<List<EditMaterial>>(list);

        }
    }
}
