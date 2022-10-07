using CPTool.Application.Features.ContingencyItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ContingencyItemFeatures.Query.GetById
{
    
    public class GetByIdContingencyItemQuery : GetByIdQuery, IRequest<AddEditContingencyItemCommand>
    {
    }
    public class GetByIdContingencyItemQueryHandler : IRequestHandler<GetByIdContingencyItemQuery, AddEditContingencyItemCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdContingencyItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditContingencyItemCommand> Handle(GetByIdContingencyItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<ContingencyItem>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditContingencyItemCommand>(table);

        }
    }
    
}
