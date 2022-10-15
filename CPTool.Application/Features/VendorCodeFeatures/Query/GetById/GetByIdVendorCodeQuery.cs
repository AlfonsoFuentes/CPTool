using CPTool.Application.Features.VendorCodeFeatures.CreateEdit;

namespace CPTool.Application.Features.VendorCodeFeatures.Query.GetById
{

    public class GetByIdVendorCodeQuery : GetByIdQuery, IRequest<EditVendorCode>
    {
        public GetByIdVendorCodeQuery() { }
       
    }
    public class GetByIdVendorCodeQueryHandler : IRequestHandler<GetByIdVendorCodeQuery, EditVendorCode>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdVendorCodeQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditVendorCode> Handle(GetByIdVendorCodeQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<VendorCode>().GetByIdAsync(request.Id);

            return _mapper.Map<EditVendorCode>(table);

        }
    }

}
