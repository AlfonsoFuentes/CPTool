
using CPTool.Application.Features.InsulationItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.InsulationItemFeatures.Query.GetList
{

    public class GetInsulationItemListQuery : GetListQuery, IRequest<List<AddEditInsulationItemCommand>>
    {



    }
    public class GetInsulationItemListQueryHandler : IRequestHandler<GetInsulationItemListQuery, List<AddEditInsulationItemCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetInsulationItemListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditInsulationItemCommand>> Handle(GetInsulationItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<InsulationItem>().GetAllAsync();

            return _mapper.Map<List<AddEditInsulationItemCommand>>(list);

        }
    }
}
