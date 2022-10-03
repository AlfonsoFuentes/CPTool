
using CPTool.Application.Features.TaxCodeLDFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.TaxCodeLDFeatures.Query.GetList
{

    public class GetTaxCodeLDListQuery : GetListQuery, IRequest<List<AddEditTaxCodeLDCommand>>
    {



    }
    public class GetTaxCodeLDListQueryHandler : IRequestHandler<GetTaxCodeLDListQuery, List<AddEditTaxCodeLDCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetTaxCodeLDListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditTaxCodeLDCommand>> Handle(GetTaxCodeLDListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<TaxCodeLD>().GetAllAsync();

            return _mapper.Map<List<AddEditTaxCodeLDCommand>>(list);

        }
    }
}
