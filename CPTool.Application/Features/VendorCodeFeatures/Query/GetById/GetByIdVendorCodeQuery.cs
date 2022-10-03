using CPTool.Application.Features.VendorCodeFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.VendorCodeFeatures.Query.GetById
{

    public class GetByIdVendorCodeQuery : GetByIdQuery, IRequest<AddEditVendorCodeCommand>
    {
    }
    public class GetByIdVendorCodeQueryHandler : IRequestHandler<GetByIdVendorCodeQuery, AddEditVendorCodeCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdVendorCodeQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditVendorCodeCommand> Handle(GetByIdVendorCodeQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<VendorCode>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditVendorCodeCommand>(table);

        }
    }

}
