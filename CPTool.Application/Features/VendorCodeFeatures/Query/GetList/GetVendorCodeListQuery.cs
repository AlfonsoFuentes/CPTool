
using CPTool.Application.Features.VendorCodeFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.VendorCodeFeatures.Query.GetList
{

    public class GetVendorCodeListQuery : GetListQuery, IRequest<List<AddEditVendorCodeCommand>>
    {



    }
    public class GetVendorCodeListQueryHandler : IRequestHandler<GetVendorCodeListQuery, List<AddEditVendorCodeCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetVendorCodeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditVendorCodeCommand>> Handle(GetVendorCodeListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<VendorCode>().GetAllAsync();

            return _mapper.Map<List<AddEditVendorCodeCommand>>(list);

        }
    }
}
