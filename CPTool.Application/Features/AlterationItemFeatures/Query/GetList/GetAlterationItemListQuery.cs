
using CPTool.Application.Features.AlterationItemFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.AlterationItemFeatures.Query.GetList
{

    public class GetAlterationItemListQuery : GetListQuery, IRequest<List<AddEditAlterationItemCommand>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetAlterationItemListQuery, List<AddEditAlterationItemCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditAlterationItemCommand>> Handle(GetAlterationItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<AlterationItem>().GetAllAsync();

            return _mapper.Map<List<AddEditAlterationItemCommand>>(list);

        }
    }
}
