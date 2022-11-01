using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.Query.GetById;

namespace CPTool.Application.Features.BrandFeatures.Query.GetById
{
    public class GetByIdBrandQuery : GetByIdQuery, IRequest<EditBrand>
    {
        public GetByIdBrandQuery() { }
        
    }
    public class GetByIdBrandQueryHandler : 
        IRequestHandler<GetByIdBrandQuery, EditBrand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdBrandQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public  async Task<EditBrand> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.RepositoryBrand.GetByIdAsync(request.Id);

            return _mapper.Map<EditBrand>(table);

        }
    }
    
}
