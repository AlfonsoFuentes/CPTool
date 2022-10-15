
using CPTool.Application.Features.MeasuredVariableModifierFeatures.CreateEdit;

namespace CPTool.Application.Features.MeasuredVariableModifierFeatures.Query.GetList
{

    public class GetMeasuredVariableModifierListQuery : GetListQuery, IRequest<List<EditMeasuredVariableModifier>>
    {



    }
    public class GetMeasuredVariableModifierListQueryHandler : IRequestHandler<GetMeasuredVariableModifierListQuery, List<EditMeasuredVariableModifier>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetMeasuredVariableModifierListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditMeasuredVariableModifier>> Handle(GetMeasuredVariableModifierListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<MeasuredVariableModifier>().GetAllAsync();

            return _mapper.Map<List<EditMeasuredVariableModifier>>(list);

        }
    }
}
