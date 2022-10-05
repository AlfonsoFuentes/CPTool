using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.Query.GetById
{
    
    public class GetByIdMWOItemQuery : GetByIdQuery, IRequest<AddEditMWOItemCommand>
    {
    }
    public class GetByIdMWOItemQueryHandler : IRequestHandler<GetByIdMWOItemQuery, AddEditMWOItemCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdMWOItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditMWOItemCommand> Handle(GetByIdMWOItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.RepositoryMWOItem.GetMWOItemIdAsync(request.Id);

            var result= _mapper.Map<AddEditMWOItemCommand>(table);
            return result;

        }
    }
    
}
