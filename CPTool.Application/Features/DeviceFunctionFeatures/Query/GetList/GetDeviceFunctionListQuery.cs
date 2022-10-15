
using CPTool.Application.Features.DeviceFunctionFeatures.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionFeatures.Query.GetList
{

    public class GetDeviceFunctionListQuery : GetListQuery, IRequest<List<EditDeviceFunction>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetDeviceFunctionListQuery, List<EditDeviceFunction>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditDeviceFunction>> Handle(GetDeviceFunctionListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<DeviceFunction>().GetAllAsync();

            return _mapper.Map<List<EditDeviceFunction>>(list);

        }
    }
}
