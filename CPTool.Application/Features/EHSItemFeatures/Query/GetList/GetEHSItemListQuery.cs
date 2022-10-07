
using CPTool.Application.Features.EHSItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.EHSItemFeatures.Query.GetList
{

    public class GetEHSItemListQuery : GetListQuery, IRequest<List<AddEditEHSItemCommand>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetEHSItemListQuery, List<AddEditEHSItemCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditEHSItemCommand>> Handle(GetEHSItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<EHSItem>().GetAllAsync();

            return _mapper.Map<List<AddEditEHSItemCommand>>(list);

        }
    }
}
