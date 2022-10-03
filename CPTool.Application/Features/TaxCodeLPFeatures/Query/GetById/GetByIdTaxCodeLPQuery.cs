using CPTool.Application.Features.TaxCodeLPFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.TaxCodeLPFeatures.Query.GetById
{

    public class GetByIdTaxCodeLPQuery : GetByIdQuery, IRequest<AddEditTaxCodeLPCommand>
    {
    }
    public class GetByIdTaxCodeLPQueryHandler : IRequestHandler<GetByIdTaxCodeLPQuery, AddEditTaxCodeLPCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdTaxCodeLPQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditTaxCodeLPCommand> Handle(GetByIdTaxCodeLPQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<TaxCodeLP>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditTaxCodeLPCommand>(table);

        }
    }

}
