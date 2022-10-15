
using CPTool.Application.Features.VendorCodeFeatures.CreateEdit;

namespace CPTool.Application.Features.VendorCodeFeatures.Query.GetList
{

    public class GetVendorCodeListQuery : GetListQuery, IRequest<List<EditVendorCode>>
    {



    }
    public class GetVendorCodeListQueryHandler : IRequestHandler<GetVendorCodeListQuery, List<EditVendorCode>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetVendorCodeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditVendorCode>> Handle(GetVendorCodeListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<VendorCode>().GetAllAsync();

            return _mapper.Map<List<EditVendorCode>>(list);

        }
    }
}
