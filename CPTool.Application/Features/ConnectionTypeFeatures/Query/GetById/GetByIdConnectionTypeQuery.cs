using CPTool.Application.Features.ConnectionTypeFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ConnectionTypeFeatures.Query.GetById
{
    
    public class GetByIdConnectionTypeQuery : GetByIdQuery, IRequest<AddEditConnectionTypeCommand>
    {
    }
    public class GetByIdConnectionTypeQueryHandler : IRequestHandler<GetByIdConnectionTypeQuery, AddEditConnectionTypeCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdConnectionTypeQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditConnectionTypeCommand> Handle(GetByIdConnectionTypeQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<ConnectionType>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditConnectionTypeCommand>(table);

        }
    }
    
}
