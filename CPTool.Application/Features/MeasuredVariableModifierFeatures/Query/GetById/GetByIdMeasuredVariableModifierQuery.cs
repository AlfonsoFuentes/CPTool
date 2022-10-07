using CPTool.Application.Features.MeasuredVariableModifierFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MeasuredVariableModifierFeatures.Query.GetById
{
    
    public class GetByIdMeasuredVariableModifierQuery : GetByIdQuery, IRequest<AddEditMeasuredVariableModifierCommand>
    {
    }
    public class GetByIdMeasuredVariableModifierQueryHandler : IRequestHandler<GetByIdMeasuredVariableModifierQuery, AddEditMeasuredVariableModifierCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdMeasuredVariableModifierQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditMeasuredVariableModifierCommand> Handle(GetByIdMeasuredVariableModifierQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<MeasuredVariableModifier>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditMeasuredVariableModifierCommand>(table);

        }
    }
    
}
