
using CPTool.Application.Features.ProcessConditionFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ProcessConditionFeatures.Query.GetList
{

    public class GetProcessConditionListQuery : GetListQuery, IRequest<List<AddEditProcessConditionCommand>>
    {



    }
    public class GetProcessConditionListQueryHandler : IRequestHandler<GetProcessConditionListQuery, List<AddEditProcessConditionCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetProcessConditionListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditProcessConditionCommand>> Handle(GetProcessConditionListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<ProcessCondition>().GetAllAsync();

            return _mapper.Map<List<AddEditProcessConditionCommand>>(list);

        }
    }
}
