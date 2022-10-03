

using CPTool.Application.Features.SupplierFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.SupplierFeatures.Query.GetList
{
   
    public class GetSupplierListQuery : GetListQuery, IRequest<List<AddEditSupplierCommand>>
    {
        public GetSupplierListQuery()
        {
        }

      

    }
    public class GetSupplierListQueryHandler : IRequestHandler<GetSupplierListQuery, List<AddEditSupplierCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetSupplierListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditSupplierCommand>> Handle(GetSupplierListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<Supplier>().GetAsync(null!,null!,true,false);

            var retorno= _mapper.Map<List<AddEditSupplierCommand>>(list);
            return retorno;

        }
    }
}
