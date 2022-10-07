
using CPTool.Application.Features.ContingencyItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ContingencyItemFeatures.Query.GetList
{

    public class GetContingencyItemListQuery : GetListQuery, IRequest<List<AddEditContingencyItemCommand>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetContingencyItemListQuery, List<AddEditContingencyItemCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditContingencyItemCommand>> Handle(GetContingencyItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<ContingencyItem>().GetAllAsync();

            return _mapper.Map<List<AddEditContingencyItemCommand>>(list);

        }
    }
}
