using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;

namespace CPTool.Application.Features.PipeAccesoryFeatures.Query.GetById
{

    public class GetByIdPipeAccesoryQuery : GetByIdQuery, IRequest<EditPipeAccesory>
    {
        public GetByIdPipeAccesoryQuery() { }
       
    }
    public class GetByIdPipeAccesoryQueryHandler : IRequestHandler<GetByIdPipeAccesoryQuery, EditPipeAccesory>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdPipeAccesoryQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditPipeAccesory> Handle(GetByIdPipeAccesoryQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<PipeAccesory>().GetByIdAsync(request.Id);

            return _mapper.Map<EditPipeAccesory>(table);

        }
    }
    
}
