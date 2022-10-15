
using CPTool.Application.Features.MeasuredVariableFeatures.CreateEdit;

namespace CPTool.Application.Features.MeasuredVariableFeatures.Query.GetList
{

    public class GetMeasuredVariableListQuery : GetListQuery, IRequest<List<EditMeasuredVariable>>
    {



    }
    public class GetMeasuredVariableListQueryHandler : IRequestHandler<GetMeasuredVariableListQuery, List<EditMeasuredVariable>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetMeasuredVariableListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditMeasuredVariable>> Handle(GetMeasuredVariableListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<MeasuredVariable>().GetAllAsync();

            return _mapper.Map<List<EditMeasuredVariable>>(list);

        }
    }
}
