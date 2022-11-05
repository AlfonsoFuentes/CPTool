
using CPTool.Application.Features.DeviceFunctionFeatures.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionFeatures.Query.GetList
{

    public class GetDeviceFunctionListQuery : GetListQuery, IRequest<List<EditDeviceFunction>>
    {



    }
    public class GetUnitaryBasePrizeListQueryHandler :
         GetListQueryHandler<EditDeviceFunction, DeviceFunction, GetDeviceFunctionListQuery>, 
        IRequestHandler<GetDeviceFunctionListQuery, List<EditDeviceFunction>>
    {

      
        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper)
        {

        }
    }
}
