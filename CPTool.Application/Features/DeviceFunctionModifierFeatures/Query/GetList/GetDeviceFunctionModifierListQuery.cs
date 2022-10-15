
using CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.Query.GetList
{

    public class GetDeviceFunctionModifierListQuery : GetListQuery, IRequest<List<EditDeviceFunctionModifier>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetDeviceFunctionModifierListQuery, List<EditDeviceFunctionModifier>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditDeviceFunctionModifier>> Handle(GetDeviceFunctionModifierListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<DeviceFunctionModifier>().GetAllAsync();

            return _mapper.Map<List<EditDeviceFunctionModifier>>(list);

        }
    }
}
