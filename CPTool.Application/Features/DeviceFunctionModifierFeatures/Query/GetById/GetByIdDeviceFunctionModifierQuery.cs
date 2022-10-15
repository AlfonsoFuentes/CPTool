using CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.Query.GetById
{

    public class GetByIdDeviceFunctionModifierQuery : GetByIdQuery, IRequest<EditDeviceFunctionModifier>
    {
        public GetByIdDeviceFunctionModifierQuery() { }
        
    }
    public class GetByIdDeviceFunctionModifierQueryHandler : IRequestHandler<GetByIdDeviceFunctionModifierQuery, EditDeviceFunctionModifier>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdDeviceFunctionModifierQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditDeviceFunctionModifier> Handle(GetByIdDeviceFunctionModifierQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<DeviceFunctionModifier>().GetByIdAsync(request.Id);

            return _mapper.Map<EditDeviceFunctionModifier>(table);

        }
    }
    
}
