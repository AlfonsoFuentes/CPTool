using CPTool.Application.Features.GasketsFeatures.CreateEdit;

namespace CPTool.Application.Features.GasketFeatures.Query.GetById
{

    public class GetByIdGasketQuery : GetByIdQuery, IRequest<EditGasket>
    {
        public GetByIdGasketQuery() { }
       
    }
    public class GetByIdGasketQueryHandler : IRequestHandler<GetByIdGasketQuery, EditGasket>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdGasketQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditGasket> Handle(GetByIdGasketQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<Gasket>().GetByIdAsync(request.Id);

            return _mapper.Map<EditGasket>(table);

        }
    }

}
