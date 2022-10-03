using CPTool.Application.Features.GasketsFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.GasketFeatures.Query.GetById
{

    public class GetByIdGasketQuery : GetByIdQuery, IRequest<AddEditGasketCommand>
    {
    }
    public class GetByIdGasketQueryHandler : IRequestHandler<GetByIdGasketQuery, AddEditGasketCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdGasketQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditGasketCommand> Handle(GetByIdGasketQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<Gasket>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditGasketCommand>(table);

        }
    }

}
