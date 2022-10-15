
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;

namespace CPTool.Application.Features.ProcessFluidFeatures.Query.GetList
{

    public class GetProcessFluidListQuery : GetListQuery, IRequest<List<EditProcessFluid>>
    {



    }
    public class GetProcessFluidListQueryHandler : IRequestHandler<GetProcessFluidListQuery, List<EditProcessFluid>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetProcessFluidListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditProcessFluid>> Handle(GetProcessFluidListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<ProcessFluid>().GetAllAsync();

            return _mapper.Map<List<EditProcessFluid>>(list);

        }
    }
}
