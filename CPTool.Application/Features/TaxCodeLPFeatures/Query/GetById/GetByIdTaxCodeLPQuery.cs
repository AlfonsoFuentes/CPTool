using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;

namespace CPTool.Application.Features.TaxCodeLPFeatures.Query.GetById
{

    public class GetByIdTaxCodeLPQuery : GetByIdQuery, IRequest<EditTaxCodeLP>
    {
        public GetByIdTaxCodeLPQuery() { }
       
    }
    public class GetByIdTaxCodeLPQueryHandler : IRequestHandler<GetByIdTaxCodeLPQuery, EditTaxCodeLP>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdTaxCodeLPQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditTaxCodeLP> Handle(GetByIdTaxCodeLPQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<TaxCodeLP>().GetByIdAsync(request.Id);

            return _mapper.Map<EditTaxCodeLP>(table);

        }
    }

}
