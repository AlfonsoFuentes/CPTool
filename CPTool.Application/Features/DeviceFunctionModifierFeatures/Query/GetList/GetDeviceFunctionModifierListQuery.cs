
using CPTool.Application.Features.DeviceFunctionModifierFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.Query.GetList
{

    public class GetDeviceFunctionModifierListQuery : GetListQuery, IRequest<List<AddEditDeviceFunctionModifierCommand>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetDeviceFunctionModifierListQuery, List<AddEditDeviceFunctionModifierCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditDeviceFunctionModifierCommand>> Handle(GetDeviceFunctionModifierListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<DeviceFunctionModifier>().GetAllAsync();

            return _mapper.Map<List<AddEditDeviceFunctionModifierCommand>>(list);

        }
    }
}
