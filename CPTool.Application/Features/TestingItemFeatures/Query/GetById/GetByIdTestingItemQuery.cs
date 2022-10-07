using CPTool.Application.Features.TestingItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.TestingItemFeatures.Query.GetById
{
    
    public class GetByIdTestingItemQuery : GetByIdQuery, IRequest<AddEditTestingItemCommand>
    {
    }
    public class GetByIdTestingItemQueryHandler : IRequestHandler<GetByIdTestingItemQuery, AddEditTestingItemCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdTestingItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditTestingItemCommand> Handle(GetByIdTestingItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<TestingItem>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditTestingItemCommand>(table);

        }
    }
    
}
