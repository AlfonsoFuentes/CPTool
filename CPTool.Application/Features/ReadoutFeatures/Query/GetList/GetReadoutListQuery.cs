
using CPTool.Application.Features.ReadoutFeatures.CreateEdit;

namespace CPTool.Application.Features.ReadoutFeatures.Query.GetList
{

    public class GetReadoutListQuery : GetListQuery, IRequest<List<EditReadout>>
    {



    }
    public class GetReadoutListQueryHandler : IRequestHandler<GetReadoutListQuery, List<EditReadout>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetReadoutListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditReadout>> Handle(GetReadoutListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<Readout>().GetAllAsync();

            return _mapper.Map<List<EditReadout>>(list);

        }
    }
}
