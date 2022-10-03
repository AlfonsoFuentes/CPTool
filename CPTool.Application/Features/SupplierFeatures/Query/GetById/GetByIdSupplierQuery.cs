using CPTool.Application.Features.SupplierFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.SupplierFeatures.Query.GetById
{
    public class GetByIdSupplierQuery : GetByIdQuery, IRequest<AddEditSupplierCommand>
    {
    }
    public class GetByIdSupplierQueryHandler : IRequestHandler<GetByIdSupplierQuery, AddEditSupplierCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdSupplierQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditSupplierCommand> Handle(GetByIdSupplierQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<Supplier>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditSupplierCommand>(table);

        }
    }
    
}
