using CPTool.Application.Features.TaxCodeLDFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.TaxCodeLDFeatures.Query.GetById
{

    public class GetByIdTaxCodeLDQuery : GetByIdQuery, IRequest<AddEditTaxCodeLDCommand>
    {
    }
    public class GetByIdTaxCodeLDQueryHandler : IRequestHandler<GetByIdTaxCodeLDQuery, AddEditTaxCodeLDCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdTaxCodeLDQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditTaxCodeLDCommand> Handle(GetByIdTaxCodeLDQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<TaxCodeLD>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditTaxCodeLDCommand>(table);

        }
    }

}
