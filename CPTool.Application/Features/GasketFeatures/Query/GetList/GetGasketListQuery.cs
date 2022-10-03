
using CPTool.Application.Features.GasketsFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.GasketFeatures.Query.GetList
{

    public class GetGasketListQuery : GetListQuery, IRequest<List<AddEditGasketCommand>>
    {



    }
    public class GetGasketListQueryHandler : IRequestHandler<GetGasketListQuery, List<AddEditGasketCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetGasketListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditGasketCommand>> Handle(GetGasketListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<Gasket>().GetAllAsync();

            return _mapper.Map<List<AddEditGasketCommand>>(list);

        }
    }
}
