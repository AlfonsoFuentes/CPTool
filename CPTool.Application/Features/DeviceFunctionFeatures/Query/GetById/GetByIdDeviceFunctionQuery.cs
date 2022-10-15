using CPTool.Application.Features.DeviceFunctionFeatures.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionFeatures.Query.GetById
{

    public class GetByIdDeviceFunctionQuery : GetByIdQuery, IRequest<EditDeviceFunction>
    {
        public GetByIdDeviceFunctionQuery() { }
       
    }
    public class GetByIdDeviceFunctionQueryHandler : IRequestHandler<GetByIdDeviceFunctionQuery, EditDeviceFunction>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdDeviceFunctionQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditDeviceFunction> Handle(GetByIdDeviceFunctionQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<DeviceFunction>().GetByIdAsync(request.Id);

            return _mapper.Map<EditDeviceFunction>(table);

        }
    }

}
