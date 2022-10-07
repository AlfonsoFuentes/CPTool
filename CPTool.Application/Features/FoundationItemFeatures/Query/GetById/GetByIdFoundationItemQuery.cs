using CPTool.Application.Features.FoundationItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.FoundationItemFeatures.Query.GetById
{
    
    public class GetByIdFoundationItemQuery : GetByIdQuery, IRequest<AddEditFoundationItemCommand>
    {
    }
    public class GetByIdFoundationItemQueryHandler : IRequestHandler<GetByIdFoundationItemQuery, AddEditFoundationItemCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdFoundationItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditFoundationItemCommand> Handle(GetByIdFoundationItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<FoundationItem>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditFoundationItemCommand>(table);

        }
    }
    
}
