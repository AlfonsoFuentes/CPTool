using CPTool.Application.Features.SignalTypeFeatures.Query.GetById;
using CPTool.Application.Features.SignalTypesFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;

namespace CPTool.Application.Features.SupplierFeatures.Query.GetById
{
    public class GetByIdSupplierQuery : GetByIdQuery, IRequest<EditSupplier>
    {
        public GetByIdSupplierQuery() { }
       
    }
    public class GetByIdSupplierQueryHandler :
        GetByIdQueryHandler<EditSupplier, Supplier, GetByIdSupplierQuery>, 
        IRequestHandler<GetByIdSupplierQuery, EditSupplier>
    {

       
        public GetByIdSupplierQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }

        public override async Task<EditSupplier> Handle(GetByIdSupplierQuery request, CancellationToken cancellationToken)
        {
            EditSupplier result = new();
            if(request.Id!=0)
            {
                var table = await _unitofwork.RepositorySupplier.GetByIdAsync(request.Id);

                result= _mapper.Map<EditSupplier>(table);
            }
          
            return result;

        }
    }
    
}
