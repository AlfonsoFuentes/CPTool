
using CPTool.Application.Features.ElectricalItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ElectricalItemFeatures.Query.GetList
{

    public class GetElectricalItemListQuery : GetListQuery, IRequest<List<AddEditElectricalItemCommand>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetElectricalItemListQuery, List<AddEditElectricalItemCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditElectricalItemCommand>> Handle(GetElectricalItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<ElectricalItem>().GetAllAsync();

            return _mapper.Map<List<AddEditElectricalItemCommand>>(list);

        }
    }
}
