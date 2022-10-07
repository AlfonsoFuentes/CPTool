using CPTool.Application.Features.EHSItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.EHSItemFeatures.Query.GetById
{
    
    public class GetByIdEHSItemQuery : GetByIdQuery, IRequest<AddEditEHSItemCommand>
    {
    }
    public class GetByIdEHSItemQueryHandler : IRequestHandler<GetByIdEHSItemQuery, AddEditEHSItemCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdEHSItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditEHSItemCommand> Handle(GetByIdEHSItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<EHSItem>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditEHSItemCommand>(table);

        }
    }
    
}
