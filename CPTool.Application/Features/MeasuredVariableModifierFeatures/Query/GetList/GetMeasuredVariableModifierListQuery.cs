
using CPTool.Application.Features.MeasuredVariableModifierFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MeasuredVariableModifierFeatures.Query.GetList
{

    public class GetMeasuredVariableModifierListQuery : GetListQuery, IRequest<List<AddEditMeasuredVariableModifierCommand>>
    {



    }
    public class GetMeasuredVariableModifierListQueryHandler : IRequestHandler<GetMeasuredVariableModifierListQuery, List<AddEditMeasuredVariableModifierCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetMeasuredVariableModifierListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditMeasuredVariableModifierCommand>> Handle(GetMeasuredVariableModifierListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<MeasuredVariableModifier>().GetAllAsync();

            return _mapper.Map<List<AddEditMeasuredVariableModifierCommand>>(list);

        }
    }
}
