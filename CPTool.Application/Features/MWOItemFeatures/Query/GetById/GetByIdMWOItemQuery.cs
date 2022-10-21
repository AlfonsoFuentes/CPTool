using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.Query.GetById
{

    public class GetByIdMWOItemQuery : GetByIdQuery, IRequest<EditMWOItem>
    {
        public GetByIdMWOItemQuery() { }
       
    }
    public class GetByIdMWOItemQueryHandler : IRequestHandler<GetByIdMWOItemQuery, EditMWOItem>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdMWOItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditMWOItem> Handle(GetByIdMWOItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.RepositoryMWOItem.GetMWOItemIdAsync(request.Id);

            var result= _mapper.Map<EditMWOItem>(table);

          
            return result;

        }
    }
    
}
