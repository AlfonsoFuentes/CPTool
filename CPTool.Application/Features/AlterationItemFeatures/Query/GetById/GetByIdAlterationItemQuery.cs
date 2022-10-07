using CPTool.Application.Features.AlterationItemFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.AlterationItemFeatures.Query.GetById
{
    
    public class GetByIdAlterationItemQuery : GetByIdQuery, IRequest<AddEditAlterationItemCommand>
    {
    }
    public class GetByIdAlterationItemQueryHandler : IRequestHandler<GetByIdAlterationItemQuery, AddEditAlterationItemCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdAlterationItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditAlterationItemCommand> Handle(GetByIdAlterationItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<AlterationItem>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditAlterationItemCommand>(table);

        }
    }
    
}
