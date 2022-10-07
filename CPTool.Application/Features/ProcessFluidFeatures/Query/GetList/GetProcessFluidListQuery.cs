
using CPTool.Application.Features.ProcessFluidFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ProcessFluidFeatures.Query.GetList
{

    public class GetProcessFluidListQuery : GetListQuery, IRequest<List<AddEditProcessFluidCommand>>
    {



    }
    public class GetProcessFluidListQueryHandler : IRequestHandler<GetProcessFluidListQuery, List<AddEditProcessFluidCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetProcessFluidListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditProcessFluidCommand>> Handle(GetProcessFluidListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<ProcessFluid>().GetAllAsync();

            return _mapper.Map<List<AddEditProcessFluidCommand>>(list);

        }
    }
}
