using CPTool.Application.Features.ProcessConditionFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ProcessConditionFeatures.Query.GetById
{
    
    public class GetByIdProcessConditionQuery : GetByIdQuery, IRequest<AddEditProcessConditionCommand>
    {
    }
    public class GetByIdProcessConditionQueryHandler : IRequestHandler<GetByIdProcessConditionQuery, AddEditProcessConditionCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdProcessConditionQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditProcessConditionCommand> Handle(GetByIdProcessConditionQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<ProcessCondition>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditProcessConditionCommand>(table);

        }
    }
    
}
