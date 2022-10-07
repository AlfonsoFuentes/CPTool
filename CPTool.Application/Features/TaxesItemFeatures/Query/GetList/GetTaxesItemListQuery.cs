
using CPTool.Application.Features.TaxesItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.TaxesItemFeatures.Query.GetList
{

    public class GetTaxesItemListQuery : GetListQuery, IRequest<List<AddEditTaxesItemCommand>>
    {



    }
    public class GetTaxesItemListQueryHandler : IRequestHandler<GetTaxesItemListQuery, List<AddEditTaxesItemCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetTaxesItemListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditTaxesItemCommand>> Handle(GetTaxesItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<TaxesItem>().GetAllAsync();

            return _mapper.Map<List<AddEditTaxesItemCommand>>(list);

        }
    }
}
