using CPTool.Application.Features.TaksFeatures.CreateEdit;

namespace CPTool.Application.Features.TaksFeatures.Query.GetById
{

    public class GetByIdTaksQuery : GetByIdQuery, IRequest<EditTaks>
    {
        public GetByIdTaksQuery() { }

    }
    public class GetByIdPipeAccesoryQueryHandler : IRequestHandler<GetByIdTaksQuery, EditTaks>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdPipeAccesoryQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditTaks> Handle(GetByIdTaksQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<Taks>().GetByIdAsync(request.Id);

            return _mapper.Map<EditTaks>(table);

        }
    }

}
