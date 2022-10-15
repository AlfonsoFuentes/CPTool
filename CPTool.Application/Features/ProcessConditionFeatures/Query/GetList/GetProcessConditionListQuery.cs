
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;

namespace CPTool.Application.Features.ProcessConditionFeatures.Query.GetList
{

    public class GetProcessConditionListQuery : GetListQuery, IRequest<List<EditProcessCondition>>
    {



    }
    public class GetProcessConditionListQueryHandler : IRequestHandler<GetProcessConditionListQuery, List<EditProcessCondition>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetProcessConditionListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditProcessCondition>> Handle(GetProcessConditionListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<ProcessCondition>().GetAllAsync();

            return _mapper.Map<List<EditProcessCondition>>(list);

        }
    }
}
