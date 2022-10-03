using CPTool.Application.Features.BrandSupplierFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.BrandSupplierFeatures.Query.GetById
{
    public class GetByIdBrandSupplierQuery : GetByIdQuery, IRequest<AddEditBrandSupplierCommand>
    {
    }
    public class GetByIdBrandSupplierQueryHandler : IRequestHandler<GetByIdBrandSupplierQuery, AddEditBrandSupplierCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdBrandSupplierQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditBrandSupplierCommand> Handle(GetByIdBrandSupplierQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<BrandSupplier>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditBrandSupplierCommand>(table);

        }
    }
    
}
