using CPTool.Application.Features.DeviceFunctionFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionFeatures.Query.GetById
{
    
    public class GetByIdDeviceFunctionQuery : GetByIdQuery, IRequest<AddEditDeviceFunctionCommand>
    {
    }
    public class GetByIdDeviceFunctionQueryHandler : IRequestHandler<GetByIdDeviceFunctionQuery, AddEditDeviceFunctionCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdDeviceFunctionQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditDeviceFunctionCommand> Handle(GetByIdDeviceFunctionQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<DeviceFunction>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditDeviceFunctionCommand>(table);

        }
    }
    
}
