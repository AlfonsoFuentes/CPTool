using CPTool.Application.Features.DeviceFunctionFeatures.CreateEdit;
using CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit;
using CPTool.Application.Features.DeviceFunctionModifierFeatures.Query.GetById;

namespace CPTool.Application.Features.DeviceFunctionFeatures.Query.GetById
{

    public class GetByIdDeviceFunctionQuery : GetByIdQuery, IRequest<EditDeviceFunction>
    {
        public GetByIdDeviceFunctionQuery() { }
       
    }
    public class GetByIdDeviceFunctionQueryHandler :
         GetByIdQueryHandler<EditDeviceFunction, DeviceFunction, GetByIdDeviceFunctionQuery>, 
        IRequestHandler<GetByIdDeviceFunctionQuery, EditDeviceFunction>
    {

       
        public GetByIdDeviceFunctionQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper) : base(unitofwork, mapper)
        {
           
        }
       
    }

}
