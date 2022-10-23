
using CPTool.Application.Features.PropertyPackageFeatures.CreateEdit;

namespace CPTool.Application.Features.ProcessFluidFeatures.Query.GetList
{

    public class GetPropertyPackageListQuery : GetListQuery, IRequest<List<EditPropertyPackage>>
    {



    }
    public class GetPropertyPackageListQueryHandler : IRequestHandler<GetPropertyPackageListQuery, List<EditPropertyPackage>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetPropertyPackageListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditPropertyPackage>> Handle(GetPropertyPackageListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<PropertyPackage>().GetAllAsync();

            return _mapper.Map<List<EditPropertyPackage>>(list);

        }
    }
}
