using CPTool.Application.Features.DeviceFunctionModifierFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.Query.GetById
{
    
    public class GetByIdDeviceFunctionModifierQuery : GetByIdQuery, IRequest<AddEditDeviceFunctionModifierCommand>
    {
    }
    public class GetByIdDeviceFunctionModifierQueryHandler : IRequestHandler<GetByIdDeviceFunctionModifierQuery, AddEditDeviceFunctionModifierCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdDeviceFunctionModifierQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditDeviceFunctionModifierCommand> Handle(GetByIdDeviceFunctionModifierQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<DeviceFunctionModifier>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditDeviceFunctionModifierCommand>(table);

        }
    }
    
}
