using CPTool.Application.Features.SupplierFeatures.CreateEdit;

namespace CPTool.Application.Features.SupplierFeatures.Query.GetById
{
    public class GetByIdSupplierQuery : GetByIdQuery, IRequest<EditSupplier>
    {
        public GetByIdSupplierQuery() { }
       
    }
    public class GetByIdSupplierQueryHandler : IRequestHandler<GetByIdSupplierQuery, EditSupplier>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdSupplierQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditSupplier> Handle(GetByIdSupplierQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<Supplier>().GetByIdAsync(request.Id);

            return _mapper.Map<EditSupplier>(table);

        }
    }
    
}
