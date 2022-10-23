using CPTool.Application.Features.PropertyPackageFeatures.CreateEdit;

namespace CPTool.Application.Features.PropertyPackageFeatures.Query.GetById
{

    public class GetByIdPropertyPackageQuery : GetByIdQuery, IRequest<EditPropertyPackage>
    {
        public GetByIdPropertyPackageQuery() { }
        
    }
    public class GetByIdProcessFluidQueryHandler : IRequestHandler<GetByIdPropertyPackageQuery, EditPropertyPackage>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdProcessFluidQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditPropertyPackage> Handle(GetByIdPropertyPackageQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<PropertyPackage>().GetByIdAsync(request.Id);

            return _mapper.Map<EditPropertyPackage>(table);

        }
    }
    
}
