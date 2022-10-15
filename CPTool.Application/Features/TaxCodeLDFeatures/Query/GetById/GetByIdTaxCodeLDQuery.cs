using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;

namespace CPTool.Application.Features.TaxCodeLDFeatures.Query.GetById
{

    public class GetByIdTaxCodeLDQuery : GetByIdQuery, IRequest<EditTaxCodeLD>
    {
        public GetByIdTaxCodeLDQuery() { }
        
    }
    public class GetByIdTaxCodeLDQueryHandler : IRequestHandler<GetByIdTaxCodeLDQuery, EditTaxCodeLD>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdTaxCodeLDQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditTaxCodeLD> Handle(GetByIdTaxCodeLDQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<TaxCodeLD>().GetByIdAsync(request.Id);

            return _mapper.Map<EditTaxCodeLD>(table);

        }
    }

}
