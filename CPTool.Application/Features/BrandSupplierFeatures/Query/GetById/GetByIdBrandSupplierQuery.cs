using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;

namespace CPTool.Application.Features.BrandSupplierFeatures.Query.GetById
{
    public class GetByIdBrandSupplierQuery : GetByIdQuery, IRequest<EditBrandSupplier>
    {
        public GetByIdBrandSupplierQuery() { }
        
    }
    public class GetByIdBrandSupplierQueryHandler : IRequestHandler<GetByIdBrandSupplierQuery, EditBrandSupplier>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdBrandSupplierQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditBrandSupplier> Handle(GetByIdBrandSupplierQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<BrandSupplier>().GetByIdAsync(request.Id);

            return _mapper.Map<EditBrandSupplier>(table);

        }
    }
    
}
